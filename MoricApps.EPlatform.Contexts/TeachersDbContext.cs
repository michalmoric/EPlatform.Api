using Microsoft.EntityFrameworkCore;
using MoricApps.EPlatform.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoricApps.EPlatform.Contexts
{
    public class TeachersDbContext: DbContext
    {
        public DbSet<Teacher> Teachers { get; set; } = null!;

        public DbSet<TeacherAssigment> Assigments { get; set; } = null!;
        public TeachersDbContext(DbContextOptions<TeachersDbContext> options) : base(options) 
        { 

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Teacher>().HasData(
                new Teacher("Michal", "Moric", "michamoric@interia.pl", "+48694871704")
                {
                    Id = 1
                });
            base.OnModelCreating(modelBuilder);
        }
    }
}
