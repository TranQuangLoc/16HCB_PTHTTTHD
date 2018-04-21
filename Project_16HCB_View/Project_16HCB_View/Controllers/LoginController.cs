using Project_16HCB_View.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace Project_16HCB_View.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
           /* var hc = new HttpClient();
            hc.DefaultRequestHeaders.Accept.Clear();
            hc.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            string url = "http://localhost:1352/api/TaiKhoan/XemTaiKhoan/" + DataUserLogin.MaTaiKhoan;
            var res = hc.GetAsync(url).Result;

            if (res.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var obj = res.Content.ReadAsAsync<TaiKhoan>().Result;

                MessageBox.Show("Tài khoản: " + obj.MATK + "\nHọ tên: " + obj.HOTEN + "\nSố dư: " + String.Format("{0:N0}", obj.SODUKHADUNG) + " VNĐ\nNgày hết hạn: " + obj.NGAYHETHAN.ToString("dd-MM-yyyy"));
            }*/
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Login(string username, string password)
        {
            var hc = new HttpClient();
            hc.DefaultRequestHeaders.Accept.Clear();
            hc.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            string url = "http://localhost:52740/Login/Login";
            var res = hc.PostAsJsonAsync(url, new
            {
                username,
                password
            }).Result;

            if (res.StatusCode == System.Net.HttpStatusCode.OK)
            {
                // var result = res.Content.ReadAsAsync<List<ACCOUNT>>().Result;
                var result = res.Content.ReadAsAsync<ACCOUNT>().Result;
                //var a = result[0].id;

                //return View("~/Views/Home/Index",result);
                TempData["login"] = result;
                
                if (result != null)
                {
                    return RedirectToAction("Index", "Home");
                }

            }
            else
            {

            }
            return View();
        }
    }
}

