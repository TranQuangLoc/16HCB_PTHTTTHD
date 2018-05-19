using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_16HCB_View.Models
{
    public class ListTHOIKHOABIEU
    {
        public List<THOIKHOABIEU> iThoiKhoaBieu;
    }

    public class THOIKHOABIEU
    {
        public int thu { get; set; }
        public String ngayBatDau { get; set; }
        public String ngayKetThuc { get; set; }
        public int maPhong { get; set; }
    }
}