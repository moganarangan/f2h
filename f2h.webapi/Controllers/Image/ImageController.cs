﻿using System;
using F2H.Interfaces.Image;
using F2H.Models.Image;
using Microsoft.AspNetCore.Http;
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
        public ActionResult<ImageResponseModel> GetImageByTableAndId(string tableName, string ImageId)
        {
            return _imageService.GetImageByTableAndId(tableName, new Guid(ImageId));
        }

        // Save Image
        // POST: api/Image
        [HttpPost("{tableName}")]
        public ActionResult<string> SaveImage(string tableName, IFormFile file)
        {
            var saveFile = file;
            var t = tableName;

            return Ok("success");
        }
    }
}