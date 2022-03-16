namespace OtripleS.Portal.Web.Services.Users
{
    public class UserService : IUserService
    {
        public Guid GetCurrentlyLoggedInUser() =>
            Guid.NewGuid();
    }
}