using System;
using System.Collections.Generic;
using System.Text;

namespace SamTech.StudentManagement.Framework
{
    public class StudentService : IStudentService
    {
        private IStudentUnitOfWork _studentUnitOfWork;

        public StudentService(IStudentUnitOfWork studentUnitOfWork)
        {
            _studentUnitOfWork = studentUnitOfWork;
        }

        public void addStudent(Student student)
        {
            _studentUnitOfWork.StudentRepository.Add(student);
            _studentUnitOfWork.Save();
        }

        public void deleteStudent(int Id)
        {
            _studentUnitOfWork.StudentRepository.Remove(Id);
            _studentUnitOfWork.Save();
        }

        public Student getStudentById(int Id)
        {
            return _studentUnitOfWork.StudentRepository.GetById(Id);
        }

        public void updateStuent(Student student)
        {
            _studentUnitOfWork.StudentRepository.Edit(student);
            _studentUnitOfWork.Save();
        }
    }
}
