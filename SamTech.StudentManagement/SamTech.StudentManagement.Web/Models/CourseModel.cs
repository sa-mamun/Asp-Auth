using Autofac;
using SamTech.StudentManagement.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SamTech.StudentManagement.Web.Models
{
    public class CourseModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int SeatCount { get; set; }
        public int Fee { get; set; }

        public void createCourse()
        {
            var course = new Course
            {
                Title = this.Title,
                SeatCount = this.SeatCount,
                Fee = this.Fee
            };

            var service = Startup.AutofacContainer.Resolve<ICourseService>();
            service.addCourse(course);
        }

        public void editCourse()
        {
            var editService = Startup.AutofacContainer.Resolve<ICourseService>();
            var course = editService.getCourseById(this.Id);

            course.Title = this.Title;
            course.SeatCount = this.SeatCount;
            course.Fee = this.Fee;

            editService.updateCourse(course);
        }

        internal void deleteCourse()
        {
            var deleteService = Startup.AutofacContainer.Resolve<ICourseService>();
            deleteService.deleteCourse(this.Id);
        }
    }
}
