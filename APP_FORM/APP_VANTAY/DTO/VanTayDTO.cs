using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class VanTayDTO
    {
        public int id { get; set; }
        public int userId { get; set; }
        public String mavanTay { get; set; }
        public DateTime ngayTao { get; set; }
    }
}
