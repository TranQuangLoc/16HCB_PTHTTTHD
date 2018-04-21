using Project_16HCB.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_16HCB.Controllers.Account
{
    
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return Json(new { name =  "Loc sida", tuoi = "24" }, JsonRequestBehavior.AllowGet);
        }

        //[HttpPost]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Index(int username, string password)
        {
            Response.AppendHeader("Access-Control-Allow-Origin", "*");
            using (var z = new Project_16HCB_CSDLEntities())
            {
                var listATM = z.ACCOUNTs.ToList();
                var obj = z.ACCOUNTs.Where(n => n.C_id == 1).FirstOrDefault();
                return Json(listATM);
                //SqlConnection con = new SqlConnection(z.Database.Connection.ConnectionString);
                //con.Open();
                //SqlCommand cmd = new SqlCommand("select * from Bank", con);
                //SqlDataReader dr = cmd.ExecuteReader();
                //List<Bank> list = new List<Bank>();
                //while (dr.Read())
                //{
                //    Bank b = new Bank();
                //    b.id = (int)dr["id"];
                //    b.NameBank = (string)dr["NameBank"];
                //    b.DiaChi = (string)dr["DiaChi"];
                //    list.Add(b);
                //}
                //con.Close();
                //return Json(list);

                //SqlCommand cmd = new SqlCommand("sp_getATM", con);
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.Add(new SqlParameter("@id", username));
                //SqlDataReader dr = cmd.ExecuteReader();
                //List<Bank> list = new List<Bank>();
                //while (dr.Read())
                //{
                //    Bank b = new Bank();
                //    b.id = (int)dr["id"];
                //    b.NameBank = (string)dr["NameBank"];
                //    b.DiaChi = (string)dr["DiaChi"];
                //    list.Add(b);
                //}
                //con.Close();
                //return Json(list);
            }

        }

        [HttpPost]
        //[AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Login(string username, string password)
        {
            Response.AppendHeader("Access-Control-Allow-Origin", "*");
            using (var z = new Project_16HCB_CSDLEntities())
            {
                //var account = z.ACCOUNTs.ToList();
                var account = z.ACCOUNTs.Where(n => n.C_username == username && n.C_password == password).FirstOrDefault();
                object rs;
                if (account != null)
                {
                    rs = new
                    {
                        data = account,
                        status = "OK"
                    };
                    
                }
                else
                {
                    rs = new
                    {
                        data = account,
                        status = "FALSE"
                    };

                }
                return Json(account);
                //SqlConnection con = new SqlConnection(z.Database.Connection.ConnectionString);
                //con.Open();
                //SqlCommand cmd = new SqlCommand("select * from Bank", con);
                //SqlDataReader dr = cmd.ExecuteReader();
                //List<Bank> list = new List<Bank>();
                //while (dr.Read())
                //{
                //    Bank b = new Bank();
                //    b.id = (int)dr["id"];
                //    b.NameBank = (string)dr["NameBank"];
                //    b.DiaChi = (string)dr["DiaChi"];
                //    list.Add(b);
                //}
                //con.Close();
                //return Json(list);

                //SqlCommand cmd = new SqlCommand("sp_getATM", con);
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.Add(new SqlParameter("@id", username));
                //SqlDataReader dr = cmd.ExecuteReader();
                //List<Bank> list = new List<Bank>();
                //while (dr.Read())
                //{
                //    Bank b = new Bank();
                //    b.id = (int)dr["id"];
                //    b.NameBank = (string)dr["NameBank"];
                //    b.DiaChi = (string)dr["DiaChi"];
                //    list.Add(b);
                //}
                //con.Close();
                //return Json(list);
            }

        }
    }
}