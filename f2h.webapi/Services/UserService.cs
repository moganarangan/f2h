using f2h.webapi.Interfaces;
using Microsoft.AspNetCore.Http;

namespace f2h.webapi.Services
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