using Newtonsoft.Json;
using Project_16HCB.Models;
using Project_16HCB_View.Models;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Project_16HCB.Controllers
{
    public class KhoaController : ApiController
    {
        /* Xem danh sách tất cả môn học */
        [HttpGet]
        [Route("api/khoa")]
        public HttpResponseMessage XemDanhSachKhoa()
        {
            HttpResponseMessage res = null;

            using (var db = new Project_16HCB_CSDLEntities())
            {
                var result = db.Database.SqlQuery<Khoa>("exec sp_getKhoa").ToList();

                res = Request.CreateResponse(HttpStatusCode.OK, JsonConvert.SerializeObject(result));
            }

            return res;
        }
    }
}
