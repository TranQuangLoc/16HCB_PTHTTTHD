using DAO;
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

namespace DangKyMail
{
    public partial class Form1 : Form
    {
        static HttpClient client = new HttpClient();
        static String localhost = "http://localhost:8080/Project_16HCB_API/";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cbb_loaiuser.Items.Add("Sinh Viên");
            cbb_loaiuser.Items.Add("Giáo Viên");
            cbb_loaiuser.Items.Add("NV_PDT");
        }

        private void btn_tao_Click(object sender, EventArgs e)
        {
            InfoMail mailInfo = new InfoMail();
            mailInfo.username = txt_username.Text;
            mailInfo.email = txt_email.Text;
            mailInfo.sdt = txt_sdt.Text;
            mailInfo.cmnd = txt_cmnd.Text;
            mailInfo.ngaysinh = dtp_ngaysinh.Value.ToString("yyyyMMdd");
            mailInfo.diachi = txt_diachi.Text;
            if (cbb_loaiuser.Text.Equals("Sinh Viên"))
            {
                mailInfo.loaiUS = 1;
            }
            else if(cbb_loaiuser.Text.Equals("Giáo Viên"))
            {
                mailInfo.loaiUS = 2;
            }
            else
            {
                mailInfo.loaiUS = 3;
            }
            mailInfo.password_email = txt_passemail.Text;

            String url = localhost + "rest/mail/dangkimail";
            RestfulAPI rs = CreateProductAsync(url, mailInfo);

            if (rs.ketqua == 1)
            {
                MessageBox.Show("Thành công !");
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra!");
            }
        }

        static RestfulAPI CreateProductAsync(String url, InfoMail mailInfo)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            RestfulAPI rs = new RestfulAPI();
            var res = client.PostAsJsonAsync(url, mailInfo).Result;

            if (res.StatusCode == System.Net.HttpStatusCode.OK)
            {
                rs = res.Content.ReadAsAsync<RestfulAPI>().Result;
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
