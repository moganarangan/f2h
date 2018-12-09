using F2H.Core.Image;
using F2H.Core.User;
using F2H.Interfaces.Image;
using F2H.Interfaces.User;
using Microsoft.Extensions.DependencyInjection;

namespace F2H.WebApi.Configuration
{
    public static class ServiceExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IImageService, ImageService>();
            // Add all other services here.

            return services;
        }
    }
}
