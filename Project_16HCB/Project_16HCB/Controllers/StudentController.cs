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
        [Route("Student/kiemtraSVTonTai")]
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
                resmsg = Request.CreateResponse(HttpStatusCode.OK, JsonConvert.SerializeObject(new { confirm = result }));

            }

            return resmsg;
        }

        [Route("Student/GetDanhSachHP")]
        [HttpPost]
        public HttpResponseMessage GetDanhSachHP([FromBody]object info)
        {
            HttpResponseMessage resmsg;

            if (info == null)
            {
                resmsg = Request.CreateResponse(HttpStatusCode.BadRequest, JsonConvert.SerializeObject(
                        new { error = 0 }));
            }
            else
            { 
                try
                {
                    var obj = JObject.Parse(info.ToString());
                    var mssv = obj["mssv"].ToObject<int>();

                    IInfoDiemDanhService idds = new InfoDiemDanhService();

                    var result = idds.GetDanhSachHP(mssv);
                    resmsg = Request.CreateResponse(HttpStatusCode.OK, result);
                } catch(Exception ex)
                {
                    resmsg = Request.CreateResponse(HttpStatusCode.InternalServerError);
                }
                

            }

            return resmsg;
        }


        [Route("Student/GetInfoDiemDanh")]
        [HttpPost]
        public HttpResponseMessage GetInfoDiemDanh([FromBody]object info)
        {
            HttpResponseMessage resmsg;

            if (info == null)
            {
                resmsg = Request.CreateResponse(HttpStatusCode.BadRequest, JsonConvert.SerializeObject(
                        new { error = 0 }));
            }
            else
            {
                try
                {
                    var jsonSettings = new JsonSerializerSettings();
                    jsonSettings.DateFormatString = "dd/MM/yyy hh:mm:ss";
                    var obj = JObject.Parse(info.ToString());
                    var mssv = obj["mssv"].ToObject<int>();
                    var matkb = obj["matkb"].ToObject<int>();

                    IInfoDiemDanhService idds = new InfoDiemDanhService();

                    var result = idds.GetInfoDiemDanh(mssv, matkb);

                    resmsg = Request.CreateResponse(HttpStatusCode.OK, JsonConvert.SerializeObject(result, jsonSettings));
                } catch(Exception ex)
                {
                    resmsg = Request.CreateResponse(HttpStatusCode.InternalServerError);
                }
               

            }

            return resmsg;
        }
    }
}
