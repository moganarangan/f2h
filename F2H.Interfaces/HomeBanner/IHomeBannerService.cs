using System.Collections.Generic;
using F2H.Models.HomeBanner;

namespace F2H.Interfaces.HomeBanner
{
    public interface IHomeBannerService
    {
        List<HomeBannerResponseModel> GetHomeBanners();
    }
}
