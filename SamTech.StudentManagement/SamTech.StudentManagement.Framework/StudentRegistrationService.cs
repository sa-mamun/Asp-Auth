using System;
using System.Collections.Generic;
using System.Text;

namespace SamTech.StudentManagement.Framework
{
    public class StudentRegistrationService : IStudentRegistrationService
    {
        private IStudentUnitOfWork _studentUnitOfWork;

        public StudentRegistrationService(IStudentUnitOfWork studentUnitOfWork)
        {
            _studentUnitOfWork = studentUnitOfWork;
        }

        public void addRegistration(StudentRegistration studentRegistration)
        {
            _studentUnitOfWork.StudentRegistrationRepository.Add(studentRegistration);
            _studentUnitOfWork.Save();
        }
    }
}
