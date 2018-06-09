using Newtonsoft.Json.Linq;
using Project_16HCB_View.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Mvc;
using System.Linq;

namespace Project_16HCB_View.Controllers
{
    public class MonHocController : Controller
    {
        // GET: MonHoc
        [HttpGet]
        public ActionResult Index()
        {
            var hc = new HttpClient();
            hc.DefaultRequestHeaders.Accept.Clear();
            hc.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            string url = "http://localhost:52740/api/MonHoc";
            var resp = hc.GetAsync(url).Result;
            var jObj = JObject.Parse(resp.Content.ReadAsAsync<string>().Result);

            if (resp.StatusCode != System.Net.HttpStatusCode.OK)
            {
                ViewBag.errorMsg = jObj["msg"].ToObject<string>();
            }
            else
            {
                var lstMonHoc = jObj["lst"].ToObject<List<MonHoc>>();
                ViewBag.lstMonHoc = lstMonHoc;
            }

            return View();
        }

        [HttpPost]
        public ActionResult Search(string tenMH)
        {
            var hc = new HttpClient();
            hc.DefaultRequestHeaders.Accept.Clear();
            hc.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            string url = "http://localhost:52740/api/MonHoc";
            var resp = hc.GetAsync(url).Result;
            var jObj = JObject.Parse(resp.Content.ReadAsAsync<string>().Result);

            if (resp.StatusCode != System.Net.HttpStatusCode.OK)
            {
                ViewBag.errorMsg = jObj["msg"].ToObject<string>();
            }
            else
            {
                var lstMonHoc = jObj["lst"].ToObject<List<MonHoc>>();
                ViewBag.lstMonHoc = lstMonHoc.Where(n => n.C_tenMH.ToLower().Contains(tenMH.ToLower())).ToList();
            }

            return View("Index");
        }
    }
}