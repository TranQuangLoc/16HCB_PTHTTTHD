using Project_16HCB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Project_16HCB.Controllers
{
    public class HocKyController : ApiController
    {
        // GET: api/HocKy
        public List<HOCKY> Get()
        {
            using (var db = new Project_16HCB_CSDLEntities())
            {
                List<HOCKY> dsHocKy = new List<HOCKY>();
                dsHocKy = db.HOCKies.Select(h => h).ToList();
                return dsHocKy;
            }
        }

    }
}