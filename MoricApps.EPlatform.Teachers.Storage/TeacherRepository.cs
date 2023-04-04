﻿using Microsoft.EntityFrameworkCore;
using MoricApps.EPlatform.Teachers.Api.Repositories;
using MoricApps.EPlatform.Teachers.Domain.Models;
using MoricApps.EPlatform.Teachers.Storage.Mappers;

namespace MoricApps.EPlatform.Teachers.Storage
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly TeachersDbContext _context;
        public TeacherRepository(TeachersDbContext context)
        {
            _context = context;
        }

        public async Task<Teacher?> AddTeacherAsync(Teacher teacher)
        {
            var entity = teacher.MapToEntity();
            await _context.Teachers.AddAsync(entity);
            await _context.SaveChangesAsync();
            return teacher;

        }

        public async Task<Teacher?> UpdateTeacherAsync(int Id, Teacher teacher)
        {
            var currentTeacher = await _context.Teachers.Include(t =>t.Assigments).FirstOrDefaultAsync(t => t.Id == Id);
            if (currentTeacher == null || teacher == null)
            {
                return null;
            }
            currentTeacher.FirstName = teacher.FirstName;
            currentTeacher.LastName = teacher.LastName;
            currentTeacher.PhoneNumber = teacher.PhoneNumber;
            currentTeacher.Email = teacher.Email;
            currentTeacher.IsDeleted = teacher.IsDeleted;
            currentTeacher.Status = teacher.Status;
            currentTeacher.Assigments.Clear();
            foreach(var assigment in teacher.Assigments)
            {
                currentTeacher.Assigments.Add(assigment.MapToEntity());
            }
            await _context.SaveChangesAsync();
            return currentTeacher.MapToModel();
        }

        public async Task<List<Teacher>> GetTeachersAsync(int pageSize, int pageNo)
        {
            var teachers = await _context.Teachers.Include(t => t.Assigments).Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync();
            List<Teacher> teacherList = new List<Teacher>();
            foreach (var teacher in teachers)
            {
                teacherList.Add(teacher.MapToModel());
            }
            return teacherList;

        }

        public async Task<Teacher?> GetTeacherAsync(int Id)
        {

            var teacher = await _context.Teachers.Include(t => t.Assigments).FirstOrDefaultAsync(x => x.Id == Id);
            var teacherModel = teacher.MapToModel();
            return teacherModel;
        }
    }

}