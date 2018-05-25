using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Project_16HCB.Models;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Web.Http;

namespace Project_16HCB.Controllers.Account
{
    public class LoginController : ApiController
    {
        private string Md5Hash(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(Encoding.ASCII.GetBytes(text));
            byte[] md5Bytes = md5.Hash;
            StringBuilder sb = new StringBuilder();

            foreach (byte b in md5Bytes)
            {
                sb.Append(b.ToString("x2"));
            }

            return sb.ToString();
        }

        // info { username:string, password:string }
        [HttpPost]
        public HttpResponseMessage Login([FromBody]object info)
        {
            HttpResponseMessage respMsg;
            var obj = JObject.Parse(info.ToString());
            var username = obj["username"].ToObject<string>();
            var password = obj["password"].ToObject<string>();

            if (info == null || username == "" || password == "")
            {
                respMsg = Request.CreateResponse(HttpStatusCode.BadRequest,
                    JsonConvert.SerializeObject(new { msg = "Chưa nhập thông tin đăng nhập" }));
            }
            else
            {
                using (var db = new Project_16HCB_CSDLEntities())
                {
                    SqlParameter pReturnVal = new SqlParameter("@returnVal", System.Data.SqlDbType.Int)
                    {
                        Direction = System.Data.ParameterDirection.Output
                    };
                    SqlParameter pUsername = new SqlParameter("@username", System.Data.SqlDbType.NVarChar, 50)
                    {
                        Value = username
                    };
                    SqlParameter pPassword = new SqlParameter("@password", System.Data.SqlDbType.NVarChar, 50)
                    {
                        Value = password
                    };
                    SqlParameter pErrorMsg = new SqlParameter("@errorMsg", System.Data.SqlDbType.NVarChar, 4000)
                    {
                        Direction = System.Data.ParameterDirection.Output
                    };

                    string sql = "EXEC @returnVal = usp_login @username, @password, @errorMsg OUT";
                    USER user;

                    try
                    {
                        user = db.Database.SqlQuery<USER>(sql, pReturnVal, pUsername, pPassword, pErrorMsg)
                            .FirstOrDefault();
                        respMsg = Request.CreateResponse(HttpStatusCode.OK,
                            JsonConvert.SerializeObject(new { user }));
                    }
                    catch (Exception)
                    {
                        if (pReturnVal.Value == null) // Internal sql server error
                            respMsg = Request.CreateResponse(HttpStatusCode.InternalServerError,
                                JsonConvert.SerializeObject(new { msg = "SQL Server: " 
                                    + pErrorMsg.Value.ToString() }));
                        else
                            respMsg = Request.CreateResponse(HttpStatusCode.BadRequest,
                                JsonConvert.SerializeObject(new { msg = GetErrorMsg((int)pReturnVal.Value) }));
                    }
                }
            }

            return respMsg;
        }

        private string GetErrorMsg(int errCode)
        {
            switch (errCode)
            {
                case 1:
                    return "Tài khoản đã bị khóa";
                case 2:
                    return "Thông tin đăng nhập không chính xác";
                default:
                    return "";
            }
        }
    }
}
