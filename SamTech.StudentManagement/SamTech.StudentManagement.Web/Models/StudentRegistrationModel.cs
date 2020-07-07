using Autofac;
using SamTech.StudentManagement.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SamTech.StudentManagement.Web.Models
{
    public class StudentRegistrationModel
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public DateTime EnrollDate { get; set; }
        public bool isPaymentComplete { get; set; }

        public void createRegistration()
        {
            var studentRegistration = new StudentRegistration
            {
                StudentId = this.StudentId,
                CourseId = this.CourseId,
                EnrollDate = this.EnrollDate,
                isPaymentComplete = this.isPaymentComplete
            };
            var service = Startup.AutofacContainer.Resolve<IStudentRegistrationService>();
            service.addRegistration(studentRegistration);
        }
    }
}
