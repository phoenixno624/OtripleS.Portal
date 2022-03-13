namespace OtripleS.Portal.Web.Models.Students.Exceptions
{
    public class InvalidStudentException : Exception
    {
        public InvalidStudentException(string parameterName, object parameterValue)
            : base("Invalid Student error occurred, " +
                  $"parameter name: {parameterName}," +
                  $"parameter value: {parameterValue}")
        {

        }
    }
}