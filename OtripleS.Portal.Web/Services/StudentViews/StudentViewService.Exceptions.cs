using OtripleS.Portal.Web.Models.Students.Exceptions;
using OtripleS.Portal.Web.Models.StudentViews;
using OtripleS.Portal.Web.Models.StudentViews.Exceptions;

namespace OtripleS.Portal.Web.Services.StudentViews
{
    public partial class StudentViewService
    {
        delegate ValueTask<StudentView> ReturningStudentViewFunction();

        async ValueTask<StudentView> TryCatch(ReturningStudentViewFunction returningStudentViewFunction)
        {
            try
            {
                return await returningStudentViewFunction();
            }
            catch (NullStudentViewException nullStudentViewException)
            {
                throw CreateAndLogValidationException(nullStudentViewException);
            }
            catch (InvalidStudentViewException invalidStudentViewException)
            {
                throw CreateAndLogValidationException(invalidStudentViewException);
            }
            catch (StudentValidationException studentValidationException)
            {
                throw CreateAndLogDependencyValidationException(studentValidationException);
            }
            catch (StudentDependencyValidationException studentDependencyValidationException)
            {
                throw CreateAndLogDependencyValidationException(studentDependencyValidationException);
            }
        }

        StudentViewValidationException CreateAndLogValidationException(Exception exception)
        {
            var studentViewValidationException = new StudentViewValidationException(exception);

            this.loggingBroker.LogError(studentViewValidationException);

            return studentViewValidationException;
        }
        StudentViewDependencyValidationException CreateAndLogDependencyValidationException(Exception exception)
        {
            var studentViewDependencyValidationException = new StudentViewDependencyValidationException(exception);

            this.loggingBroker.LogError(studentViewDependencyValidationException);

            return studentViewDependencyValidationException;
        }
    }
}