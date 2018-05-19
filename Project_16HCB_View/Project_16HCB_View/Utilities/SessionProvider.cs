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
    }
}