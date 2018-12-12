using F2H.Core.HomeBanner;
using F2H.Core.Image;
using F2H.Core.User;
using F2H.DataAccess;
using F2H.DataAccess.Interfaces;
using F2H.Interfaces.HomeBanner;
using F2H.Interfaces.Image;
using F2H.Interfaces.User;
using Microsoft.Extensions.DependencyInjection;

namespace F2H.WebApi.Configuration
{
    public static class ServiceExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<IMySqlDataAccess, MySqlDataAccess>();

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IImageService, ImageService>();
            services.AddTransient<IHomeBannerService, HomeBannerService>();

            // Add all other services here.

            return services;
        }
    }
}
