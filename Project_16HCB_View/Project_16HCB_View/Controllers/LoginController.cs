using Project_16HCB_View.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
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

        // username: loc, password: qwertyui
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Login(string username, string password)
        {
            var hc = new HttpClient();
            hc.DefaultRequestHeaders.Accept.Clear();
            hc.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            string url = "http://localhost:52740/api/Login";
            StringBuilder sb = new StringBuilder();

            MD5 md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(Encoding.ASCII.GetBytes(password));
            byte[] md5Bytes = md5.Hash;

            foreach (byte b in md5Bytes)
            {
                sb.Append(b.ToString("x2"));
            }

            password = sb.ToString();

            var res = hc.PostAsJsonAsync(url, new
            {
                username,
                password
            }).Result;

            if (res.StatusCode == System.Net.HttpStatusCode.OK)
            {
                // ACCOUNT
                var result = res.Content.ReadAsAsync<ACCOUNT>().Result;

                //return View("~/Views/Home/Index",result);
                //TempData["login"] = result;
                
                if (result != null)
                {
                    Session.Add("userid", result._userId);
                    return RedirectToAction("Index", "Home");
                }

            }
            else
            {
                ViewBag.error = res.StatusCode; //res.Content.ReadAsAsync<string>().Result;
            }

            return View();
        }
    }
}

