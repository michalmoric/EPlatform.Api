using MoricApps.EPlatform.Contexts;
using MoricApps.EPlatform.Domain.Models;
using MoricApps.EPlatform.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoricApps.EPlatform.Application
{
    public class TeacherService : ITeacherService // Logika przetwarzająca dane idące z lub do bazy
    {
        private readonly ITeacherRepository _repository;
        public TeacherService(ITeacherRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<TeacherGetDto>> GetTeachers(int pageSize,int pageNo)
        {
            var teachers = await _repository.GetTeachersAsync(pageSize,pageNo);
            List<TeacherGetDto> getDtoList = new List<TeacherGetDto>();
            foreach(var teacher in teachers)
            {
                getDtoList.Add(new TeacherGetDto
                {
                    Id = teacher.Id,
                    FirstName = teacher.FirstName,
                    LastName = teacher.LastName,
                    Email = teacher.Email,
                    PhoneNumber = teacher.PhoneNumber
                });
            }
            return getDtoList;
        }
        public async Task<TeacherGetDto> GetTeacher(int id)
        {
            var teacher = await _repository.GetTeacherAsync(id);
            TeacherGetDto getDto = new TeacherGetDto();
            if(teacher == null)
            {
                return null;
            }
            getDto.Id = teacher.Id;
            getDto.FirstName = teacher.FirstName;
            getDto.LastName = teacher.LastName;
            getDto.Email = teacher.Email;
            getDto.PhoneNumber = teacher.PhoneNumber;
            return getDto;
        }
        public async Task<TeacherAddDto> AddTeacher(Teacher teacher)
        {
            var result= await _repository.AddTeacherAsync(teacher);
            TeacherAddDto addDto = new TeacherAddDto();
            addDto.Id = teacher.Id;
            addDto.FirstName = teacher.FirstName;
            addDto.LastName = teacher.LastName;
            addDto.Email = teacher.Email;
            addDto.PhoneNumber = teacher.PhoneNumber;
            return addDto;
        }
        public async Task<TeacherModyfyDto> ModifyTeacher(int id,Teacher teacher)
        {
            var result = await _repository.ModyfyTeacherAsync(id, teacher);
            if(result == null)
            {
                return null;
            }
            TeacherModyfyDto modifyDto = new TeacherModyfyDto();
            modifyDto.Id = result.Id;
            modifyDto.FirstName = result.FirstName;
            modifyDto.LastName = result.LastName;
            modifyDto.Email = result.Email;
            modifyDto.PhoneNumber = result.PhoneNumber;
            return modifyDto;
        }
        public async Task DeleteTeacher(int id)
        {
            await Task.CompletedTask;// TODO Wyrejestruj nauczyciela
        }
        public async Task DeactivateTeacher(int id)
        {
            await Task.CompletedTask;//TODO Zawieś nauczyciela
        }
        public async Task ReactivateTeacher(int id)
        {
            await Task.CompletedTask;// TODO Odwieś nauczyciela
        }

    }
}
