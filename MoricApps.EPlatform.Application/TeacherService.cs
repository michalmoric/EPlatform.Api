using Microsoft.IdentityModel.Tokens;
using MoricApps.EPlatform.Teachers.Contract;
using MoricApps.EPlatform.Teachers.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoricApps.EPlatform.Teachers.Storage
{
    public class TeacherService : ITeacherService // Logika przetwarzająca dane idące z lub do bazy
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
                getDtoList.Add(new TeacherReturnDto
                {
                    Id = teacher.Id,
                    FirstName = teacher.FirstName,
                    LastName = teacher.LastName,
                    Email = teacher.Email,
                    PhoneNumber = teacher.PhoneNumber,
                    Status = teacher.Status
                });
            }
            return getDtoList;
        }
        public async Task<TeacherReturnDto> GetTeacher(int id)
        {
            var teacher = await _repository.GetTeacherAsync(id);
            TeacherReturnDto getDto = new TeacherReturnDto();
            if (teacher == null)
            {
                return null;
            }
            getDto.Id = teacher.Id;
            getDto.FirstName = teacher.FirstName;
            getDto.LastName = teacher.LastName;
            getDto.Email = teacher.Email;
            getDto.PhoneNumber = teacher.PhoneNumber;
            getDto.Status = teacher.Status;
            return getDto;
        }
        public async Task<TeacherReturnDto> AddTeacher(TeacherInputDto teacher)
        {
            var temp = new Teacher(teacher.FirstName,teacher.LastName,teacher.Email,teacher.PhoneNumber);
            var result = await _repository.AddTeacherAsync(temp);
            TeacherReturnDto addDto = new TeacherReturnDto();
            addDto.Id = result.Id;
            addDto.FirstName = result.FirstName;
            addDto.LastName = result.LastName;
            addDto.Email = result.Email;
            addDto.PhoneNumber = result.PhoneNumber;
            addDto.Status = result.Status;
            return addDto;
        }
        public async Task<TeacherReturnDto> ModifyTeacher(int id, TeacherInputDto teacher)
        {
            var temp = new Teacher(teacher.FirstName, teacher.LastName, teacher.Email, teacher.PhoneNumber);
            var result = await _repository.ModyfyTeacherAsync(id, temp);
            if (result == null)
            {
                return null;
            }
            TeacherReturnDto modifyDto = new TeacherReturnDto();
            modifyDto.Id = result.Id;
            modifyDto.FirstName = result.FirstName;
            modifyDto.LastName = result.LastName;
            modifyDto.Email = result.Email;
            modifyDto.PhoneNumber = result.PhoneNumber;
            return modifyDto;
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
            TeacherReturnDto deleteDto = new TeacherReturnDto();
            deleteDto.Id = teacher.Id;
            deleteDto.FirstName = teacher.FirstName;
            deleteDto.LastName = teacher.LastName;
            deleteDto.Email = teacher.Email;
            deleteDto.PhoneNumber = teacher.PhoneNumber;
            return deleteDto;
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
            TeacherReturnDto deactDto = new TeacherReturnDto();
            deactDto.Id = teacher.Id;
            deactDto.FirstName = teacher.FirstName;
            deactDto.LastName = teacher.LastName;
            deactDto.Email = teacher.Email;
            deactDto.PhoneNumber = teacher.PhoneNumber;
            deactDto.Status = teacher.Status;
            return deactDto;
        }
        public async Task<TeacherReturnDto> ReactivateTeacher(int id)
        {
            var teacher = await _repository.ReactivateTeacherAsync(id);

            if(teacher == null)
            {
                return null;
            }
            TeacherReturnDto reactDto = new TeacherReturnDto();
            reactDto.Id = teacher.Id;
            reactDto.FirstName = teacher.FirstName;
            reactDto.LastName = teacher.LastName;
            reactDto.Email = teacher.Email;
            reactDto.PhoneNumber = teacher.PhoneNumber;
            reactDto.Status = teacher.Status;
            return reactDto;
        }

    }
}
