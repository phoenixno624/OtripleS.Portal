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

                case { } when IsInvalid(student.UserId):
                    throw new InvalidStudentException(
                        parameterName: nameof(student.UserId),
                        parameterValue: student.UserId);

                case { } when IsInvalid(student.IdentityNumber):
                    throw new InvalidStudentException(
                        parameterName: nameof(student.IdentityNumber),
                        parameterValue: student.IdentityNumber);

                case { } when IsInvalid(student.FirstName):
                    throw new InvalidStudentException(
                        parameterName: nameof(student.FirstName),
                        parameterValue: student.FirstName);

                case { } when IsInvalid(student.BirthDate):
                    throw new InvalidStudentException(
                        parameterName: nameof(student.BirthDate),
                        parameterValue: student.BirthDate);

                case { } when IsInvalid(student.CreatedBy):
                    throw new InvalidStudentException(
                        parameterName: nameof(student.CreatedBy),
                        parameterValue: student.CreatedBy);

                case { } when IsInvalid(student.UpdatedBy):
                    throw new InvalidStudentException(
                        parameterName: nameof(student.UpdatedBy),
                        parameterValue: student.UpdatedBy);
            }
        }

        static bool IsInvalid(Guid id) =>
            id == Guid.Empty;
        static bool IsInvalid(string text) =>
            string.IsNullOrWhiteSpace(text);
        static bool IsInvalid(DateTimeOffset date) =>
            date == default;
    }
}