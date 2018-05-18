using BUS.Interface;
using BUS.Model;
using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BUS.Service
{
    public class SinhVienService : ISinhVienService
    {
        public bool ThemSinhVien(SinhVien sv)
        {
            try
            {
                using (var db = new Project_16HCB_CSDLEntities())
                {
                    //Thêm user
                    USER objUser = new USER();
                    objUser.C_username = sv._username;
                    objUser.C_email = sv._email;
                    objUser.C_sdt = sv._sdt;
                    objUser.C_cmnd = sv._cmnd;
                    string[] arrtemp = sv._ngaysinh.Split('/');
                    objUser.C_ngaysinh = Convert.ToDateTime(arrtemp[1] + "/" + arrtemp[0] + "/" + arrtemp[2]);
                    objUser.C_diachi = sv._diachi;
                    objUser.C_loaiUS = 1;
                    objUser.C_daXoa = false;

                    db.USERS.Add(objUser);
                    db.SaveChanges();
                    //try
                    //{
                    //    db.USERS.Add(objUser);
                    //    db.SaveChanges();
                    //}
                    //catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
                    //{
                    //    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    //    {
                    //        foreach (var validationError in validationErrors.ValidationErrors)
                    //        {
                    //            System.Console.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    //        }
                    //    }
                    //}

                    sv._userid = objUser.C_userId;
                }

                using (var db = new Project_16HCB_CSDLEntities())
                {
                    //Thêm sinh viên
                    SINHVIEN objSinhVien = new SINHVIEN();
                    objSinhVien.C_userId = sv._userid;
                    objSinhVien.C_heDaoTao = sv._hedaotao;
                    objSinhVien.C_ngayBatDau = DateTime.Now;
                    objSinhVien.C_trangThai = sv._trangthai;
                    objSinhVien.C_maLop = sv._malop;
                    objSinhVien.C_daXoa = false;

                    db.SINHVIENs.Add(objSinhVien);
                    db.SaveChanges();
                }

                using (var db = new Project_16HCB_CSDLEntities())
                {
                    //Thêm vân tay
                    int intSoVanTay = sv._lstVanTay.Count;

                    for (int i = 0; i < intSoVanTay; i++)
                    {
                        VANTAY objVanTay = new VANTAY();
                        objVanTay.C_userID = sv._userid;
                        objVanTay.C_url = sv._lstVanTay[i]._url;
                        objVanTay.C_ngayTao = DateTime.Now;
                        objVanTay.C_daXoa = false;

                        db.VANTAYs.Add(objVanTay);
                    }
                    db.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //public bool ThemSinhVien(SinhVien sv)
        //{
        //    try
        //    {
        //        int CurID;
        //        using (var db = new Project_16HCB_CSDLEntities())
        //        {
        //            SqlParameter paUSERNAME = new SqlParameter("@USERNAME", sv._username);
        //            SqlParameter paEMAIL = new SqlParameter("@EMAIL", sv._email);
        //            SqlParameter paSDT = new SqlParameter("@SDT", sv._sdt);
        //            SqlParameter paCMND = new SqlParameter("@CMND", sv._cmnd);
        //            SqlParameter paNGAYSINH = new SqlParameter("@NGAYSINH", sv._ngaysinh);
        //            SqlParameter paDIACHI = new SqlParameter("@DIACHI", sv._diachi);
        //            SqlParameter paMSSV = new SqlParameter("@MSSV", sv._mssv);
        //            SqlParameter paHDT = new SqlParameter("@HEDAOTAO", sv._hedaotao);
        //            SqlParameter paTRANGTHAI = new SqlParameter("@TRANGTHAI", sv._trangthai);
        //            SqlParameter paMALOP = new SqlParameter("@MALOP", sv._malop);

        //            var result = db.Database.SqlQuery<SinhVien>("exec sp_themUser @USERNAME,@EMAIL,@SDT,@CMND,@NGAYSINH,@DIACHI,@MSSV,@HEDAOTAO,@TRANGTHAI,@MALOP", 
        //                paUSERNAME,
        //                paEMAIL,
        //                paSDT,
        //                paCMND,
        //                paNGAYSINH,
        //                paDIACHI,
        //                paMSSV,
        //                paHDT,
        //                paTRANGTHAI,
        //                paMALOP).FirstOrDefault();

        //            CurID = Convert.ToInt32(result);
        //        }

        //        using (var db = new Project_16HCB_CSDLEntities())
        //        {

        //            int intSoVanTay = sv._lstVanTay.Count;

        //            for (int i = 0; i < intSoVanTay; i++)
        //            {
        //                SqlParameter paUSERID = new SqlParameter("@USERID", CurID);
        //                SqlParameter paMAVANTAY = new SqlParameter("@MAVANTAY", sv._lstVanTay[i]._mavantay);
        //                SqlParameter paURL = new SqlParameter("@URL", sv._lstVanTay[i]._url);

        //                var result = db.Database.SqlQuery<SinhVien>("exec sp_themVanTay @USERID,@MAVANTAY,@URL",
        //                    paUSERID,
        //                    paMAVANTAY,
        //                    paURL).FirstOrDefault();
        //            }
        //        }

        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}

        public bool CapNhatSinhVien(SinhVien sv)
        {
            try
            {
                using (var db = new Project_16HCB_CSDLEntities())
                {
                    //Cập nhật user
                    var objUser = db.USERS.Where(i => i.C_userId == sv._userid).FirstOrDefault();
                    objUser.C_username = sv._username;
                    objUser.C_email = sv._email;
                    objUser.C_sdt = sv._sdt;
                    objUser.C_cmnd = sv._cmnd;
                    string[] arrtemp = sv._ngaysinh.Split('/');
                    objUser.C_ngaysinh = Convert.ToDateTime(arrtemp[1] + "/" + arrtemp[0] + "/" + arrtemp[2]);
                    objUser.C_diachi = sv._diachi;

                    db.SaveChanges();

                    //Cập nhật sinh viên
                    var objSinhVien = db.SINHVIENs.Where(i => i.C_userId == sv._userid).FirstOrDefault();
                    objSinhVien.C_heDaoTao = sv._hedaotao;
                    objSinhVien.C_ngayBatDau = DateTime.Now;
                    objSinhVien.C_trangThai = sv._trangthai;
                    objSinhVien.C_maLop = sv._malop;

                    db.SaveChanges();

                    //Cập nhật vân tay
                    var lstVanTay = db.VANTAYs.Where(i => i.C_userID == sv._userid).ToList();
                    int intSoVanTay = lstVanTay.Count();

                    for (int i = 0; i < intSoVanTay; i++)
                    {
                        var objVanTay = lstVanTay[i];
                        objVanTay.C_maVanTay = sv._lstVanTay[i]._mavantay;
                        objVanTay.C_url = sv._lstVanTay[i]._url;
                        objVanTay.C_ngayTao = DateTime.Now;
                    }
                    db.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }

        public bool XoaSinhVien(int intUserID)
        {
            try
            {
                using (var db = new Project_16HCB_CSDLEntities())
                {
                    //Xóa sinh viên
                    var objSinhVien = db.SINHVIENs.Where(i => i.C_userId == intUserID && i.C_daXoa == false).FirstOrDefault();
                    objSinhVien.C_daXoa = true;

                    db.SaveChanges();
                }

                using (var db = new Project_16HCB_CSDLEntities())
                {
                    //Xóa user
                    var objUser = db.USERS.Where(i => i.C_userId == intUserID).FirstOrDefault();
                    objUser.C_daXoa = true;

                    db.SaveChanges();
                }

                using (var db = new Project_16HCB_CSDLEntities())
                {
                    //Xóa vân tay
                    var lstVanTay = db.VANTAYs.Where(i => i.C_userID == intUserID).ToList();
                    int intSoVanTay = lstVanTay.Count();

                    for (int i = 0; i < intSoVanTay; i++)
                    {
                        var objVanTay = lstVanTay[i];
                        objVanTay.C_daXoa = true;
                    }

                    db.SaveChanges();
                }

                return true;
            }
            catch (Exception)
            {
                return false;

            }
        }

        public bool LayThongTinSinhVien(int intUserID, ref SinhVien objSinhVien)
        {
            try
            {
                using (var db = new Project_16HCB_CSDLEntities())
                {
                    SqlParameter paMSSV = new SqlParameter("@MSSV", intUserID);
                    var result = db.Database.SqlQuery<SinhVien>("exec sp_getThongTinSinhVien @MSSV", paMSSV).ToList();

                    objSinhVien = result[0];

                    var lstVanTay = db.VANTAYs.Where(i => i.C_userID == intUserID).ToList();
                    List<VanTay> lstTemp = new List<VanTay>();

                    for (int i = 0; i < lstVanTay.Count(); i++)
                    {
                        VanTay objVanTayDTO = new VanTay();
                        objVanTayDTO._id = lstVanTay[i].C_id;
                        objVanTayDTO._mavantay = lstVanTay[i].C_maVanTay;
                        objVanTayDTO._url = lstVanTay[i].C_url;
                        objVanTayDTO._userid = intUserID;

                        lstTemp.Add(objVanTayDTO);
                    }

                    objSinhVien._lstVanTay = lstTemp;
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool TimKiemSinhVien(SinhVien sv, ref List<SinhVien> lstSinhVien, string strTuKhoa, int intPageIndex, int intPageSize)
        {
            try
            {
                using (var db = new Project_16HCB_CSDLEntities())
                {
                    SqlParameter paTuKhoa = new SqlParameter("@KEYSEARCH", strTuKhoa);
                    SqlParameter paLop = new SqlParameter("@SCHOOLCLASSID", sv._malop);
                    SqlParameter paKhoa = new SqlParameter("@DIVIONID", sv._makhoa);
                    SqlParameter paDaLay = new SqlParameter("@GETFINGER", (sv._dalay >= 0 ? 1 : 0));
                    SqlParameter paPageIndex = new SqlParameter("@PAGEINDEX", intPageIndex);
                    SqlParameter paPageSize = new SqlParameter("@PAGESIZE", intPageSize);

                    var result = db.Database.SqlQuery<SinhVien>("exec sp_timkiemThongTinSinhVien @KEYSEARCH,@SCHOOLCLASSID,@DIVIONID,@GETFINGER,@PAGEINDEX,@PAGESIZE",
                        paTuKhoa,
                        paLop,
                        paKhoa,
                        paDaLay,
                        paPageIndex,
                        paPageSize).ToList();

                    lstSinhVien = result;
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
