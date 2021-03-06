using OtripleS.Portal.Web.Models.Students;
using OtripleS.Portal.Web.Models.Students.Exceptions;
using RESTFulSense.WebAssembly.Exceptions;

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
            catch (InvalidStudentException invalidStudentException)
            {
                throw CreateAndLogValidationException(invalidStudentException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                throw CreateAndLogCriticalDependencyException(httpResponseUrlNotFoundException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                throw CreateAndLogCriticalDependencyException(httpResponseUnauthorizedException);
            }
            catch (HttpResponseConflictException httpResponseConflictException)
            {
                throw CreateAndLogDependencyValidationException(httpResponseConflictException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                throw CreateAndLogDependencyValidationException(httpResponseBadRequestException);
            }
            catch (HttpResponseInternalServerErrorException httpResponseInternalServerErrorException)
            {
                throw CreateAndLogDependencyException(httpResponseInternalServerErrorException);
            }
            catch (HttpResponseException httpResponseException)
            {
                throw CreateAndLogDependencyException(httpResponseException);
            }
            catch (Exception exception)
            {
                throw CreateAndLogServiceException(exception);
            }
        }

        private StudentValidationException CreateAndLogValidationException(
            Exception exception)
        {
            var studentValidationException =
                new StudentValidationException(exception);

            this.loggingBroker.LogError(studentValidationException);

            return studentValidationException;
        }
        private StudentDependencyValidationException CreateAndLogDependencyValidationException(
            Exception exception)
        {
            var studentDependencyValidationException =
                new StudentDependencyValidationException(exception);

            this.loggingBroker.LogError(studentDependencyValidationException);

            return studentDependencyValidationException;
        }
        private StudentDependencyException CreateAndLogCriticalDependencyException(
            Exception exception)
        {
            var studentDependencyException =
                new StudentDependencyException(exception);

            this.loggingBroker.LogCritical(studentDependencyException);

            return studentDependencyException;
        }
        private StudentDependencyException CreateAndLogDependencyException(
            Exception exception)
        {
            var studentDependencyException =
                new StudentDependencyException(exception);

            this.loggingBroker.LogError(studentDependencyException);

            return studentDependencyException;
        }
        private StudentServiceException CreateAndLogServiceException(
            Exception exception)
        {
            var studentDependencyException =
                new StudentServiceException(exception);

            this.loggingBroker.LogError(studentDependencyException);

            return studentDependencyException;
        }
    }
}