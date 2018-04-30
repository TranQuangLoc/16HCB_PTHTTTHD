using System;
using BUS.Interface;
using BUS.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProjectDiemDanh
{
    [TestClass]
    public class utInfoDiemDanhService
    {
        [TestMethod]
        public void TestKiemTraSVTonTai_CoKetQua()
        {
            IInfoDiemDanhService idds = new InfoDiemDanhService();
            bool result = idds.KiemTraSVTonTai(1);
            Assert.IsTrue(result, "Lỗi: TestKiemTraSVTonTai_CoKetQua: không trả về kết quả.");
        }

        [TestMethod]
        public void TestKiemTraSVTonTai_KhongKetQua()
        {
            IInfoDiemDanhService idds = new InfoDiemDanhService();
            bool result = idds.KiemTraSVTonTai(2);
            Assert.IsFalse(result, "Lỗi: TestKiemTraSVTonTai_KhongKetQua: trả về được kết quả.");
        }



        [TestMethod]
        public void TestGetDanhSachHP_CoKetQua()
        {
            IInfoDiemDanhService idds = new InfoDiemDanhService();
            var danhsach = idds.GetDanhSachHP(1);
            bool result;
            if (danhsach.Count > 0)
            {
                result = true;
            } else
            {
                result = false;
            }
            Assert.IsTrue(result, "Lỗi: TestGetDanhSachHP_CoKetQua: không trả về kết quả.");
        }

        [TestMethod]
        public void TestGetDanhSachHP_KhongKetQua()
        {
            IInfoDiemDanhService idds = new InfoDiemDanhService();
            var danhsach = idds.GetDanhSachHP(0);
            bool result;
            if (danhsach.Count > 0)
            {
                result = true;
            }
            else
            {
                result = false;
            }
            Assert.IsFalse(result, "Lỗi: TestGetDanhSachHP_KhongKetQua: trả về kết quả.");
        }

        [TestMethod]
        public void TestGetInfoDiemDanh_CoKetQua()
        {
            IInfoDiemDanhService idds = new InfoDiemDanhService();
            var danhsach = idds.GetInfoDiemDanh(1,3);
            bool result;
            if (danhsach.Count > 0)
            {
                result = true;
            }
            else
            {
                result = false;
            }
            Assert.IsTrue(result, "Lỗi: TestGetInfoDiemDanh_CoKetQua: không trả về kết quả.");
        }

        [TestMethod]
        public void TestGetInfoDiemDanh_KhongKetQua_SaiMSSV()
        {
            IInfoDiemDanhService idds = new InfoDiemDanhService();
            var danhsach = idds.GetInfoDiemDanh(0,3);
            bool result;
            if (danhsach.Count > 0)
            {
                result = true;
            }
            else
            {
                result = false;
            }
            Assert.IsFalse(result, "Lỗi: TestGetInfoDiemDanh_KhongKetQua_SaiMSSV: trả về kết quả.");
        }


        [TestMethod]
        public void TestGetInfoDiemDanh_KhongKetQua_SaiTKB()
        {
            IInfoDiemDanhService idds = new InfoDiemDanhService();
            var danhsach = idds.GetInfoDiemDanh(1, 0);
            bool result;
            if (danhsach.Count > 0)
            {
                result = true;
            }
            else
            {
                result = false;
            }
            Assert.IsFalse(result, "Lỗi: TestGetInfoDiemDanh_KhongKetQua_SaiTKB: trả về kết quả.");
        }

        [TestMethod]
        public void TestGetInfoDiemDanh_KhongKetQua_SaiALL()
        {
            IInfoDiemDanhService idds = new InfoDiemDanhService();
            var danhsach = idds.GetInfoDiemDanh(0, 0);
            bool result;
            if (danhsach.Count > 0)
            {
                result = true;
            }
            else
            {
                result = false;
            }
            Assert.IsFalse(result, "Lỗi: TestGetInfoDiemDanh_KhongKetQua_SaiALL: trả về kết quả.");
        }


    }
}
