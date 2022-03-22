namespace OtripleS.Portal.Web.Models.StudentViews.Exceptions
{
    public class StudentViewServiceException : Exception
    {
        public StudentViewServiceException(Exception innerException)
            : base("Student View service error occurred, contact support.", innerException)
        {

        }
    }
}