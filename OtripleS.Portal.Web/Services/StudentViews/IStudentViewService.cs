using OtripleS.Portal.Web.Models.StudentViews;

namespace OtripleS.Portal.Web.Services.StudentViews
{
    public interface IStudentViewService
    {
        ValueTask<StudentView> AddStudentViewAsync(StudentView studentView);
    }
}