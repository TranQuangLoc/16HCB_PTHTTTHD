using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Project_16HCB.Models;

namespace Project_16HCB.Controllers
{
    public class MonHocController : ApiController
    {
        // GET: api/MonHoc
        public List<MONHOC> Get()
        {
            using (var db = new Project_16HCB_CSDLEntities())
            {
                List<MONHOC> dsMonHoc = new List<MONHOC>();
                dsMonHoc = db.MONHOCs.Select(h => h).ToList();
                return dsMonHoc;
            }
        }

       
    }
}
