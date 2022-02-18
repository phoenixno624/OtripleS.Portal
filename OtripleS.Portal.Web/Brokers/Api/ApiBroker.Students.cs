using OtripleS.Portal.Web.Models.Students;

namespace OtripleS.Portal.Web.Brokers.Api
{
    public partial class ApiBroker
    {
        const string RelativeUrl = "api/students";

        public async ValueTask<Student> PostStudentAsync(Student student) =>
            await PostAsync(RelativeUrl, student);
    }
}