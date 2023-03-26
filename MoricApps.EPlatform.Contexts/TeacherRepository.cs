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
        public async Task AddTeacherAsync(Teacher teacher)
        {
            await _context.Teachers.AddAsync(teacher);
            await _context.SaveChangesAsync();

        }
    }
}
