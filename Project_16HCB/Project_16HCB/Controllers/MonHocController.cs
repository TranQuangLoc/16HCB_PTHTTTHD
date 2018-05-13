using Newtonsoft.Json;
using Project_16HCB.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Project_16HCB.Controllers
{
    public class MonHocController : ApiController
    {
        /* Xem danh sách tất cả môn học */
        [HttpGet]
        [Route("api/monhoc")]
        public HttpResponseMessage XemDanhSachMonHoc()
        {
            HttpResponseMessage res = null;

            using (var db = new Project_16HCB_CSDLEntities())
            {
                res = Request.CreateResponse(HttpStatusCode.OK, JsonConvert.SerializeObject(db.MONHOCs.ToList()));
            }

            return res;
        }

        /* Xem thông tin môn học theo id môn học */
        [HttpGet]
        [Route("api/monhoc/{monHocId}")]
        public HttpResponseMessage XemThongTinMonHoc(int monHocId)
        {
            HttpResponseMessage res = null;

            using (var db = new Project_16HCB_CSDLEntities())
            {
                MONHOC monHoc = db.MONHOCs.FirstOrDefault(m => m.C_id == monHocId);
                
                if (monHoc != null)
                {
                    res = Request.CreateResponse(HttpStatusCode.OK, JsonConvert.SerializeObject(monHoc));
                }
                else
                {
                    res = Request.CreateResponse(HttpStatusCode.NotFound, JsonConvert.SerializeObject(
                            new { error = "Mã môn học không tồn tại!" }));
                }
            }

            return res;
        }
    }
}
