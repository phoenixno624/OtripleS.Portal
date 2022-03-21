using OtripleS.Portal.Web.Brokers.DateTimes;
using OtripleS.Portal.Web.Brokers.Logging;
using OtripleS.Portal.Web.Models.Students;
using OtripleS.Portal.Web.Models.StudentViews;
using OtripleS.Portal.Web.Services.Students;
using OtripleS.Portal.Web.Services.Users;

namespace OtripleS.Portal.Web.Services.StudentViews
{
    public partial class StudentViewService : IStudentViewService
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

        public ValueTask<StudentView> AddStudentViewAsync(StudentView studentView) =>
            TryCatch(async () =>
            {
                ValidateStudentView(studentView);

                Student student = MapToStudent(studentView);
                await this.studentService.RegisterStudentAsync(student);

                return studentView;
            });

        Student MapToStudent(StudentView studentView)
        {
            Guid currentLoggedInUserId = this.userService.GetCurrentlyLoggedInUser();
            DateTimeOffset currentDateTime = this.dateTimeBroker.GetCurrentDateTime();

            return new Student
            {
                Id = Guid.NewGuid(),
                UserId = Guid.NewGuid().ToString(),
                IdentityNumber = studentView.IdentityNumber,
                FirstName = studentView.FirstName,
                MiddleName = studentView.MiddleName,
                LastName = studentView.LastName,
                Gender = (StudentGender)studentView.Gender,
                BirthDate = studentView.BirthDate,
                CreatedBy = currentLoggedInUserId,
                UpdatedBy = currentLoggedInUserId,
                CreatedDate = currentDateTime,
                UpdatedDate = currentDateTime
            };
        }
    }
}