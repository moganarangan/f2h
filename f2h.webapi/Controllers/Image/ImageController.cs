using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using F2H.Interfaces.Image;
using F2H.Models.Image;
using Microsoft.AspNetCore.Mvc;

namespace f2h.webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImageService _imageService;

        public ImageController(IImageService imageService)
        {
            _imageService = imageService;
        }

        // Get Image by Image Id and Table
        [HttpGet("{tableName}/{imageId}")]
        public ActionResult<ImageResponseModel> GetImageByTableAndId(string tableName, string imageId)
        {
            return _imageService.GetImageByTableAndId(tableName, new Guid(imageId));
        }

        // Get Image by Image Id and Table
        [HttpGet("homebanner/{imageId}")]
        public async Task<HttpResponseMessage> Get(string imageId)
        {
            var result = await _imageService.GetHomeBannerImage(new Guid(imageId));

            var response = new HttpResponseMessage
            {
                Content = new ByteArrayContent(result),
                StatusCode = HttpStatusCode.OK,
            };
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");

            return response;
        }

        // Save Image
        // POST: api/Image
        [HttpPost("{tableName}")]
        public async Task<string> SaveImage(string tableName, [FromBody]ImagePostModel imagePostModel)
        {
            var result = await _imageService.SaveImage(tableName, imagePostModel.Content, imagePostModel.ImageName, 1, true);

            return result;
        }
    }
}