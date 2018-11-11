using fc.webapi.Models;

namespace fc.webapi.Interfaces
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
    }
}
