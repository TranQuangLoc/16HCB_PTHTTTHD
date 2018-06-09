using BUS.Interface;
using BUS.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProjectDiemDanh
{
    [TestClass]
    public class utMonHocService
    {
        [TestMethod]
        public void TestLayDanhSachMonHoc()
        {
            IMonHocService ims = new MonHocService();
            string error = "";
            var result = ims.LayDanhSachMonHoc(ref error);

            Assert.AreEqual(result.Count, 0, "Lỗi: TestLayDanhSachMonHoc: không trả về kết quả.");
        }
    }
}
