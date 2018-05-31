using Newtonsoft.Json.Linq;
using Project_16HCB_View.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Project_16HCB_View.Utilities;

namespace Project_16HCB_View.Controllers
{
    [RoutePrefix("PhieuDiem")]
    public class PhieuDiemController : Controller
    {
        // GET: PhieuDiem
        public ActionResult TaoPhieuDiem()
        {
            if ((int)Session["userid"] == 0)
            {
               return RedirectToAction("Login", "Login");
                
            }
           
                return View();
            
           
        }

        //GiaoVien
        public ActionResult DanhSachPhieuDiem()
        {
            if ((int)Session["userid"] == 0)
            {
                return RedirectToAction("Login", "Login");

            }
            var hc = new HttpClient();
            hc.DefaultRequestHeaders.Accept.Clear();
            hc.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            string url = "http://localhost:8080/Project_16HCB_API/rest/phieudiem/danhsachphieudiem";
            var res = hc.GetAsync(url).Result;
            
            if (res.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var result = res.Content.ReadAsAsync<ListObjectPhieuDiem>().Result;
               
                if (result != null)
                {
                    return View(result);
                }
            }
            else
            {
                return RedirectToAction("TrangChu", "TrangChu");
            }
            return View();


        }

        //GiaoVien
        public ActionResult TraPhieuDiem()
        {
            
            int masv = Int32.Parse(Request.QueryString["masv"]);
            int hocki = Int32.Parse(Request.QueryString["hocki"]);
            int magv = Int32.Parse(Request.QueryString["magv"]);

            if ((int)Session["userid"] == 0)
            {
                return RedirectToAction("Login", "Login");

            }
            var hc = new HttpClient();
            hc.DefaultRequestHeaders.Accept.Clear();
            hc.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            string url = "http://localhost:8080/Project_16HCB_API/rest/phieudiem/traphieudiem";
            //var resquestParam = new JavaScriptSerializer().Serialize(new { masv, hocki, magv });
            var res = hc.PostAsJsonAsync(url,new { masv,hocki,magv}).Result;
           // var res = hc.PostAsJsonAsync(url, resquestParam).Result;
            if (res.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var result = res.Content.ReadAsAsync<KETQUA>().Result;
                if (result.ketqua == 1)
                {
                    return RedirectToAction("DanhSachPhieuDiem", "PhieuDiem",new { ketqua= result.ketqua });
                }
                
            }
            
            return View();


        }


        //Sinh vien
        public ActionResult NhanPhieuDiem()
        {

            int masv = SessionProvider.GetUserFromSession().C_userId;
            
            if ((int)Session["userid"] == 0)
            {
                return RedirectToAction("Login", "Login");

            }
            var hc = new HttpClient();
            hc.DefaultRequestHeaders.Accept.Clear();
            hc.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            string url = "http://localhost:8080/Project_16HCB_API/rest/phieudiem/nhanphieudiem";
            //var resquestParam = new JavaScriptSerializer().Serialize(new { masv, hocki, magv });
            var res = hc.PostAsJsonAsync(url, new { masv}).Result;
            // var res = hc.PostAsJsonAsync(url, resquestParam).Result;
            if (res.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var result = res.Content.ReadAsAsync<ListPhieuDiemSinhVien>().Result;
                if (result != null)
                {
                    return View(result);
                }

            }

            return View();


        }
    }
}