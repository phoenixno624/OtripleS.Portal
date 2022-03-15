namespace OtripleS.Portal.Web.Models.Students.Exceptions
{
    public class StudentDependencyValidationException : Exception
    {
        public StudentDependencyValidationException(Exception innerException)
            : base("Student dependency validation error occurred, try again.", innerException) { }
    }
}