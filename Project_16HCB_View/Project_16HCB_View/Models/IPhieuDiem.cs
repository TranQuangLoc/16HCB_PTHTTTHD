using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_16HCB_View.Models
{
    public class IPhieuDiem
    {
        public int hocki { get; set; }
        public int masv { get; set; }
        public int namhoc { get; set; }
        public String tensv { get; set; }
        public int tinhtrang { get; set; }
    }

    public class ListObjectPhieuDiem
    {
        public List<IPhieuDiem> iPhieuDiem;
    }
}