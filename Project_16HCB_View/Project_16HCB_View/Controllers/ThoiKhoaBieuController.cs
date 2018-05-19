﻿using Project_16HCB_View.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace Project_16HCB_View.Controllers
{
    public class ThoiKhoaBieuController : Controller
    {
        // GET: ThoiGianBieu
        public ActionResult ThoiKhoaBieu()
        {
            var hc = new HttpClient();
            hc.DefaultRequestHeaders.Accept.Clear();
            hc.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            int userId = 1;
            string url = "http://localhost:8080/Project_16HCB_API/rest/thoikhoabieu/thoikhoabieu";
            var res = hc.PostAsJsonAsync(url, new
            {
                //userId = Session["userid"]   
                userId
            }).Result;
            
            if (res.StatusCode == System.Net.HttpStatusCode.OK)
            {                 
                var result = res.Content.ReadAsAsync<ListTHOIKHOABIEU>().Result;
                
                if (result == null)
                {
                    return RedirectToAction("TrangChu", "TrangChu");
                }
                else
                {
                    return View(result);
                }
            }
            else
            {

            }
            return View();
        }
    }
}