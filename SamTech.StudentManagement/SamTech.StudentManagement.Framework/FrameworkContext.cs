using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace SamTech.StudentManagement.Framework
{
    public class FrameworkContext : DbContext, IFrameworkContext
    {
        private string _connectionString;
        private string _migrationAssemblyName;

        public FrameworkContext(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            if (!dbContextOptionsBuilder.IsConfigured)
            {
                dbContextOptionsBuilder.UseSqlServer(
                    _connectionString,
                    m => m.MigrationsAssembly(_migrationAssemblyName));
            }

            base.OnConfiguring(dbContextOptionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Many to many relation
            builder.Entity<StudentRegistration>()
                .HasKey(pc => new { pc.StudentId, pc.CourseId });

            builder.Entity<StudentRegistration>()
                .HasOne(pc => pc.Student)
                .WithMany(p => p.Courses)
                .HasForeignKey(pc => pc.StudentId);

            builder.Entity<StudentRegistration>()
                .HasOne(pc => pc.Course)
                .WithMany(c => c.Students)
                .HasForeignKey(pc => pc.CourseId);

            base.OnModelCreating(builder);
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
