using Microsoft.EntityFrameworkCore;
using MoricApps.EPlatform.Teachers.Storage.Entities;

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
            modelBuilder.Entity<TeacherEntity>().HasMany(t => t.Assigments).WithOne(a => a.Teacher);
            modelBuilder.Entity<TeacherEntity>().HasQueryFilter(t => !t.IsDeleted);
            base.OnModelCreating(modelBuilder);
        }
    }
}
