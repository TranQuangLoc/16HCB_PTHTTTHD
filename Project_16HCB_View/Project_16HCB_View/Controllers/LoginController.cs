using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
using System.Web.Script.Serialization;

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

            string url = "http://localhost:52740/api/Login";
            
            if (password != null && password != "")
                password = Md5Hash(password);

            var res = hc.PostAsJsonAsync(url, new { username, password }).Result;

            if (res.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jobj = JObject.Parse(res.Content.ReadAsAsync<string>().Result);
                USER user = jobj["user"].ToObject<USER>();
                int sores = jobj["resPhieuDiem"].ToObject<int>();
                int soresSV = jobj["resTraPhieuDiemSV"].ToObject<int>();
                
                TempData["login"] = user;

                if (user != null)
                {
                    Session.Add("userid", user.C_userId);
                    Session.Add("loaiUS", user.C_loaiUS);                 
                    Session.Add("user", user);
                    Session.Add("resPhieuDiem", sores);
                    Session.Add("resTraPhieuDiemSV", soresSV);
                    return RedirectToAction("TrangChu", "TrangChu");
                }
            }
            else
            {
                var jObj = JObject.Parse(res.Content.ReadAsAsync<string>().Result);
                ViewBag.error = jObj["msg"].ToObject<string>();
            }

            return View();
        }

        // Mã hóa mật khẩu
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
    }
}

