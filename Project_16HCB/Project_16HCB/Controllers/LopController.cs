using DTO;
using Newtonsoft.Json;
using Project_16HCB.Models;
using Project_16HCB_View.Models;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Project_16HCB.Controllers
{
    public class LopController : ApiController
    {
        /* Xem danh sách tất cả môn học */
        [HttpGet]
        [Route("api/lop")]
        public HttpResponseMessage XemDanhSachLop()
        {
            HttpResponseMessage res = null;

            using (var db = new Project_16HCB_CSDLEntities())
            {
                var result = db.Database.SqlQuery<LopHoc>("exec sp_getLopHoc").ToList();

                res = Request.CreateResponse(HttpStatusCode.OK, JsonConvert.SerializeObject(result));
            }

            return res;
        }
    }
}
