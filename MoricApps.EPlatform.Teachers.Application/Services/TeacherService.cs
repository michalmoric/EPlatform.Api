using MoricApps.EPlatform.Teachers.Api.Repositories;
using MoricApps.EPlatform.Teachers.Domain.Models;

namespace MoricApps.EPlatform.Teachers.Application.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _repository;
        private readonly IEmailService _emailService;
        public TeacherService(ITeacherRepository repository,IEmailService emailService)
        {
            _repository = repository;
            _emailService = emailService;
        }

        public async Task<List<Teacher>> GetTeachers(int pageSize, int pageNo)
        {
            var teachers = await _repository.GetTeachersAsync(pageSize, pageNo);
            List<Teacher> getDtoList = new List<Teacher>();
            foreach (var teacher in teachers)
            {
                getDtoList.Add(teacher);
            }
            return getDtoList;
        }

        public async Task<Teacher?> GetTeacher(int id)
        {
            var teacher = await _repository.GetTeacherAsync(id);
            if (teacher == null)
            {
                return null;
            }
            return teacher;
        }

        public async Task<Teacher?> AddTeacher(Teacher teacher)
        {
            var result = await _repository.AddTeacherAsync(teacher);
            if (result == null)
            {
                return null;
            }
            _emailService.SendEmailAsync(teacher, EmailTypes.Add);
            return result;
        }

        public async Task<Teacher?> UpdateTeacher(int id, Teacher teacher)
        {
            var result = await _repository.UpdateTeacherAsync(id, teacher);
            if (result == null)
            {
                return null;
            }
            _emailService.SendEmailAsync(result, EmailTypes.Update);
            return result;
        }

        public async Task<Teacher?> DeleteTeacher(int id)
        {
            var teacher = await _repository.GetTeacherAsync(id);
            if (teacher == null)
            {
                return null;
            }
            var updateResult = teacher.Delete();
            var result = await _repository.UpdateTeacherAsync(id, updateResult);
            if (result != null)
            {
                _emailService.SendEmailAsync(result,EmailTypes.Delete);
            }
            return result;
        }

        public async Task<Teacher?> DeactivateTeacher(int id)
        {
            var teacher = await _repository.GetTeacherAsync(id);
            if (teacher == null)
            {
                return null;
            }
            var updateResult = teacher.Disactivate();
            var result = await _repository.UpdateTeacherAsync(id, updateResult);
            if (result != null)
            {
                _emailService.SendEmailAsync(result, EmailTypes.Deactivate);
            }
            return result;
        }

        public async Task<Teacher?> ReactivateTeacher(int id)
        {
            var teacher = await _repository.GetTeacherAsync(id);

            if (teacher == null)
            {
                return null;
            }
            var updateResult = teacher.Reactivate();
            var result = await _repository.UpdateTeacherAsync(id, updateResult);
            if (result != null)
            {
                _emailService.SendEmailAsync(result, EmailTypes.Reactivate);
            }
            return result;
        }

    }
}
