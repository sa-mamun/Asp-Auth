using System;
using System.Collections.Generic;
using System.Text;

namespace SamTech.StudentManagement.Framework
{
    public class CourseService : ICourseService
    {
        private IStudentUnitOfWork _studentUnitOfWork;

        public CourseService(IStudentUnitOfWork studentUnitOfWork)
        {
            _studentUnitOfWork = studentUnitOfWork;
        }
        public void addCourse(Course course)
        {
            _studentUnitOfWork.CourseRepository.Add(course);
            _studentUnitOfWork.Save();
        }

        public void deleteCourse(int Id)
        {
            _studentUnitOfWork.CourseRepository.Remove(Id);
            _studentUnitOfWork.Save();
        }

        public Course getCourseById(int Id)
        {
            return _studentUnitOfWork.CourseRepository.GetById(Id);
        }

        public void updateCourse(Course course)
        {
            _studentUnitOfWork.CourseRepository.Edit(course);
            _studentUnitOfWork.Save();
        }
    }
}
