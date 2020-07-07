using System;
using System.Collections.Generic;

namespace SamTech.StudentManagement.Framework
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public IList<StudentRegistration> Courses { get; set; }
    }
}
