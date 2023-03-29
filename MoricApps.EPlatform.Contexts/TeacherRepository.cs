using Microsoft.EntityFrameworkCore;
using MoricApps.EPlatform.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoricApps.EPlatform.Contexts
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly TeachersDbContext _context;
        public TeacherRepository(TeachersDbContext context)
        {
            _context = context;
        }
        public async Task<Teacher> AddTeacherAsync(Teacher teacher)
        {
            await _context.Teachers.AddAsync(teacher);
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
            return currentTeacher;
        }
        public async Task<Teacher> DisactivateTeacherAsync(int Id)
        {
            var teacher = await _context.Teachers.FirstOrDefaultAsync(t => t.Id == Id);
            if(teacher == null)
            {
                return null;
            }
            teacher.Disactivate();
            await _context.SaveChangesAsync();
            return teacher;
        }
        public async Task<List<Teacher>> GetTeachersAsync(int pageSize, int pageNo)
        {
            return await _context.Teachers.Skip((pageNo-1)*pageSize).Take(pageSize).ToListAsync();
            
        }
        public async Task<Teacher?> GetTeacherAsync(int Id)
        {

            return await  _context.Teachers.FirstOrDefaultAsync(x => x.Id == Id);
        }
        public async Task<IEnumerable<TeacherAssigment>?> GetAssigmentsAsync(int Id)
        {
            var assigments = await _context.Assigments.Where(t => t.Id == Id).ToListAsync();
            return assigments;
        }
    }

}