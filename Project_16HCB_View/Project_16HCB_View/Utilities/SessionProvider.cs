using Project_16HCB_View.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_16HCB_View.Utilities
{
    public static class SessionProvider
    {
        public static int GetUserIdFromSession()
        {
            return (int) HttpContext.Current.Session["userId"];
        }

        public static int GetUserTypeFromSession()
        {
            return (int)HttpContext.Current.Session["loaiUS"];
        }

        public static USER GetUserFromSession()
        {
            return (USER)HttpContext.Current.Session["user"];
        }

        public static int GetSoLuongResPhieuDiemFromSession()
        {
            return (int)HttpContext.Current.Session["resPhieuDiem"];
        }

        public static int GetSoLuongResTraPhieuDiemFromSession()
        {
            return (int)HttpContext.Current.Session["resTraPhieuDiemSV"];
        }
    }


}