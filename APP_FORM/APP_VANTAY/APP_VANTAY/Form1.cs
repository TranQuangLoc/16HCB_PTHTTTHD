using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APP_VANTAY
{
    public partial class Form1 : Form
    {
        static HttpClient client = new HttpClient();
        static String localhost = "http://localhost:8080/Project_16HCB_API/";
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_quet_Click(object sender, EventArgs e)
        {
            VanTayDTO vantay = new VanTayDTO();
            vantay.mavanTay = CreateMD5.MD5Hash(txt_ma.Text);
            String url = localhost + "rest/vantay/getvantaybyid";
            ResultAPI rs = CreateProductAsync(url,vantay);
            if (rs != null)
            {
                if (Int32.Parse(rs.ketqua) >= 3)
                {
                    MessageBox.Show("Đã check thẻ quá 3 lần!");
                }
                else
                {
                    MessageBox.Show("OK!");
                }
            }
            
            /////
        }

        static  ResultAPI CreateProductAsync(String url,VanTayDTO vantay)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            ResultAPI rs = new ResultAPI() ;
            var res = client.PostAsJsonAsync(url, new { maVanTay = vantay.mavanTay}).Result;
          
            if (res.StatusCode == System.Net.HttpStatusCode.OK)
            {
                rs = res.Content.ReadAsAsync<ResultAPI>().Result;
               
                
                //DataUserLogin.MaTaiKhoan = res.Content.ReadAsAsync<string>().Result;

                //if (DataUserLogin.MaTaiKhoan.Equals("-1"))
                //{
                //    MessageBox.Show("Mật khẩu hoặc tên đăng nhập không đúng!");
                //}
                //else
                //{
                //    Form1 frm = new Form1();
                //    this.Hide();
                //    frm.ShowDialog();

                //    this.Dispose();
                //}
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra!");
            }
            return rs;
        }

        
    }
}
