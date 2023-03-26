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
        public async Task GetTeachers()
        {
            await Task.CompletedTask; // TODO Zwroc liste wszystkich nauczycieli
        }
        public async Task GetTeacher(int id)
        {
            await Task.CompletedTask;// TODO Zwroc jednego nauczyciela
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
        public async Task ModifyTeacher(int id)
        {
            await Task.CompletedTask;// TODO Zmodyfikuj dane nauczyciela
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
