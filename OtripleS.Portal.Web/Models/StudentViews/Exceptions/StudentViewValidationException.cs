namespace OtripleS.Portal.Web.Models.StudentViews.Exceptions
{
    public class StudentViewValidationException : Exception
    {
        public StudentViewValidationException(Exception innerException)
            : base($"Student vView validation error occurred, try again.", innerException)
        {
        }
    }
}