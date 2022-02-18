using FluentAssertions;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace OtripleS.Portal.Web.Tests.Unit.Services.Students
{
    public partial class StudentServiceTests
    {
        [Fact]
        public async Task ShouldRegisterStudentAsync()
        {
            // given
            var randomStudent = CreateRandomStudent();
            var inputStudent = randomStudent;
            var retrievedStudent = inputStudent;
            var expectedStudent = retrievedStudent;

            this.apiBrokerMock.Setup(broker =>
                broker.PostStudentAsync(inputStudent))
                    .ReturnsAsync(retrievedStudent);

            // when
            var actualStudent = await this.studentService.RegisterStudentAsync(inputStudent);

            // then
            actualStudent.Should()
                .BeEquivalentTo(expectedStudent);

            this.apiBrokerMock.Verify(broker =>
                broker.PostStudentAsync(inputStudent),
                    Times.Once);

            this.apiBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}