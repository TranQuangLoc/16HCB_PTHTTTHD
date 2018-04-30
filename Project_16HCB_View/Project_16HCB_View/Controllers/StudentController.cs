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
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Infodiemdanh()
        {
            return View();
        }

        public ActionResult DetailInfoDiemDanh(string txtMSSV)
        {
            int mssv = 0;
            if (txtMSSV != null)
            {
                mssv = int.Parse(txtMSSV);
            }

            var hc = new HttpClient();
            hc.DefaultRequestHeaders.Accept.Clear();
            hc.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            string url = "http://localhost:52740/Student/GetDanhSachHP";
            var res = hc.PostAsJsonAsync(url, new
            {
                mssv
            }).Result;

            if (res.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var result = res.Content.ReadAsAsync<List<HOCPHAN>>().Result;

                ViewBag.danhsachHP = result;

            }
            
            return View();
        }
    }
}