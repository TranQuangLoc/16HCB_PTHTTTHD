using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SinhVien
    {
        public int _mssv { get; set; }
        public int _userid { get; set; }
        public string _hedaotao { get; set; }
        public string _ngaybatdau { get; set; }
        public string _trangthai { get; set; }
        public int _malop { get; set; }
        public string _tenlop { get; set; }
        public string _username { get; set; }
        public string _email { get; set; }
        public string _sdt { get; set; }
        public string _cmnd { get; set; }
        public string _ngaysinh { get; set; }
        public string _diachi { get; set; }
        public bool _daxoa { get; set; }
        public List<VanTay> _lstVanTay { get; set; }
        public int _dalay { get; set; }
        public int _stt { get; set; }
        public int _sodong { get; set; }
        public int _makhoa { get; set; }
        public string _tenkhoa { get; set; }
    }
}
