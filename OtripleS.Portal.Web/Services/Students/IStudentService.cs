using OtripleS.Portal.Web.Models.Students;

namespace OtripleS.Portal.Web.Services.Students
{
    public interface IStudentService
    {
        ValueTask<Student> RegisterStudentAsync(Student student);
    }
}