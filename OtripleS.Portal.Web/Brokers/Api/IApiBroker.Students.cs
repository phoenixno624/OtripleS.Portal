using OtripleS.Portal.Web.Models.Students;

namespace OtripleS.Portal.Web.Brokers.Api
{
    public partial interface IApiBroker
    {
        ValueTask<Student> PostStudentAsync(Student student);
    }
}