using Moq;
using OtripleS.Portal.Web.Models.Students;
using OtripleS.Portal.Web.Models.Students.Exceptions;
using OtripleS.Portal.Web.Models.StudentViews;
using OtripleS.Portal.Web.Models.StudentViews.Exceptions;
using System;
using System.Threading.Tasks;
using Xunit;

namespace OtripleS.Portal.Web.Tests.Unit.Services.StudentViews
{
    public partial class StudentViewServiceTests
    {
        public static TheoryData StudentServiceValidationExceptions()
        {
            var innerException = new Exception();

            return new TheoryData<Exception>
            {
                new StudentValidationException(innerException),
                new StudentDependencyValidationException(innerException)
            };
        }

        [Theory]
        [MemberData(nameof(StudentServiceValidationExceptions))]
        public async Task ShouldThrowDependencyValidationExceptionOnAddIfStudentValidationErrorOccurredAndLogItAsync(
            Exception studentServiceValidationException)
        {
            // given
            StudentView someStudentView = CreateRandomStudentView();

            var expectedDependencyValidationException =
                new StudentViewDependencyValidationException(studentServiceValidationException);

            this.studentServiceMock.Setup(service =>
                service.RegisterStudentAsync(It.IsAny<Student>()))
                    .ThrowsAsync(studentServiceValidationException);

            // when
            ValueTask<StudentView> addStudentViewTask =
                this.studentViewService.AddStudentViewAsync(someStudentView);

            // then
            await Assert.ThrowsAsync<StudentViewDependencyValidationException>(() =>
                addStudentViewTask.AsTask());

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(
                    expectedDependencyValidationException))),
                    Times.Once);

            this.userServiceMock.Verify(service =>
                service.GetCurrentlyLoggedInUser(),
                Times.Once);

            this.dateTimeBrokerMock.Verify(broker =>
                broker.GetCurrentDateTime(),
                Times.Once);

            this.studentServiceMock.Verify(service =>
                service.RegisterStudentAsync(It.IsAny<Student>()),
                Times.Once);

            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.userServiceMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
            this.studentServiceMock.VerifyNoOtherCalls();
        }

        public static TheoryData StudentServiceDependencyExceptions()
        {
            var innerException = new Exception();

            return new TheoryData<Exception>
            {
                new StudentDependencyException(innerException),
                new StudentServiceException(innerException)
            };
        }

        [Theory]
        [MemberData(nameof(StudentServiceDependencyExceptions))]
        public async Task ShouldThrowDependencyExceptionOnAddIfStudentDependencyErrorOccurredAndLogItAsync(
            Exception studentServiceDependencyException)
        {
            // given
            StudentView someStudentView = CreateRandomStudentView();

            var expectedStudentViewDependencyException =
                new StudentViewDependencyException(studentServiceDependencyException);

            this.studentServiceMock.Setup(service =>
                service.RegisterStudentAsync(It.IsAny<Student>()))
                    .ThrowsAsync(studentServiceDependencyException);

            // when
            ValueTask<StudentView> addStudentViewTask =
                this.studentViewService.AddStudentViewAsync(someStudentView);

            // then
            await Assert.ThrowsAsync<StudentViewDependencyException>(() =>
                addStudentViewTask.AsTask());

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(
                    expectedStudentViewDependencyException))),
                    Times.Once);

            this.userServiceMock.Verify(service =>
                service.GetCurrentlyLoggedInUser(),
                Times.Once);

            this.dateTimeBrokerMock.Verify(broker =>
                broker.GetCurrentDateTime(),
                Times.Once);

            this.studentServiceMock.Verify(service =>
                service.RegisterStudentAsync(It.IsAny<Student>()),
                Times.Once);

            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.userServiceMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
            this.studentServiceMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnAddIfServiceErrorOccurredAndLogItAsync()
        {
            // given
            StudentView someStudentView = CreateRandomStudentView();
            var serviceException = new Exception();

            var expectedStudentViewServiceException =
                new StudentViewServiceException(serviceException);

            this.userServiceMock.Setup(service =>
                service.GetCurrentlyLoggedInUser())
                    .Throws(serviceException);

            // when
            ValueTask<StudentView> addStudentViewTask =
                this.studentViewService.AddStudentViewAsync(someStudentView);

            // then
            await Assert.ThrowsAsync<StudentViewServiceException>(() =>
                addStudentViewTask.AsTask());

            this.userServiceMock.Verify(service =>
                service.GetCurrentlyLoggedInUser(),
                Times.Once);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(
                    expectedStudentViewServiceException))),
                    Times.Once);

            this.dateTimeBrokerMock.Verify(broker =>
                broker.GetCurrentDateTime(),
                Times.Never);

            this.studentServiceMock.Verify(service =>
                service.RegisterStudentAsync(It.IsAny<Student>()),
                Times.Never);

            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.userServiceMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
            this.studentServiceMock.VerifyNoOtherCalls();
        }
    }
}