using OtripleS.Portal.Web.Models.Students;
using OtripleS.Portal.Web.Models.Students.Exceptions;

namespace OtripleS.Portal.Web.Services.Students
{
    public partial class StudentService
    {
        delegate ValueTask<Student> ReturningStudentFunction();

        async ValueTask<Student> TryCatch(ReturningStudentFunction returningStudentFunction)
        {
            try
            {
                return await returningStudentFunction();
            }
            catch (NullStudentException nullStudentException)
            {
                throw CreateAndLogValidationException(nullStudentException);
            }
        }

        private StudentValidationException CreateAndLogValidationException(NullStudentException nullStudentException)
        {
            var studentValidationException = new StudentValidationException(nullStudentException);

            this.loggingBroker.LogError(studentValidationException);

            return studentValidationException;
        }
    }
}