using System;
using System.Threading.Tasks;
using F2H.Models.Image;

namespace F2H.Interfaces.Image
{
    public interface IImageService
    {
        ImageResponseModel GetImageByTableAndId(string tableName, Guid imageId);

        Task<string> SaveImage(string tableName, byte[] image, string fileName, int position, bool active);

        Task<byte[]> GetHomeBannerImage(Guid imageId);
    }
}
