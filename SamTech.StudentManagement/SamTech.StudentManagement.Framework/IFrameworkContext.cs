using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace SamTech.StudentManagement.Framework
{
    public interface IFrameworkContext
    {
        DbSet<Student> Students { get; set; }
        DbSet<Course> Courses { get; set; }
    }
}
