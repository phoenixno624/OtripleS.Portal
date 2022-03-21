using OtripleS.Portal.Web.Models.StudentViews;
using OtripleS.Portal.Web.Models.StudentViews.Exceptions;

namespace OtripleS.Portal.Web.Services.StudentViews
{
    public partial class StudentViewService
    {
        static void ValidateStudentView(StudentView studentView)
        {
            switch (studentView)
            {
                case null:
                    throw new NullStudentViewException();

                case { } when IsInvalid(studentView.IdentityNumber):
                    throw new InvalidStudentViewException(
                        parameterName: nameof(studentView.IdentityNumber),
                        parameterValue: studentView.IdentityNumber);

                case { } when IsInvalid(studentView.FirstName):
                    throw new InvalidStudentViewException(
                        parameterName: nameof(studentView.FirstName),
                        parameterValue: studentView.FirstName);

                case { } when IsInvalid(studentView.BirthDate):
                    throw new InvalidStudentViewException(
                        parameterName: nameof(studentView.BirthDate),
                        parameterValue: studentView.BirthDate);
            }
        }

        static bool IsInvalid(string text) =>
            string.IsNullOrWhiteSpace(text);
        static bool IsInvalid(DateTimeOffset date) =>
            date == default;
    }
}