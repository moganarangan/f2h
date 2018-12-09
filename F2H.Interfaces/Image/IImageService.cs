using F2H.Models.Image;
using System;

namespace F2H.Interfaces.Image
{
    public interface IImageService
    {
        ImageResponseModel GetImageByTableAndId(string tableName, Guid imageId);
    }
}
