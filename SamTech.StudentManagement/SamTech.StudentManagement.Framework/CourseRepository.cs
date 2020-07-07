using Microsoft.EntityFrameworkCore;
using SamTech.StudentManagement.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace SamTech.StudentManagement.Framework
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        public CourseRepository(DbContext dbContext)
            : base(dbContext)
        {

        }
    }
}
