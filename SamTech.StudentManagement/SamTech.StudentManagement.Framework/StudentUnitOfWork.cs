using SamTech.StudentManagement.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace SamTech.StudentManagement.Framework
{
    public class StudentUnitOfWork : UnitOfWork<FrameworkContext>, IStudentUnitOfWork
    {
        public IStudentRepository StudentRepository { get; set; }
        public ICourseRepository CourseRepository { get; set; }
        public IStudentRegistrationRepository StudentRegistrationRepository { get; set; }

        public StudentUnitOfWork(string connectionString, string migrationAssemblyName)
            : base(connectionString, migrationAssemblyName)
        {
            StudentRepository = new StudentRepository(_dbContext);
            CourseRepository = new CourseRepository(_dbContext);
            StudentRegistrationRepository = new StudentRegistrationRepository(_dbContext);
        }
    }
}
