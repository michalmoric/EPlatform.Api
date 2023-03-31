using Microsoft.EntityFrameworkCore;
using MoricApps.EPlatform.Teachers.Domain.Models;
using MoricApps.EPlatform.Teachers.Storage;
using MoricApps.EPlatform.Teachers.Storage.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoricApps.EPlatform.Teachers.Storage
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly TeachersDbContext _context;
        public TeacherRepository(TeachersDbContext context)
        {
            _context = context;
        }
        private TeacherEntity ConvertTeacher(Teacher teacher)
        {
            if (teacher == null) return null;
            TeacherEntity entity= new TeacherEntity(teacher.FirstName,teacher.LastName,teacher.Email,teacher.PhoneNumber);
            entity.Id = teacher.Id;
            entity.Status = teacher.Status;
            return entity;

        }
        private Teacher ConvertEntity(TeacherEntity entity)
        {
            if (entity == null) return null;
            Teacher teacher = new Teacher(entity.FirstName, entity.LastName, entity.Email, entity.PhoneNumber);
            teacher.Id = entity.Id;
            teacher.Status = entity.Status;
            return teacher;

        }
        private TeacherAssigment ConvertAssigments(TeacherAssigmentEntity entity)
        {
            if (entity == null) return null;
            TeacherAssigment assigment = new TeacherAssigment();
            assigment.Id = entity.Id;
            assigment.Teacher=ConvertEntity(entity.Teacher);
            assigment.BeginDate = entity.BeginDate;
            assigment.EndDate = entity.EndDate;
            return assigment;
        }
        public async Task<Teacher> AddTeacherAsync(Teacher teacher)
        {
            var entity = ConvertTeacher(teacher);
            await _context.Teachers.AddAsync(entity);
            await _context.SaveChangesAsync();
            return teacher;

        }
        public async Task<Teacher> ModyfyTeacherAsync(int Id, Teacher teacher)
        {
            var currentTeacher = await _context.Teachers.FirstOrDefaultAsync(t => t.Id == Id);
            if (currentTeacher == null)
            {
                return null;
            }
            currentTeacher.FirstName = teacher.FirstName;
            currentTeacher.LastName = teacher.LastName;
            currentTeacher.PhoneNumber = teacher.PhoneNumber;
            currentTeacher.Email = teacher.Email;
            await _context.SaveChangesAsync();
            var temp = ConvertEntity(currentTeacher);
            return temp;
        }
        public async Task<Teacher> DisactivateTeacherAsync(int Id)
        {
            var teacher = await _context.Teachers.FirstOrDefaultAsync(t => t.Id == Id);
            if (teacher == null)
            {
                return null;
            }
            teacher.Disactivate();
            await _context.SaveChangesAsync();
            var temp = ConvertEntity(teacher);
            return temp;
        }
        public async Task<Teacher> ReactivateTeacherAsync(int Id)
        {
            var teacher = await _context.Teachers.FirstOrDefaultAsync(t=>t.Id == Id);
            if(teacher == null)
            {
                return null;
            }
            teacher.Reactivate();
            await _context.SaveChangesAsync();
            var temp = ConvertEntity(teacher);
            return temp;
        }
        public async Task<Teacher> DeleteTeacherAsync(int Id)
        {
            var teacher = await _context.Teachers.FirstOrDefaultAsync(t=>t.Id==Id);
            if (teacher == null)
            {
                return null;
            }
            teacher.IsDeleted = true;
            await _context.SaveChangesAsync();
            var temp = ConvertEntity(teacher);
            return temp;
        }
        public async Task<List<Teacher>> GetTeachersAsync(int pageSize, int pageNo)
        {
            var teachers = await _context.Teachers.Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync();
            List<Teacher> temp = new List<Teacher>();
            foreach (var teacher in teachers)
            {
                temp.Add(ConvertEntity(teacher));
            }
            return temp;

        }
        public async Task<Teacher?> GetTeacherAsync(int Id)
        {

            var teacher = await _context.Teachers.FirstOrDefaultAsync(x => x.Id == Id);
            var temp = ConvertEntity(teacher);
            return temp;
        }
        public async Task<IEnumerable<TeacherAssigment>?> GetAssigmentsAsync(int Id)
        {
            var assigments = await _context.Assigments.IgnoreQueryFilters().Where(t => t.Teacher.Id == Id).ToListAsync();
            List<TeacherAssigment>? temp = new List<TeacherAssigment>();
            foreach (var assigment in assigments)
            {
                temp.Add(ConvertAssigments(assigment));
            }
            return temp;
        }
    }

}