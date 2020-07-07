using System;
using System.Collections.Generic;
using System.Text;

namespace SamTech.StudentManagement.Framework
{
    public interface ICourseService
    {
        void addCourse(Course course);
        Course getCourseById(int Id);
        void updateCourse(Course course);
        void deleteCourse(int Id);
    }
}
