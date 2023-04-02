using Microsoft.IdentityModel.Tokens;
using MoricApps.EPlatform.Teachers.Application.Mapper;
using MoricApps.EPlatform.Teachers.Application.Repositories;
using MoricApps.EPlatform.Teachers.Contract;
using MoricApps.EPlatform.Teachers.Domain.Models;

namespace MoricApps.EPlatform.Teachers.Application.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _repository;
        public TeacherService(ITeacherRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<TeacherReturnDto>> GetTeachers(int pageSize, int pageNo)
        {
            var teachers = await _repository.GetTeachersAsync(pageSize, pageNo);
            List<TeacherReturnDto> getDtoList = new List<TeacherReturnDto>();
            foreach (var teacher in teachers)
            {
                getDtoList.Add(teacher.MapToDto());
            }
            return getDtoList;
        }
        public async Task<TeacherReturnDto> GetTeacher(int id)
        {
            var teacher = await _repository.GetTeacherAsync(id);
            if (teacher == null)
            {
                return null;
            }
            return teacher.MapToDto();
        }
        public async Task<TeacherReturnDto> AddTeacher(Teacher teacher)
        {
            var result = await _repository.AddTeacherAsync(teacher);
            if (result == null)
            {
                return null;
            }
            return result.MapToDto();
        }
        public async Task<TeacherReturnDto> ModifyTeacher(int id, Teacher teacher)
        {
            var result = await _repository.ModyfyTeacherAsync(id, teacher);
            if (result == null)
            {
                return null;
            }
            return result.MapToDto();
        }
        public async Task<TeacherReturnDto> DeleteTeacher(int id)
        {
            var assigments = await _repository.GetAssigmentsAsync(id);
            if (!assigments.IsNullOrEmpty())
            {
                foreach (var assigment in assigments)
                {
                    if (assigment.EndDate > DateTime.Now)
                    {
                        return null;
                    }
                }
            }
            var teacher = await _repository.DeleteTeacherAsync(id);
            if (teacher == null)
            {
                return null;
            }
            return teacher.MapToDto();
        }
        public async Task<TeacherReturnDto> DeactivateTeacher(int id)
        {
            var assigments = await _repository.GetAssigmentsAsync(id);
            if (!assigments.IsNullOrEmpty())
            {
                foreach (var assigment in assigments)
                {
                    if (assigment.EndDate > DateTime.Now)
                    {
                        return null;
                    }
                }
            }
            var teacher = await _repository.DisactivateTeacherAsync(id);
            if (teacher == null)
            {
                return null;
            }
            return teacher.MapToDto();
        }
        public async Task<TeacherReturnDto> ReactivateTeacher(int id)
        {
            var teacher = await _repository.ReactivateTeacherAsync(id);

            if (teacher == null)
            {
                return null;
            }
            return teacher.MapToDto();
        }

    }
}
