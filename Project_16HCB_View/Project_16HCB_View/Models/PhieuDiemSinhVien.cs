using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_16HCB_View.Models
{
    public class PhieuDiemSinhVien
    {
        public int masv { get; set; }
        public String tensv { get; set; }
        public String tenmh { get; set; }
        public double diem { get; set; }
        public int sotc { get; set; }
    }

    public class ListPhieuDiemSinhVien
    {
        public List<PhieuDiemSinhVien> iKetQuaPhieuDiemSinhVien;
    }
}