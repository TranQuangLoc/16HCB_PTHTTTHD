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
            if(Session["userid"] != null){
                return RedirectToAction("DetailInfoDiemDanh", "Student");
            }
            return View();
        }

        public ActionResult DetailInfoDiemDanh(string txtMSSV)
        {
            int mssv = 0;
            if (txtMSSV != null)
            {
                mssv = int.Parse(txtMSSV);
                ViewBag.mssv = mssv;
            }
            else if (Session["userid"] != null)
            {
                var hcuserid = new HttpClient();
                var userid = Session["userid"];
                hcuserid.DefaultRequestHeaders.Accept.Clear();
                hcuserid.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                string urluserid = "http://localhost:52740/Student/convertUserId";
                var resuserid = hcuserid.PostAsJsonAsync(urluserid, new
                {
                    userid
                }).Result;

                if (resuserid.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    mssv = resuserid.Content.ReadAsAsync<int>().Result;
                    if (mssv > 0)
                    {
                        ViewBag.mssv = mssv;
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    

                }
            }
            else
            {
                return RedirectToAction("InfoDiemDanh", "Student");
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