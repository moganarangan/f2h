using System;
using System.IO;
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
        public async Task<FileStreamResult> Get(string imageId)
        {
            var imageByte = await _imageService.GetHomeBannerImage(new Guid(imageId));
            var ms = new MemoryStream(imageByte);
            var contentType = "image/jpeg";
            var response = new FileStreamResult(ms, contentType);

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