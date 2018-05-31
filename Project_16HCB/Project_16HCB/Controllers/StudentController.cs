using BUS.Interface;
using BUS.Service;
using DTO;
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


        [Route("Student/convertUserId")]
        [HttpPost]
        public HttpResponseMessage convertUserId([FromBody]object info)
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
                var userid = obj["userid"].ToObject<int>();

                IInfoDiemDanhService idds = new InfoDiemDanhService();

                int result = idds.convertUserId(userid);
                resmsg = Request.CreateResponse(HttpStatusCode.OK, result);

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

        #region Quản lý sinh viên
        [Route("Student/themSV")]
        [HttpPost]
        public HttpResponseMessage themSinhVien([FromBody]object info)
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
                SinhVien objSinhVien = obj.ToObject<SinhVien>();

                SinhVienService objSVSer = new SinhVienService();
                bool result = objSVSer.ThemSinhVien(objSinhVien);
                if (result == true)
                {
                    resmsg = Request.CreateResponse(HttpStatusCode.OK, result);
                }
                else
                {
                    resmsg = Request.CreateResponse(HttpStatusCode.NotFound);
                }

            }

            return resmsg;
        }

        [Route("Student/capnhatSV")]
        [HttpPost]
        public HttpResponseMessage capnhatSinhVien([FromBody]object info)
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
                SinhVien objSinhVien = obj.ToObject<SinhVien>();

                SinhVienService objSVSer = new SinhVienService();
                bool result = objSVSer.CapNhatSinhVien(objSinhVien);
                if (result == true)
                {
                    resmsg = Request.CreateResponse(HttpStatusCode.OK, JsonConvert.SerializeObject(result));
                }
                else
                {
                    resmsg = Request.CreateResponse(HttpStatusCode.NotFound);
                }

            }

            return resmsg;
        }

        [Route("Student/xoaSV")]
        [HttpGet]
        public HttpResponseMessage xoaSV(int mssv)
        {
            HttpResponseMessage resmsg;

            SinhVienService objSVSer = new SinhVienService();
            bool result = objSVSer.XoaSinhVien(mssv);
            if (result == true)
            {
                resmsg = Request.CreateResponse(HttpStatusCode.OK, JsonConvert.SerializeObject(result));
            }
            else
            {
                resmsg = Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return resmsg;
        }

        [Route("Student/layThongTinSV")]
        [HttpGet]
        public HttpResponseMessage layThongTinSV(int mssv)
        {
            HttpResponseMessage resmsg;

            SinhVienService objSVSer = new SinhVienService();
            SinhVien objSinhVien = new SinhVien();
            bool result = objSVSer.LayThongTinSinhVien(mssv, ref objSinhVien);
            if (result == true)
            {
                resmsg = Request.CreateResponse(HttpStatusCode.OK, JsonConvert.SerializeObject(objSinhVien));
            }
            else
            {
                resmsg = Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return resmsg;
        }

        [Route("Student/timkiemSV")]
        [HttpPost]
        public HttpResponseMessage timkiemSinhVien([FromBody]object info)
        {
            HttpResponseMessage resmsg;

            if (info == null)
            {
                resmsg = Request.CreateResponse(HttpStatusCode.BadRequest, JsonConvert.SerializeObject(
                        new { error = 0 }));
            }
            else
            {
                SinhVien objSinhVien = new SinhVien();
                var obj = JObject.Parse(info.ToString());
                string strTuKhoa = obj["tukhoa"].ToObject<string>();
                objSinhVien._malop = obj["malop"].ToObject<int>();
                objSinhVien._makhoa = obj["makhoa"].ToObject<int>();
                objSinhVien._dalay = obj["dalay"].ToObject<int>();
                int intPageIndex = obj["chisotrang"].ToObject<int>();
                int intPageSize = obj["sodong"].ToObject<int>();

                List<SinhVien> lstSinhVien = new List<SinhVien>();
                SinhVienService objSVSer = new SinhVienService();
                bool result = objSVSer.TimKiemSinhVien(objSinhVien, ref lstSinhVien, strTuKhoa, intPageIndex, intPageSize);
                if (result == true)
                {
                    resmsg = Request.CreateResponse(HttpStatusCode.OK, JsonConvert.SerializeObject(lstSinhVien));
                }
                else
                {
                    resmsg = Request.CreateResponse(HttpStatusCode.NotFound);
                }

            }

            return resmsg;
        }
        #endregion
    }
}
