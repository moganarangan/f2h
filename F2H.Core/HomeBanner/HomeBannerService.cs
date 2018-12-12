using System;
using System.Collections.Generic;
using System.Data;
using F2H.DataAccess.Interfaces;
using F2H.Interfaces.HomeBanner;
using F2H.Models.HomeBanner;

namespace F2H.Core.HomeBanner
{
    public class HomeBannerService : IHomeBannerService
    {
        private readonly IMySqlDataAccess _mySqlDataAccess;

        public HomeBannerService(IMySqlDataAccess mySqlDataAccess)
        {
            _mySqlDataAccess = mySqlDataAccess;
        }

        public List<HomeBannerResponseModel> GetHomeBanners()
        {
            var response = new List<HomeBannerResponseModel>();

            var query = "SELECT HOME_BANNER_ID, CAPTION FROM F2H.HOME_BANNER WHERE ACTIVE = 1 ORDER BY POSITION LIMIT 3";
            var queryParams = new Dictionary<string, object>();

            var result = _mySqlDataAccess.GetData(query, queryParams);

            if (result.Rows.Count > 0)
            {
                foreach (DataRow row in result.Rows)
                {
                    var item = new HomeBannerResponseModel
                    {
                        BannerId = new Guid(row.Field<string>(0)),
                        Caption = row.Field<string>(1)
                    };

                    response.Add(item);
                }
            }

            return response;
        }
    }
}
