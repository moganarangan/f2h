using F2H.Interfaces.User;
using Microsoft.AspNetCore.Http;

namespace F2H.Core.User
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetCurrentUser()
        {
            var username = _httpContextAccessor.HttpContext.User.Identity.Name;

            return username;
        }
    }
}
