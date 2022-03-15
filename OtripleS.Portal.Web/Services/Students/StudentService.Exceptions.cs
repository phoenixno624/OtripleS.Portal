﻿using OtripleS.Portal.Web.Models.Students;
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
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                throw CreateAndLogDependencyValidationException(httpResponseBadRequestException);
            }
        }

        private StudentValidationException CreateAndLogValidationException(
            Exception nullStudentException)
        {
            var studentValidationException =
                new StudentValidationException(nullStudentException);

            this.loggingBroker.LogError(studentValidationException);

            return studentValidationException;
        }
        private StudentDependencyValidationException CreateAndLogDependencyValidationException(
            Exception nullStudentException)
        {
            var studentDependencyValidationException =
                new StudentDependencyValidationException(nullStudentException);

            this.loggingBroker.LogError(studentDependencyValidationException);

            return studentDependencyValidationException;
        }
        private StudentDependencyException CreateAndLogCriticalDependencyException(
            Exception nullStudentException)
        {
            var studentDependencyException =
                new StudentDependencyException(nullStudentException);

            this.loggingBroker.LogCritical(studentDependencyException);

            return studentDependencyException;
        }
    }
}