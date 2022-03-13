using OtripleS.Portal.Web.Models.Students;
using OtripleS.Portal.Web.Models.Students.Exceptions;

namespace OtripleS.Portal.Web.Services.Students
{
    public partial class StudentService
    {
        void ValidateStudent(Student student)
        {
            switch (student)
            {
                case null:
                    throw new NullStudentException();
                case { } when IsInvalid(student.Id):
                    throw new InvalidStudentException(
                        parameterName: nameof(student.Id),
                        parameterValue: student.Id);
            }
        }

        static bool IsInvalid(Guid id) =>
            id == Guid.Empty;
    }
}