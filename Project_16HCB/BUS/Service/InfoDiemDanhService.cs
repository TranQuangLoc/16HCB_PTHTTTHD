using BUS.Interface;
using BUS.Model;
using DTO;
using DTO.InfoDiemDanhDTO;
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

        public List<InfoDiemDanhContainer>  GetInfoDiemDanh(int mssv, int tkb)
        {
            using (var db = new Project_16HCB_CSDLEntities())
            {
                SqlParameter parameter1 = new SqlParameter("@MSSV", mssv);
                SqlParameter parameter2 = new SqlParameter("@MaTKB", tkb);
                var result = db.Database.SqlQuery<InfoDiemDanhContainer>("exec GetInfoDiemDanh @MSSV, @MaTKB", parameter1, parameter2).ToList();

                return result;
            }
        }

    }
}
