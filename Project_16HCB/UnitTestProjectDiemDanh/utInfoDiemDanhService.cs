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
    }
}
