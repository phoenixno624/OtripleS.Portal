namespace OtripleS.Portal.Web.Models.StudentViews.Exceptions
{
    public class StudentViewDependencyValidationException : Exception
    {
        public StudentViewDependencyValidationException(Exception innerException)
            : base("Student view dependency error occurred, try again.", innerException)
        {

        }
    }
}