using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_16HCB_View.Models
{
    public class ACCOUNT
    {
        public int _id { get; set; }
        public string _username { get; set; }
        public string _password { get; set; }
        public int _userId { get; set; }
        public DateTime _ngayLap { get; set; }
    }
}