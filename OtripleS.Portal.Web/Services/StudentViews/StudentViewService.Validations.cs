using OtripleS.Portal.Web.Models.Students.Exceptions;
using OtripleS.Portal.Web.Models.StudentViews;

namespace OtripleS.Portal.Web.Services.StudentViews
{
    public partial class StudentViewService
    {
        static void ValidateStudentView(StudentView studentView)
        {
            switch (studentView)
            {
                case { } when IsInvalid(studentView.IdentityNumber):
                    throw new InvalidStudentException(
                        parameterName: nameof(studentView.IdentityNumber),
                        parameterValue: studentView.IdentityNumber);
            }
        }

        static bool IsInvalid(string text) =>
            string.IsNullOrWhiteSpace(text);
    }
}