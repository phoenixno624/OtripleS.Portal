using OtripleS.Portal.Web.Brokers.DateTimes;
using OtripleS.Portal.Web.Brokers.Logging;
using OtripleS.Portal.Web.Models.StudentViews;
using OtripleS.Portal.Web.Services.Students;
using OtripleS.Portal.Web.Services.Users;

namespace OtripleS.Portal.Web.Services.StudentViews
{
    public class StudentViewService : IStudentViewService
    {
        readonly IStudentService studentService;
        readonly IUserService userService;
        readonly IDateTimeBroker dateTimeBroker;
        readonly ILoggingBroker loggingBroker;

        public StudentViewService(
            IStudentService studentService,
            IUserService userService,
            IDateTimeBroker dateTimeBroker,
            ILoggingBroker loggingBroker)
        {
            this.studentService = studentService ?? throw new ArgumentNullException(nameof(studentService));
            this.userService = userService ?? throw new ArgumentNullException(nameof(userService));
            this.dateTimeBroker = dateTimeBroker ?? throw new ArgumentNullException(nameof(dateTimeBroker));
            this.loggingBroker = loggingBroker ?? throw new ArgumentNullException(nameof(loggingBroker));
        }

        public ValueTask<StudentView> AddStudentViewAsync(StudentView studentView)
        {
            throw new NotImplementedException();
        }
    }
}