using System;
using System.Collections.Generic;
using System.Text;

namespace SamTech.StudentManagement.Framework
{
    public class StudentRegistration
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public DateTime EnrollDate { get; set; }
        public bool isPaymentComplete { get; set; }
        public Student Student { get; set; }
        public Course Course { get; set; }
    }
}
