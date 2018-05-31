using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Interface
{
    public interface ISinhVienService
    {
        bool ThemSinhVien(SinhVien sv);
        bool CapNhatSinhVien(SinhVien sv);
        bool XoaSinhVien(int intMSSV);
        bool LayThongTinSinhVien(int intMSSV, ref SinhVien objSinhVien);
        bool TimKiemSinhVien(SinhVien sv, ref List<SinhVien> lstSinhVien, string strTuKhoa, int intPageIndex, int intPageSize);

    }
}
