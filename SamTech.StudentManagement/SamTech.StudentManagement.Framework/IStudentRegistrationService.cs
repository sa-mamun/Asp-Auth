using System;
using System.Collections.Generic;
using System.Text;

namespace SamTech.StudentManagement.Framework
{
    public interface IStudentRegistrationService
    {
        void addRegistration(StudentRegistration studentRegistration);
    }
}
