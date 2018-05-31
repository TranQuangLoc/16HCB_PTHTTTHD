using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BUS.Interface;
using BUS.Service;
using DTO;

namespace UnitTestProjectDiemDanh
{
    /// <summary>
    /// Summary description for utSinhVienService
    /// </summary>
    [TestClass]
    public class utSinhVienService
    {
        [TestMethod]
        public void utSinhVienService_TestLayThongTinSinhVien_CoKetQua()
        {
            ISinhVienService issv = new SinhVienService();
            SinhVien sv = new SinhVien();
            bool result = issv.LayThongTinSinhVien(5,ref sv);
            Assert.IsTrue(result, "Lỗi: utSinhVienService_TestLayThongTinSinhVien: không trả về kết quả.");
        }

        [TestMethod]
        public void utSinhVienService_TestLayThongTinSinhVien_KhongKetQua()
        {
            ISinhVienService issv = new SinhVienService();
            SinhVien sv = new SinhVien();
            bool result = issv.LayThongTinSinhVien(0, ref sv);
            Assert.IsFalse(result, "Lỗi: utSinhVienService_TestLayThongTinSinhVien: trả về kết quả.");
        }


        [TestMethod]
        public void utSinhVienService_TestTimKiemSinhVien_CoKetQua()
        {
            ISinhVienService issv = new SinhVienService();
            SinhVien sv = new SinhVien();
            sv._malop = -1;
            sv._makhoa = -1;
            sv._dalay = -1;
            List<SinhVien> lstSinhVien = new List<SinhVien>();
            bool result = issv.TimKiemSinhVien(sv, ref lstSinhVien , string.Empty, 1, 10);
            Assert.IsTrue(result, "Lỗi: utSinhVienService_TestTimKiemSinhVien: không trả về kết quả.");
        }


        [TestMethod]
        public void utSinhVienService_TestCapNhatSinhVien()
        {
            ISinhVienService issv = new SinhVienService();
            SinhVien sv = new SinhVien();
            bool result = issv.LayThongTinSinhVien(5, ref sv);
            if (result == true && sv._userid != 0)
            {
                sv._username = "Nguyễn Văn Test";
                if (!string.IsNullOrEmpty(sv._ngaysinh))
                    sv._ngaysinh = sv._ngaysinh.Replace('-', '/');
            }
            result = issv.CapNhatSinhVien(sv);
            Assert.IsTrue(result, "Lỗi: utSinhVienService_TestCapNhatSinhVien: không cập nhật được.");
        }

        [TestMethod]
        public void utSinhVienService_TestThemSinhVien()
        {
            ISinhVienService issv = new SinhVienService();
            SinhVien sv = new SinhVien();
            bool result = issv.LayThongTinSinhVien(5, ref sv);
            if (result == true && sv._userid != 0)
            {
                sv._username = "Nguyễn Văn Test";
                if (!string.IsNullOrEmpty(sv._ngaysinh))
                    sv._ngaysinh = sv._ngaysinh.Replace('-', '/');
            }
            result = issv.ThemSinhVien(sv);
            Assert.IsTrue(result, "Lỗi: utSinhVienService_TestThemSinhVien: không thêm được.");
        }

        [TestMethod]
        public void utSinhVienService_TestXoaSinhVien()
        {
            ISinhVienService issv = new SinhVienService();
            bool result = issv.XoaSinhVien(5);
            Assert.IsTrue(result, "Lỗi: utSinhVienService_TestXoaSinhVien: không xóa được.");
        }

    }
}
