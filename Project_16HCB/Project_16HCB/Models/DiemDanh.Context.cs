﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Project_16HCB.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Project_16HCB_CSDLEntities : DbContext
    {
        public Project_16HCB_CSDLEntities()
            : base("name=Project_16HCB_CSDLEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ACCOUNT> ACCOUNTs { get; set; }
        public virtual DbSet<DIEM> DIEMs { get; set; }
        public virtual DbSet<GIAOVIEN> GIAOVIENs { get; set; }
        public virtual DbSet<GIAOVIEN_MONHOC> GIAOVIEN_MONHOC { get; set; }
        public virtual DbSet<HOCKY> HOCKies { get; set; }
        public virtual DbSet<KETQUADIEMDANH> KETQUADIEMDANHs { get; set; }
        public virtual DbSet<KHOA> KHOAs { get; set; }
        public virtual DbSet<LOPHOC> LOPHOCs { get; set; }
        public virtual DbSet<MAIL> MAILs { get; set; }
        public virtual DbSet<MONHOC> MONHOCs { get; set; }
        public virtual DbSet<MONHOC_HOCKY> MONHOC_HOCKY { get; set; }
        public virtual DbSet<PHONG> PHONGs { get; set; }
        public virtual DbSet<SINHVIEN> SINHVIENs { get; set; }
        public virtual DbSet<THOIKHOABIEU> THOIKHOABIEUx { get; set; }
        public virtual DbSet<USER> USERS { get; set; }
        public virtual DbSet<VANTAY> VANTAYs { get; set; }
    }
}
