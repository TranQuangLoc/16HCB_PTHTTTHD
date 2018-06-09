using BUS.Interface;
using BUS.Service;
using DTO;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Project_16HCB.Controllers
{
    public class MonHocController : ApiController
    {
        /* Xem danh sách tất cả môn học */
        [HttpGet]
        public HttpResponseMessage XemDanhSachMonHoc()
        {
            HttpResponseMessage respMsg;
            string errorMsg = "";

            IMonHocService ims = new MonHocService();
            var lst = ims.LayDanhSachMonHoc(ref errorMsg);

            if (errorMsg != "")
            {
                respMsg = Request.CreateResponse(HttpStatusCode.InternalServerError,
                    JsonConvert.SerializeObject(new { msg = errorMsg, lst }));
            }
            else
            {
                respMsg = Request.CreateResponse(HttpStatusCode.OK,
                    JsonConvert.SerializeObject(new { lst }));
            }

            return respMsg;
        }
    }
}
