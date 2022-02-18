using OtripleS.Portal.Web.Models.Students;
using OtripleS.Portal.Web.Models.Students.Exceptions;

namespace OtripleS.Portal.Web.Services.Students
{
    public partial class StudentService
    {
        void ValidateStudent(Student student)
        {
            if (student is null)
                throw new NullStudentException();
        }
    }
}