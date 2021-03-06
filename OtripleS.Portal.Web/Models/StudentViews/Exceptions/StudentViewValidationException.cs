namespace OtripleS.Portal.Web.Models.StudentViews.Exceptions
{
    public class StudentViewValidationException : Exception
    {
        public StudentViewValidationException(Exception innerException)
            : base($"Student View validation error occurred, try again.", innerException)
        {
        }
    }
}