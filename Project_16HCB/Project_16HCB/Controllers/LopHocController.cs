using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Project_16HCB.Models;

namespace Project_16HCB.Controllers
{
    public class LopHocController : ApiController
    {
        // GET: api/LopHoc
        public List<LOPHOC> Get(int NamHoc = -1, int HocKy =1, int MonHoc =1)
        {
            var listLopHoc = new List<LOPHOC>();

            using (var db = new Project_16HCB_CSDLEntities())
            {
                listLopHoc = (from hk in db.HOCKies
                           join mhhk in db.MONHOC_HOCKY on hk.C_id equals mhhk.C_maHK
                           join gvmh in db.GIAOVIEN_MONHOC on mhhk.C_id equals gvmh.C_idMH_HK
                           join tkb in db.THOIKHOABIEUx on gvmh.C_id equals tkb.C_idGV_MH
                           join lh in db.LOPHOCs on tkb.C_idLop equals lh.C_id
                           where ((NamHoc == -1 || hk.C_nam == NamHoc)
                           && (HocKy == -1 || hk.C_id == HocKy)
                           && (MonHoc == -1 || mhhk.C_maMH == MonHoc))
                           select lh).Distinct().ToList();
            }
            return listLopHoc;
        }

    }
}
