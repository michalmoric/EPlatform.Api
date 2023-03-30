using Microsoft.EntityFrameworkCore;
using MoricApps.EPlatform.Teachers.Domain.Models;
using MoricApps.EPlatform.Teachers.Storage.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoricApps.EPlatform.Teachers.Storage
{
    public class TeachersDbContext : DbContext
    {
        public DbSet<TeacherEntity> Teachers { get; set; } = null!;

        public DbSet<TeacherAssigmentEntity> Assigments { get; set; } = null!;
        public TeachersDbContext(DbContextOptions<TeachersDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TeacherEntity>().HasData(
                new TeacherEntity("Michal", "Moric", "michamoric@interia.pl", "+48694871704")
                {
                    Id = 1
                });
            base.OnModelCreating(modelBuilder);
        }
    }
}
