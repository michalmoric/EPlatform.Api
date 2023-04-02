using Microsoft.EntityFrameworkCore;
using MoricApps.EPlatform.Teachers.Application.Repositories;
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
        public async Task<Teacher> AddTeacherAsync(Teacher teacher)
        {
            var entity = teacher.MapToEntity();
            await _context.Teachers.AddAsync(entity);
            await _context.SaveChangesAsync();
            return teacher;

        }
        public async Task<Teacher> ModyfyTeacherAsync(int Id, Teacher teacher)
        {
            var currentTeacher = await _context.Teachers.Include(t =>t.Assigments).FirstOrDefaultAsync(t => t.Id == Id);
            if (currentTeacher == null)
            {
                return null;
            }
            currentTeacher.FirstName = teacher.FirstName;
            currentTeacher.LastName = teacher.LastName;
            currentTeacher.PhoneNumber = teacher.PhoneNumber;
            currentTeacher.Email = teacher.Email;
            currentTeacher.Assigments.Clear();
            foreach(var assigment in teacher.Assigments)
            {
                currentTeacher.Assigments.Add(assigment.MapToEntity());
            }
            await _context.SaveChangesAsync();
            return currentTeacher.MapToModel();
        }
        public async Task<Teacher> DisactivateTeacherAsync(int Id)
        {
            var teacher = await _context.Teachers.Include(t =>t.Assigments).FirstOrDefaultAsync(t => t.Id == Id);
            if (teacher == null)
            {
                return null;
            }
            teacher.Disactivate();
            await _context.SaveChangesAsync();
            return teacher.MapToModel();
        }
        public async Task<Teacher> ReactivateTeacherAsync(int Id)
        {
            var teacher = await _context.Teachers.Include(t => t.Assigments).FirstOrDefaultAsync(t=>t.Id == Id);
            if(teacher == null)
            {
                return null;
            }
            teacher.Reactivate();
            await _context.SaveChangesAsync();
            return teacher.MapToModel();
        }
        public async Task<Teacher> DeleteTeacherAsync(int Id)
        {
            var teacher = await _context.Teachers.Include(t => t.Assigments).FirstOrDefaultAsync(t=>t.Id==Id);
            if (teacher == null)
            {
                return null;
            }
            teacher.IsDeleted = true;
            await _context.SaveChangesAsync();
            return teacher.MapToModel();
        }
        public async Task<List<Teacher>> GetTeachersAsync(int pageSize, int pageNo)
        {
            var teachers = await _context.Teachers.Include(t => t.Assigments).Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync();
            List<Teacher> temp = new List<Teacher>();
            foreach (var teacher in teachers)
            {
                temp.Add(teacher.MapToModel());
            }
            return temp;

        }
        public async Task<Teacher?> GetTeacherAsync(int Id)
        {

            var teacher = await _context.Teachers.Include(t => t.Assigments).FirstOrDefaultAsync(x => x.Id == Id);
            var temp = teacher.MapToModel();
            return temp;
        }
        public async Task<IEnumerable<TeacherAssigment>?> GetAssigmentsAsync(int Id)
        {
            //var assigments = await _context.Assigments.IgnoreQueryFilters().Where(t => t.Teacher.Id == Id).ToListAsync();
            //List<TeacherAssigment>? temp = new List<TeacherAssigment>();
            //foreach (var assigment in assigments)
            //{
            //    temp.Add(ConvertAssigments(assigment));
            //}
            //return temp;
            var assigments =  await _context.Teachers.Where(t => t.Id == Id).Select(e => e.Assigments).ToListAsync();
            List<TeacherAssigment> temp = new List<TeacherAssigment>();
            var ass = assigments.FirstOrDefault();
            foreach(var assigment in ass)
            {
                temp.Add(assigment.MapToModel());
            }
            return temp;
        }
    }

}