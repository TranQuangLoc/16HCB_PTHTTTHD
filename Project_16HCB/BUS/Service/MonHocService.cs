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
    public class MonHocService : IMonHocService
    {
        public List<MonHoc> LayDanhSachMonHoc(ref string errorMsg)
        {
            var lstResult = new List<MonHoc>();
            string sql = "exec usp_layDanhSachMonHoc @errorMsg out";
            errorMsg = "";

            using (var db = new Project_16HCB_CSDLEntities())
            {
                SqlParameter pErrorMsg = new SqlParameter("@errorMsg", System.Data.SqlDbType.NVarChar, 4000)
                {
                    Direction = System.Data.ParameterDirection.Output
                };

                try
                {
                    lstResult = db.Database.SqlQuery<MonHoc>(sql, pErrorMsg).ToList();
                }
                catch (Exception ex)
                {
                    if (pErrorMsg.Value != null)
                        errorMsg = pErrorMsg.Value.ToString();
                    else
                        errorMsg = ex.Message;
                }

                return lstResult;
            }
        }
    }
}
