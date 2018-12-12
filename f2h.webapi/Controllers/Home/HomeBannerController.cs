using System.Collections.Generic;
using F2H.Interfaces.HomeBanner;
using F2H.Models.HomeBanner;
using Microsoft.AspNetCore.Mvc;

namespace f2h.webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeBannerController : ControllerBase
    {
        private readonly IHomeBannerService _homeBannerService;

        public HomeBannerController(IHomeBannerService homeBannerService)
        {
            _homeBannerService = homeBannerService;
        }

        // Get Home Banner Details
        // Get Image by Image Id and Table
        [HttpGet]
        public ActionResult<List<HomeBannerResponseModel>> Get()
        {
            return _homeBannerService.GetHomeBanners();
        }


        // Save Home Banner Details

    }
}