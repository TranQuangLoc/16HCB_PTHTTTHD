using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Project_16HCB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Project_16HCB.Controllers.Account
{
    public class LoginController : ApiController
    {
        // info { username: loc, password: qwertyui }
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
                        resmsg = Request.CreateResponse(HttpStatusCode.OK, account);
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
