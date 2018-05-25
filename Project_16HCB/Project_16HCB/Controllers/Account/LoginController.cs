using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Project_16HCB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Web;
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
            HttpResponseMessage resmsg;

            if (info == null)
            {
                resmsg = Request.CreateResponse(HttpStatusCode.BadRequest, "Chưa nhập thông tin đăng nhập!");
            }
            else
            {
                var obj = JObject.Parse(info.ToString());
                var username = obj["username"].ToObject<string>();
                var password = obj["password"].ToObject<string>();

                using (var db = new Project_16HCB_CSDLEntities())
                {
                    var account = db.ACCOUNTs
                            .Where(n => n.C_username == username && n.C_password == password)
                            .FirstOrDefault();

                    if (account != null)
                    {
                        var user = db.USERS.Where(u => u.C_userId == account.C_userId).FirstOrDefault();
                        resmsg = Request.CreateResponse(HttpStatusCode.OK, user);
                    }
                    else
                    {
                        resmsg = Request.CreateResponse(HttpStatusCode.NotFound, "Thông tin đăng nhập không chính xác!");
                    }
                }
            }

            return resmsg;
        }
    }
}
