using Newtonsoft.Json;
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
    public class MonHocController : ApiController
    {
        /* Xem danh sách tất cả môn học */
        [HttpGet]
        public HttpResponseMessage XemDanhSachMonHoc()
        {
            using (var db = new Project_16HCB_CSDLEntities())
            {
                HttpResponseMessage respMsg;
                SqlParameter resParam = new SqlParameter("@result", System.Data.SqlDbType.Int);
                resParam.Direction = System.Data.ParameterDirection.Output;
                SqlParameter errorMsg = new SqlParameter("@errorMsg", System.Data.SqlDbType.NVarChar, 4000);
                errorMsg.Direction = System.Data.ParameterDirection.Output;

                string sql = "exec @result = usp_layDanhSachMonHoc @errorMsg OUT";
                List<MONHOC> result;

                try
                {
                    result = db.Database.SqlQuery<MONHOC>(sql, resParam, errorMsg).ToList();

                    respMsg = Request.CreateResponse(HttpStatusCode.OK,
                        JsonConvert.SerializeObject(new { res = result }));
                }
                catch (Exception)
                {
                    respMsg = Request.CreateResponse(HttpStatusCode.InternalServerError,
                        JsonConvert.SerializeObject(new { msg = errorMsg.Value.ToString() }));
                }

                return respMsg;
            }
        }
        [HttpGet]
        [Route("api/GetMonHoc")]
        public List<MONHOC> getMonHoc()
        {
            var list = new List<MONHOC>();
            using (var db = new Project_16HCB_CSDLEntities())
            {
                list = db.MONHOCs.ToList();
            }
            return list;
        }
        /* Xem thông tin môn học theo id môn học */
        [HttpGet]
        [Route("api/MonHoc/{monHocId}")]
        public HttpResponseMessage XemThongTinMonHoc(int monHocId)
        {
            HttpResponseMessage respMsg;

            using (var db = new Project_16HCB_CSDLEntities())
            {
                SqlParameter param_returnValue = new SqlParameter("@returnValue", System.Data.SqlDbType.Int)
                {
                    Direction = System.Data.ParameterDirection.Output
                };
                SqlParameter param_id = new SqlParameter("@monHocId", System.Data.SqlDbType.Int)
                {
                    Direction = System.Data.ParameterDirection.Input,
                    Value = monHocId
                };
                SqlParameter param_errMsg = new SqlParameter("@errorMsg", System.Data.SqlDbType.NVarChar, 4000)
                {
                    Direction = System.Data.ParameterDirection.Output
                };

                string sql = "EXEC @returnValue = usp_layThongTinMonHocTheoId @monHocId, @errorMsg OUT";
                MONHOC monhoc;

                try
                {
                    monhoc = db.Database.SqlQuery<MONHOC>(sql, param_returnValue, param_id, param_errMsg)
                        .FirstOrDefault();
                    respMsg = Request.CreateResponse(HttpStatusCode.OK,
                        JsonConvert.SerializeObject(new { res = monhoc }));
                }
                catch (Exception)
                {
                    if (param_returnValue.Value == null) // Internal Sql server error
                        respMsg = Request.CreateResponse(HttpStatusCode.InternalServerError,
                            JsonConvert.SerializeObject(new { msg = "SQL Server: " 
                                + param_errMsg.Value.ToString() }));
                    else
                        respMsg = Request.CreateResponse(HttpStatusCode.BadRequest,
                            JsonConvert.SerializeObject(new { msg = "Môn học không tồn tại" }));
                }
            }

            return respMsg;
        }
    }
}
