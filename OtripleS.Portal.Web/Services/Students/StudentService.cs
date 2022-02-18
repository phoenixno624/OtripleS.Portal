using OtripleS.Portal.Web.Brokers.Api;
using OtripleS.Portal.Web.Brokers.Logging;
using OtripleS.Portal.Web.Models.Students;

namespace OtripleS.Portal.Web.Services.Students
{
    public class StudentService : IStudentService
    {
        readonly IApiBroker apiBroker;
        readonly ILoggingBroker loggingBroker;

        public StudentService(IApiBroker apiBroker, ILoggingBroker loggingBroker)
        {
            this.apiBroker = apiBroker ?? throw new ArgumentNullException(nameof(apiBroker));
            this.loggingBroker = loggingBroker ?? throw new ArgumentNullException(nameof(loggingBroker));
        }

        public async ValueTask<Student> RegisterStudentAsync(Student student) =>
             await this.apiBroker.PostStudentAsync(student);
    }
}