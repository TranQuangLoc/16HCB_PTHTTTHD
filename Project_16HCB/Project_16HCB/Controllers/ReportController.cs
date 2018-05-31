using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Project_16HCB.Models;

namespace Project_16HCB.Controllers
{

    public class ReportStudentResult
    {
        public int MSSV { get; set; }
        public string Username { get; set; }
        public string TenLop { get; set; }
        public int NamHoc { get; set; }
        public string MonHoc { get; set; }
        public string HocKy { get; set; }
        public int SLNghi { get; set; }
    }
	public class ReportDanhSachHocSinhNghiModel
    {
        public int ma_sv { get; set; }
        public string ten_sv { get; set; }
        public int ma_lop { get; set; }
        public DateTime ngay_nghihoc { get; set; }
        public string ngay_nghihoc_text { get; set; }

    }
    public class ReportController : ApiController
    {
        // GET: api/Default
        [HttpGet]
        [Route("api/Report/ReportStudent")]
        public List<ReportStudentResult> ReportStudent(int Nam = -1, int HocKy = -1, int MonHoc = -1, int LopHoc = -1)
        {
            using (var db = new Project_16HCB_CSDLEntities())
            {
                List<ReportStudentResult> results = new List<ReportStudentResult>();

                results = db.Database.SqlQuery<ReportStudentResult>("sp_ReportStudent @Nam, @HocKy, @MonHoc, @LopHoc",
                    new SqlParameter("Nam", Nam),
                    new SqlParameter("HocKy", HocKy),
                    new SqlParameter("MonHoc", MonHoc),
                    new SqlParameter("LopHoc", LopHoc)).ToList();
                return results;
            }
        }
		
		
		[HttpGet]
        [Route("api/Report/ReportDanhSachHocSinhNghi")]
        public List<ReportDanhSachHocSinhNghiModel> ReportDanhSachHocSinhNghi(DateTime? TU_NGAY = null, DateTime? DEN_NGAY = null)
        {
            if (TU_NGAY == null || DEN_NGAY == null)
                throw new Exception("VUI LÒNG CHỌN TỪ NGÀY ĐẾN NGÀY");

            using (var db = new Project_16HCB_CSDLEntities())
            {
                List<ReportDanhSachHocSinhNghiModel> results = new List<ReportDanhSachHocSinhNghiModel>();

                results = db.Database.SqlQuery<ReportDanhSachHocSinhNghiModel>("SP_DanhSacHocSinhNghi @TU_NGAY, @DEN_NGAY ",
                    new SqlParameter("TU_NGAY", TU_NGAY),
                    new SqlParameter("DEN_NGAY", DEN_NGAY)).ToList();

                foreach (var data in results)
                {
                    data.ngay_nghihoc_text = data.ngay_nghihoc.ToString("dd/MM/yyyy");
                }


                return results;
            }
        }
    }
}