namespace OtripleS.Portal.Web.Models.StudentViews.Exceptions
{
    public class NullStudentViewException : Exception
    {
        public NullStudentViewException()
            : base("Null student error occurred.")
        {
        }
    }
}