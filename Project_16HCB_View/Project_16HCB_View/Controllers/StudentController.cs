using DTO;
using Project_16HCB_View.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
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
            if (Session["userid"] != null)
            {
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

        #region Quan ly sinh vien
        public ActionResult ManageStudent()
        {
            if (Session["userid"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                //Lấy danh sách lớp
                var hc = new HttpClient();
                hc.DefaultRequestHeaders.Accept.Clear();
                hc.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                string url = "http://localhost:52740/api/lop";
                var res = hc.GetAsync(url).Result;

                List<LopHoc> lstLopHoc = new List<LopHoc>();

                if (res.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    Models.Common.ConvertLst<LopHoc>(res, ref lstLopHoc);
                }

                ViewBag.HTMLLop = GenHtmlLop(lstLopHoc);

                //Lấy danh sách khoa
                hc.DefaultRequestHeaders.Accept.Clear();
                hc.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                url = "http://localhost:52740/api/khoa";
                res = hc.GetAsync(url).Result;

                List<Khoa> lstKhoa = new List<Khoa>();

                if (res.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    Models.Common.ConvertLst<Khoa>(res, ref lstKhoa);
                }

                ViewBag.HTMLKhoa = GenHtmlKhoa(lstKhoa);

                return View();
            }
        }

        public ActionResult SearchStudent(string strKeyWord, int intSchoolClassID, int intDivisionID, int intIsGet, int intPageIndex = 1)
        {
            try
            {
                if (Session["userid"] != null)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    int intRowOnPage = 2;
                    //Lấy danh sách lớp
                    var hc = new HttpClient();
                    hc.DefaultRequestHeaders.Accept.Clear();
                    hc.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    string url = "http://localhost:52740/Student/timkiemSV";

                    var res = hc.PostAsJsonAsync(url, new
                    {
                        tukhoa = strKeyWord,
                        malop = intSchoolClassID,
                        makhoa = intDivisionID,
                        dalay = intIsGet,
                        chisotrang = intPageIndex,
                        sodong = intRowOnPage
                    }).Result;
                    List<SinhVien> lstSinhVien = new List<SinhVien>();

                    if (res.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        Models.Common.ConvertLst<SinhVien>(res, ref lstSinhVien);
                    }

                    string strHTMLSinhVien = GenHtmlSinhVien(lstSinhVien);

                    int intTotalPages = 0;
                    int intSoDong = 0;
                    if (lstSinhVien != null && lstSinhVien.Count > 0)
                    {
                        intSoDong = lstSinhVien[0]._sodong;
                        //Lấy tổng số lượng trang
                        intTotalPages = lstSinhVien[0]._sodong / intRowOnPage;
                        //Trường hợp số phần tử không chia hết cho intVisiblePages
                        if (lstSinhVien[0]._sodong % intRowOnPage != 0)
                            intTotalPages = intTotalPages + 1;
                    }

                    return Json(new
                    {
                        iserror = false,
                        content = strHTMLSinhVien,
                        totalpages = intTotalPages,
                        totalrows = intSoDong
                    });
                }
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    iserror = true
                });
            }
        }

        public ActionResult StudentInsert()
        {
            if (Session["userid"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                //Lấy danh sách lớp
                var hc1 = new HttpClient();
                hc1.DefaultRequestHeaders.Accept.Clear();
                hc1.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                string url = "http://localhost:52740/api/lop";
                var res = hc1.GetAsync(url).Result;

                List<LopHoc> lstLopHoc = new List<LopHoc>();

                if (res.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    Models.Common.ConvertLst<LopHoc>(res, ref lstLopHoc);
                }

                ViewBag.HTMLLop = GenHtmlLop(lstLopHoc);

                return View();
            }
        }

        [HttpPost]
        public JsonResult InsertStudent(FormCollection frm)
        {
            try
            {
                List<VanTay> lstVanTay = Newtonsoft.Json.JsonConvert.DeserializeObject<List<VanTay>>(frm["hdListVanTay"]);
                string strUserName = Convert.ToString(frm["txtUserName"]);
                string strCMND = Convert.ToString(frm["txtCMND"]);
                string strEmail = Convert.ToString(frm["txtEmail"]);
                string strSDT = Convert.ToString(frm["txtSDT"]);
                string strNgaySinh = Convert.ToString(frm["txtNgaySinh"]);
                string strHDT = Convert.ToString(frm["cboHDT"]);
                string strTrangThai = Convert.ToString(frm["cboTrangThai"]);
                int intLop = Convert.ToInt32(Convert.ToString(frm["cboLop"]));
                string strDiaChi = Convert.ToString(frm["txtDiaChi"]);

                SinhVien objSinhVien = new SinhVien();
                objSinhVien._username = strUserName;
                objSinhVien._cmnd = strCMND;
                objSinhVien._email = strEmail;
                objSinhVien._sdt = strSDT;
                objSinhVien._ngaysinh = strNgaySinh;
                objSinhVien._hedaotao = strHDT;
                objSinhVien._trangthai = strTrangThai;
                objSinhVien._malop = intLop;
                objSinhVien._diachi = strDiaChi;
                objSinhVien._lstVanTay = lstVanTay;

                var hc2 = new HttpClient();
                hc2.DefaultRequestHeaders.Accept.Clear();
                hc2.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                string url = "http://localhost:52740/Student/themSV";

                var res = hc2.PostAsJsonAsync(url, objSinhVien).Result;

                if (res.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    bool bolSuccess = res.Content.ReadAsAsync<bool>().Result;

                    if (bolSuccess == true)
                        return Json(new { iserror = false });
                }

                return Json(new { iserror = true });
            }
            catch (Exception)
            {
                return Json(new { iserror = true });
            }
        }

        public ActionResult StudentUpdate(string strStudentID)
        {
            if (Session["userid"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                //Lấy thông tin sinh viên theo id
                var hc = new HttpClient();
                hc.DefaultRequestHeaders.Accept.Clear();
                hc.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                string url = "http://localhost:52740/Student/layThongTinSV?mssv=" + strStudentID;
                var res = hc.GetAsync(url).Result;

                List<SinhVien> lstSinhVien = new List<SinhVien>();

                if (res.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    Models.Common.ConvertLst<SinhVien>(res, ref lstSinhVien);
                }

                //Lấy danh sách lớp
                hc.DefaultRequestHeaders.Accept.Clear();
                hc.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                url = "http://localhost:52740/api/lop";
                res = hc.GetAsync(url).Result;

                List<LopHoc> lstLopHoc = new List<LopHoc>();

                if (res.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    Models.Common.ConvertLst<LopHoc>(res, ref lstLopHoc);
                }

                ViewBag.HTMLLop = GenHtmlLop(lstLopHoc, lstSinhVien[0]._malop);

                string[] arrTemp = lstSinhVien[0]._ngaysinh.Split('-');
                lstSinhVien[0]._ngaysinh = arrTemp[2] + '/' + arrTemp[1] + '/' + arrTemp[0];

                return View(lstSinhVien[0]);
            }
        }

        public ActionResult StudentDelete(string strStudentID)
        {
            try
            {
                if (Session["userid"] != null)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    //Lấy thông tin sinh viên theo id
                    var hc = new HttpClient();
                    hc.DefaultRequestHeaders.Accept.Clear();
                    hc.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    string url = "http://localhost:52740/Student/xoaSV?mssv=" + strStudentID;
                    var res = hc.GetAsync(url).Result;

                    if (res.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        bool bolSuccess = res.Content.ReadAsAsync<bool>().Result;

                        if (bolSuccess == true)
                            return Json(new { iserror = false });
                    }

                    return Json(new { iserror = true });
                }
            }
            catch (Exception ex)
            {
                return Json(new { iserror = true });
            }
        }

        [HttpPost]
        public JsonResult UpdateStudent(FormCollection frm)
        {
            try
            {
                List<VanTay> lstVanTay = Newtonsoft.Json.JsonConvert.DeserializeObject<List<VanTay>>(frm["hdListVanTay"]);
                string strUserName = Convert.ToString(frm["txtUserName"]);
                string strCMND = Convert.ToString(frm["txtCMND"]);
                string strEmail = Convert.ToString(frm["txtEmail"]);
                string strSDT = Convert.ToString(frm["txtSDT"]);
                string strNgaySinh = Convert.ToString(frm["txtNgaySinh"]);
                string strHDT = Convert.ToString(frm["cboHDT"]);
                string strTrangThai = Convert.ToString(frm["cboTrangThai"]);
                int intLop = Convert.ToInt32(Convert.ToString(frm["cboLop"]));
                string strDiaChi = Convert.ToString(frm["txtDiaChi"]);
                int intUserID  = Convert.ToInt32(frm["hdUserID"]);

                SinhVien objSinhVien = new SinhVien();
                objSinhVien._userid = intUserID;
                objSinhVien._username = strUserName;
                objSinhVien._cmnd = strCMND;
                objSinhVien._email = strEmail;
                objSinhVien._sdt = strSDT;
                objSinhVien._ngaysinh = strNgaySinh;
                objSinhVien._hedaotao = strHDT;
                objSinhVien._trangthai = strTrangThai;
                objSinhVien._malop = intLop;
                objSinhVien._diachi = strDiaChi;
                objSinhVien._lstVanTay = lstVanTay;

                var hc = new HttpClient();
                hc.DefaultRequestHeaders.Accept.Clear();
                hc.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                string url = "http://localhost:52740/Student/capnhatSV";

                var res = hc.PostAsJsonAsync(url, objSinhVien).Result;

                if (res.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    bool bolSuccess = res.Content.ReadAsAsync<bool>().Result;

                    if (bolSuccess == true)
                        return Json(new { iserror = false });
                }

                return Json(new { iserror = true });
            }
            catch (Exception)
            {
                return Json(new { iserror = true });
            }
        }

        public string GenHtmlLop(List<LopHoc> lstLopHoc, int intChon = -1)
        {
            StringBuilder strHTML = new StringBuilder();

            if (intChon == -1)
                strHTML.Append("<option value='-1' selected>-- Chọn lớp học --</option>");
            else
                strHTML.Append("<option value='-1' selected>-- Chọn lớp học --</option>");

            if (lstLopHoc != null && lstLopHoc.Count > 0)
            {
                int intCountElm = lstLopHoc.Count;
                for (int i = 0; i < intCountElm; i++)
                {
                    strHTML.Append(String.Format("<option value='{0}' {1}>{2}</option>", 
                        lstLopHoc[i]._id, 
                        (lstLopHoc[i]._id == intChon ? "selected" : ""),
                        lstLopHoc[i]._tenLop));
                }
            }

            return Convert.ToString(strHTML);
        }

        public string GenHtmlKhoa(List<Khoa> lstKhoa, int intChon = -1)
        {
            StringBuilder strHTML = new StringBuilder();

            if (intChon == -1)
                strHTML.Append("<option value='-1' selected>-- Chọn khoa --</option>");
            else
                strHTML.Append("<option value='-1'>-- Chọn khoa --</option>");

            if (lstKhoa != null && lstKhoa.Count > 0)
            {
                int intCountElm = lstKhoa.Count;
                for (int i = 0; i < intCountElm; i++)
                {
                    strHTML.Append(String.Format("<option value='{0}' {1}>{2}</option>", 
                        lstKhoa[i]._id, 
                        (lstKhoa[i]._id == intChon ? "selected" : ""), 
                        lstKhoa[i]._tenKhoa));
                }
            }

            return Convert.ToString(strHTML);
        }

        private string GenHtmlSinhVien(List<SinhVien> lstSinhVien)
        {
            StringBuilder strbuilder = new StringBuilder();

            if (lstSinhVien != null && lstSinhVien.Count > 0)
            {
                int intCountElm = lstSinhVien.Count;

                for (int i = 0; i < intCountElm; i++)
                {
                    string StudentID = Convert.ToString(lstSinhVien[i]._userid);
                    strbuilder.Append("<tr>");
                    strbuilder.AppendFormat("<td>{0}</td>", lstSinhVien[i]._stt);
                    strbuilder.AppendFormat("<td>{0}</td>", lstSinhVien[i]._userid);
                    strbuilder.AppendFormat("<td>{0}</td>", lstSinhVien[i]._username);
                    strbuilder.AppendFormat("<td>{0}</td>", lstSinhVien[i]._tenlop);
                    strbuilder.AppendFormat("<td>{0}</td>", lstSinhVien[i]._email);
                    strbuilder.AppendFormat("<td>{0}</td>", lstSinhVien[i]._sdt);
                    strbuilder.AppendFormat("<td>{0}</td>", lstSinhVien[i]._cmnd);
                    strbuilder.AppendFormat("<td>{0}</td>", lstSinhVien[i]._dalay);
                    strbuilder.AppendFormat("<td data-studentid='{0}'>", StudentID);
                    strbuilder.AppendFormat("<span class='glyphicon glyphicon-pencil table-icon' data-name='Detail'></span>");
                    strbuilder.AppendFormat("<span class='glyphicon glyphicon-trash table-icon' data-name='Delete'></span>");
                    strbuilder.AppendFormat("</td>");
                    strbuilder.Append("</tr>");
                }
            }
            else
            {
                strbuilder.Append("<tr><td colspan='12' class='table-content-null'>Hiện không có nội dung</td></tr>");
            }

            return Convert.ToString(strbuilder);
        }

        #endregion
    }
}