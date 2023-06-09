﻿using MoricApps.EPlatform.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoricApps.EPlatform.Application
{
    public class TeacherService : ITeacherService // Logika przetwarzająca dane idące z lub do bazy
    {
        public async Task GetTeachers()
        {
            await Task.CompletedTask; // TODO Zwroc liste wszystkich nauczycieli
        }
        public async Task GetTeacher(int id)
        {
            await Task.CompletedTask;// TODO Zwroc jednego nauczyciela
        }
        public async Task AddTeacher()
        {
            await Task.CompletedTask;// TODO Zarejestruj nauczyciela
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
