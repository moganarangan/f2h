using F2H.MySqlConnector;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace f2h.webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        // Get Image by Image Id and Table
        [HttpGet("{tableName}/{id}")]
        public async Task<ActionResult<string>> GetAsync()
        {
            using (var db = new AppDb())
            {
                await db.Connection.OpenAsync();

                var cmd = db.Connection.CreateCommand();
                cmd.CommandText = @"SELECT * FROM HOME_BANNER;";
                var result = cmd.ExecuteReaderAsync().Result;
                var name = string.Empty;

                while (await result.ReadAsync())
                {
                    name = await result.GetFieldValueAsync<string>(1);
                }

                return new OkObjectResult(name);
            }
        }

        // Save Image
    }
}