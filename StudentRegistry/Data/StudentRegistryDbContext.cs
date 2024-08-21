using Microsoft.EntityFrameworkCore;
using StudentRegistry.Models;
using System.Net;

namespace StudentRegistry.Data
{
    public class StudentRegistryDbContext : DbContext
    {
        public StudentRegistryDbContext(DbContextOptions<StudentRegistryDbContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Mark> Marks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Address)
                .WithOne(a => a.Student)
                .HasForeignKey<Address>(a => a.StudentId);

            modelBuilder.Entity<Mark>()
                .HasOne(m => m.Student)
                .WithMany(s => s.Marks)
                .HasForeignKey(m => m.StudentId);

            modelBuilder.Entity<Mark>()
                .HasOne(m => m.Course)
                .WithMany(c => c.Marks)
                .HasForeignKey(m => m.CourseId);
        }
    }
}
