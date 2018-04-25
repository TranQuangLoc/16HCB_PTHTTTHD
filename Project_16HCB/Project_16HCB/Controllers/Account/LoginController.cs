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
        // info { username: loc, password: sjdfsjdhfjshg }
        [HttpPost]
        public HttpResponseMessage login([FromBody]object info)
        {
            var obj = JObject.Parse(info.ToString());
            var username = obj["username"].ToObject<string>();
            var password = obj["password"].ToObject<string>();

            //Response.AppendHeader("Access-Control-Allow-Origin", "*");

            using (var db = new Project_16HCB_CSDLEntities_SanLe())
            {
                var account = db.ACCOUNTs.Where(n => n.C_username == username
                        && n.C_password == password).FirstOrDefault();
                HttpResponseMessage resmsg;

                if (account != null)
                {
                    resmsg = Request.CreateResponse(HttpStatusCode.OK, JsonConvert.SerializeObject(account));
                }
                else
                {
                    resmsg = Request.CreateResponse(HttpStatusCode.NoContent);
                }

                return resmsg;
                //return Json(account);
            }
        }
    }
}
