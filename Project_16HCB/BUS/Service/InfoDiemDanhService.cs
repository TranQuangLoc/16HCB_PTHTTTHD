using BUS.Interface;
using BUS.Model;
using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Service
{
    public class InfoDiemDanhService : IInfoDiemDanhService
    {
        public bool KiemTraSVTonTai(int mssv)
        {
            using (var db = new Project_16HCB_CSDLEntities())
            {
                //var sinhvien = db.SINHVIENs
                //        .Where(n => n.C_mssv == mssv)
                //        .FirstOrDefault();
                SqlParameter parameter1 = new SqlParameter("@MSSV", mssv);
                var result = db.Database.SqlQuery<int>("exec kiemtraSVTonTai @MSSV", parameter1).FirstOrDefault();

                if (result != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public List<HOCPHAN> GetDanhSachHP(int mssv)
        {
            using (var db = new Project_16HCB_CSDLEntities())
            {
                SqlParameter parameter1 = new SqlParameter("@MSSV", mssv);
                var result = db.Database.SqlQuery<HOCPHAN>("exec GetDanhSachHP @MSSV", parameter1).ToList();

                return result;
            }
        }

    }
}
