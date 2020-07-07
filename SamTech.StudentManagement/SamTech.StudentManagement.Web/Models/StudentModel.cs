using SamTech.StudentManagement.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;

namespace SamTech.StudentManagement.Web.Models
{
    public class StudentModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }

        public void createStudent()
        {
            var student = new Student
            {
                Name = this.Name,
                DateOfBirth = this.DateOfBirth
            };
            var service = Startup.AutofacContainer.Resolve<IStudentService>();
            service.addStudent(student);

        }

        public void editStudent()
        {
            var editService = Startup.AutofacContainer.Resolve<IStudentService>();
            var student = editService.getStudentById(this.Id);
            student.Name = this.Name;
            student.DateOfBirth = this.DateOfBirth;

            editService.updateStuent(student);
        }

        internal void deleteStudent()
        {
            var editService = Startup.AutofacContainer.Resolve<IStudentService>();
            editService.deleteStudent(this.Id);
        }
    }
}
