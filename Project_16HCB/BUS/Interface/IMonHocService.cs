using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Interface
{
    public interface IMonHocService
    {
        List<MonHoc> LayDanhSachMonHoc(ref string errorMsg);
    }
}
