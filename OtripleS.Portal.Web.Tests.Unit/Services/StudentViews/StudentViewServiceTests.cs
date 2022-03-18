﻿using KellermanSoftware.CompareNetObjects;
using Moq;
using OtripleS.Portal.Web.Brokers.DateTimes;
using OtripleS.Portal.Web.Brokers.Logging;
using OtripleS.Portal.Web.Models.Students;
using OtripleS.Portal.Web.Models.StudentViews;
using OtripleS.Portal.Web.Services.Students;
using OtripleS.Portal.Web.Services.StudentViews;
using OtripleS.Portal.Web.Services.Users;
using System;
using System.Linq.Expressions;
using Tynamix.ObjectFiller;

namespace OtripleS.Portal.Web.Tests.Unit.Services.StudentViews
{
    public partial class StudentViewServiceTests
    {
        readonly Mock<IStudentService> studentServiceMock;
        readonly Mock<IUserService> userServiceMock;
        readonly Mock<IDateTimeBroker> dateTimeBrokerMock;
        readonly Mock<ILoggingBroker> loggingBrokerMock;
        readonly ICompareLogic compareLogic;
        readonly IStudentViewService studentViewService;

        public StudentViewServiceTests()
        {
            this.studentServiceMock = new Mock<IStudentService>();
            this.userServiceMock = new Mock<IUserService>();
            this.dateTimeBrokerMock = new Mock<IDateTimeBroker>();
            this.loggingBrokerMock = new Mock<ILoggingBroker>();

            var compareConfig = new ComparisonConfig();

            compareConfig.IgnoreProperty<Student>(student => student.Id);
            compareConfig.IgnoreProperty<Student>(student => student.UserId);

            this.compareLogic = new CompareLogic(compareConfig);

            this.studentViewService = new StudentViewService(
                studentService: this.studentServiceMock.Object,
                userService: this.userServiceMock.Object,
                dateTimeBroker: this.dateTimeBrokerMock.Object,
                loggingBroker: this.loggingBrokerMock.Object);
        }

        static dynamic CreateRandomStudentViewProperties(
            DateTimeOffset auditDates,
            Guid auditIds)
        {
            StudentGender randomStudentGender = GetRandomGender();

            return new
            {
                Id = Guid.NewGuid(),
                UserId = Guid.NewGuid().ToString(),
                IdentityNumber = GetRandomString(),
                FirstName = GetRandomName(),
                MiddleName = GetRandomName(),
                LastName = GetRandomName(),
                BirthDate = GetRandomDate(),
                Gender = randomStudentGender,
                GenderView = (StudentViewGender)randomStudentGender,
                CreatedDate = auditDates,
                UpdatedDate = auditDates,
                CreatedBy = auditIds,
                UpdatedBy = auditIds
            };
        }

        Expression<Func<Student, bool>> SameStudentAs(Student expectedStudent)
        {
            return actualStudent => this.compareLogic.Compare(expectedStudent, actualStudent)
                .AreEqual;
        }
        static DateTimeOffset GetRandomDate() =>
            new DateTimeRange(earliestDate: new DateTime()).GetValue();
        static StudentView CreateRandomStudentView() =>
            CreateStudentViewFiller().Create();
        static Expression<Func<Exception, bool>> SameExceptionAs(Exception expectedException)
        {
            return actualException => actualException.Message == expectedException.Message
                && actualException.InnerException.Message == expectedException.InnerException.Message;
        }
        static string GetRandomName() =>
            new RealNames(NameStyle.FirstName).GetValue();
        static string GetRandomString() =>
            new MnemonicString().GetValue();
        static StudentGender GetRandomGender()
        {
            int studentGenderCount =
                Enum.GetValues(typeof(StudentGender)).Length;

            int randomStudentGenderValue = new IntRange(min: 0, max: studentGenderCount).GetValue();

            return (StudentGender)randomStudentGenderValue;
        }
        static Filler<StudentView> CreateStudentViewFiller()
        {
            var filler = new Filler<StudentView>();

            filler.Setup()
                .OnType<DateTimeOffset>()
                .Use(DateTimeOffset.UtcNow);

            return filler;
        }
    }
}