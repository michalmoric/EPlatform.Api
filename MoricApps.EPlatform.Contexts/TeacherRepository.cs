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
        public async Task<List<Teacher>> GetTeachersAsync(int pageSize, int pageNo)
        {
            return await _context.Teachers.Skip((pageNo-1)*pageSize).Take(pageSize).ToListAsync();
            
        }
        public async Task<Teacher> GetTeacherAsync(int Id)
        {

            return await  _context.Teachers.FirstOrDefaultAsync(x => x.Id == Id);
        }
    }
}
