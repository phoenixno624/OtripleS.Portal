using Moq;
using OtripleS.Portal.Web.Brokers.Api;
using OtripleS.Portal.Web.Brokers.Logging;
using OtripleS.Portal.Web.Models.Students;
using OtripleS.Portal.Web.Services.Students;
using System;
using System.Linq.Expressions;
using Tynamix.ObjectFiller;

namespace OtripleS.Portal.Web.Tests.Unit.Services.Students
{
    public partial class StudentServiceTests
    {
        readonly Mock<IApiBroker> apiBrokerMock;
        readonly Mock<ILoggingBroker> loggingBrokerMock;
        readonly IStudentService studentService;

        public StudentServiceTests()
        {
            this.apiBrokerMock = new Mock<IApiBroker>();
            this.loggingBrokerMock = new Mock<ILoggingBroker>();

            this.studentService = new StudentService(
                this.apiBrokerMock.Object,
                this.loggingBrokerMock.Object);
        }

        static Student CreateRandomStudent() =>
            CreateStudentFiller().Create();

        static Expression<Func<Exception, bool>> SameExceptionAs(Exception expectedException)
        {
            return actualException => actualException.Message == expectedException.Message
                && actualException.InnerException.Message == expectedException.InnerException.Message;
        }

        static Filler<Student> CreateStudentFiller()
        {
            var filler = new Filler<Student>();

            filler.Setup()
                .OnType<DateTimeOffset>()
                .Use(DateTimeOffset.UtcNow);

            return filler;
        }
    }
}