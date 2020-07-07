using Microsoft.EntityFrameworkCore;
using SamTech.StudentManagement.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace SamTech.StudentManagement.Framework
{
    public class StudentRegistrationRepository : Repository<StudentRegistration>, IStudentRegistrationRepository
    {
        public StudentRegistrationRepository(DbContext dbContext)
            : base(dbContext)
        {

        }
    }
}
