using Project_16HCB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Project_16HCB.Controllers
{
    public class MonHocHKController : ApiController
    {
        // GET: api/NamHocHK
        public List<MONHOC_HOCKY> Get()
        {
            using (var db = new Project_16HCB_CSDLEntities())
            {
                List<MONHOC_HOCKY> dsMonHocHocKy = new List<MONHOC_HOCKY>();
                dsMonHocHocKy = db.MONHOC_HOCKY.Select(h => h).ToList();
                return dsMonHocHocKy;
            }
        }
    }
}
