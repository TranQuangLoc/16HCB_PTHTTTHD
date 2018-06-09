using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_16HCB_View.Models
{
    public class MonHoc
    {
        public int C_id { get; set; }
        public string C_tenMH { get; set; }
        public Nullable<int> C_maKhoa { get; set; }
        public Nullable<int> C_soBuoi { get; set; }
        public Nullable<int> C_soTC { get; set; }
    }
}