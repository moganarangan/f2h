using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using F2H.DataAccess.Interfaces;
using F2H.Interfaces.Image;
using F2H.Models.Image;

namespace F2H.Core.Image
{
    public class ImageService : IImageService
    {
        private readonly IMySqlDataAccess _mySqlDataAccess;

        public ImageService(IMySqlDataAccess mySqlDataAccess)
        {
            _mySqlDataAccess = mySqlDataAccess;
        }

        public ImageResponseModel GetImageByTableAndId(string tableName, Guid imageId)
        {
            var response = new ImageResponseModel { };

            var sql = "SELECT * FROM HOME_BANNER";
            var sqlParams = new Dictionary<string, object>();

            var result = _mySqlDataAccess.GetData(sql, sqlParams);

            if (result.Rows.Count > 0)
            {
                response.Caption = result.AsEnumerable().FirstOrDefault().Field<string>(1);

                var image = result.AsEnumerable().FirstOrDefault().Field<byte?>(2);
                response.Image = image;
            }

            return response;
        }
    }
}
