using BUS.Interface;
using BUS.Service;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Project_16HCB.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Project_16HCB.Controllers
{
    public class StudentController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage kiemtraSVTonTai([FromBody]object info)
        {
            HttpResponseMessage resmsg;

            if (info == null)
            {
                resmsg = Request.CreateResponse(HttpStatusCode.BadRequest, JsonConvert.SerializeObject(
                        new { error = 0 }));
            }
            else
            {
                var obj = JObject.Parse(info.ToString());
                var mssv = obj["mssv"].ToObject<int>();

                IInfoDiemDanhService idds = new InfoDiemDanhService();

                bool result = idds.KiemTraSVTonTai(mssv);
                if (result == true)
                {
                    resmsg = Request.CreateResponse(HttpStatusCode.OK, JsonConvert.SerializeObject(new { confirm = result }));
                }
                else
                {
                    resmsg = Request.CreateResponse(HttpStatusCode.NotFound);
                }

            }

            return resmsg;
        }
    }
}
