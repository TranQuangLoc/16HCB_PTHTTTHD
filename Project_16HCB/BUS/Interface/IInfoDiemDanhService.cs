using BUS.Model;
using DTO;
using DTO.InfoDiemDanhDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Interface
{
    public interface IInfoDiemDanhService
    {
        bool KiemTraSVTonTai(int mssv);
        List<HOCPHAN> GetDanhSachHP(int mssv);
        List<InfoDiemDanhContainer> GetInfoDiemDanh(int mssv, int tkb);
        int convertUserId(int userid);
    }
}
