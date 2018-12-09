using F2H.DataAccess;
using F2H.Interfaces.Image;
using F2H.Models.Image;
using System;

namespace F2H.Core.Image
{
    public class ImageService : IImageService
    {
        public ImageResponseModel GetImageByTableAndId(string tableName, Guid imageId)
        {
            var response = new ImageResponseModel { };

            var sql = "SELECT * FROM HOME_BANNER";

            using (var db = new AppDb())
            {
                db.Connection.Open();

                var cmd = db.Connection.CreateCommand();
                cmd.CommandText = sql;
                var result = cmd.ExecuteReaderAsync().Result;
                var name = string.Empty;

                while (result.Read())
                {
                    response.Caption = result.GetFieldValue<string>(1);
                    // response.Image = result.GetFieldValue<byte>(2);
                }
            }

            return response;
        }
    }
}
