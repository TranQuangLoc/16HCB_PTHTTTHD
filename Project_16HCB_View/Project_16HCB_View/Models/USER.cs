using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_16HCB_View.Models
{
    public class USER
    {
        public int C_userId { get; set; }
        public string C_username { get; set; }
        public string C_email { get; set; }
        public string C_sdt { get; set; }
        public string C_cmnd { get; set; }
        public Nullable<System.DateTime> C_ngaysinh { get; set; }
        public string C_diachi { get; set; }
        public Nullable<int> C_loaiUS { get; set; }
        public Nullable<bool> C_daXoa { get; set; }
    }
}