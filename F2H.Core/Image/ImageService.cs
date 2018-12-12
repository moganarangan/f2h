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

            var query = string.Format("SELECT CAPTION, IMAGE FROM {0} WHERE {0}_ID = '{1}'", tableName, imageId);
            var queryParams = new Dictionary<string, object>();

            var result = _mySqlDataAccess.GetData(query, queryParams);

            if (result.Rows.Count > 0)
            {
                response.Caption = result.AsEnumerable().FirstOrDefault().Field<string>(0);
                response.Image = result.AsEnumerable().FirstOrDefault().Field<byte[]>(1);
            }

            return response;
        }

        public string SaveImage(string tableName, byte[] image, string fileName, int position, bool active)
        {
            var newId = Guid.NewGuid();

            var query = string.Format("INSERT INTO {0}({0}_ID, CAPTION, IMAGE, POSITION, ACTIVE) VALUES (@{0}_ID, @CAPTION, @IMAGE, @POSITION, @ACTIVE)", tableName);
            var queryParams = new Dictionary<string, object>
            {
                { "HOME_BANNER_ID", newId.ToString() },
                { "CAPTION", fileName },
                { "IMAGE", image },
                { "POSITION", position },
                { "ACTIVE", active }
            };

            _mySqlDataAccess.ExecuteNonQuery(query, queryParams);

            return "Image saved.";
        }
    }
}
