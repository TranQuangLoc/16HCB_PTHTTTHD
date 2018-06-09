package backend.test;
import java.util.List;

import javax.ws.rs.core.GenericEntity;
import javax.ws.rs.core.Response;

import org.junit.*;
import org.junit.rules.ExpectedException;

import backend.entities.*;
import service.export.*;
public class unitTest{
	
	//ThoiKhoaBieu Restful
	@Test
	public void testThoiKhoaBieuRestFul() throws Exception{
		ThoiKhoaBieuRestful tkb_res = new ThoiKhoaBieuRestful();
		IThoiKhoaBieu_Properties tkb_pro = new IThoiKhoaBieu_Properties();
		tkb_pro.setUserId(1);
		Response rp = tkb_res.DanhSachThoiKhoaBieu(tkb_pro);
	    Assert.assertEquals(Response.Status.OK.getStatusCode(),rp.getStatus());
	    GenericEntity<List<IThoiKhoaBieu>> list = (GenericEntity<List<IThoiKhoaBieu>>)rp.getEntity();
	    Assert.assertEquals(5, list.getEntity().size());
	  
	}
	
	//Gửi mail
	@Test
	public void testMailRestFul() throws Exception{
		MailResful mail_res = new MailResful();
		Response rp = mail_res.themNoiDungGuiMail("{\"userID\": \"3\", \"_tieuDe\": \"aaaaa\", \"irecipients\": \"tranquangloc2906@gmail.com\", \"_noiDung\": \"aaaaaaa\"}");
	    Assert.assertEquals(Response.Status.OK.getStatusCode(),rp.getStatus());
	    KetQuaDiemDanh_Properties ketqua = (KetQuaDiemDanh_Properties)rp.getEntity();
	    Assert.assertEquals(1, ketqua.getKetqua());
	}
	
	@Test
	public void testMailRestFul_2() throws Exception{
		IMailInfo info  = new IMailInfo();
		MailResful mail_res = new MailResful();
		info.setUsername("Trần Quang Lộc 1");
		info.setEmail("tranquangloc2907@gmail.com");
		info.setSdt("049485777");
		info.setCmnd("12345");
		info.setNgaysinh("1994-06-29");
		info.setDiachi("Quận 5");
		info.setLoaiUS(1);
		info.setPassword_email("quangloc@@2907");
		Response rp = mail_res.DangKiGuiMail(info);
	    Assert.assertEquals(Response.Status.OK.getStatusCode(),rp.getStatus());
	    KetQuaDiemDanh_Properties ketqua = (KetQuaDiemDanh_Properties)rp.getEntity();
	    Assert.assertEquals(1, ketqua.getKetqua());
	    
	}
	
	
	@Test
	public void testDangKiMail() throws Exception{
		MailResful mail_res = new MailResful();
		Response rp = mail_res.themNoiDungGuiMail("{\"userID\": \"99\", \"_tieuDe\": \"aaaaa\", \"irecipients\": \"tranquangloc2906@gmail.com\", \"_noiDung\": \"aaaaaaa\"}");
	    Assert.assertEquals(Response.Status.OK.getStatusCode(),rp.getStatus());
	    KetQuaDiemDanh_Properties ketqua = (KetQuaDiemDanh_Properties)rp.getEntity();
	    Assert.assertEquals(1, ketqua.getKetqua());
	}
	
	//Phieu diem Restful : nhanThongTinPhieuDiem
	@Test
	public void testPhieudiemRestFul_nhanThongTinPhieuDiem() throws Exception{
		PhieuDiemRestful pd_res = new PhieuDiemRestful();
		Response rp = pd_res.nhanThongTinPhieuDiem("{\"masv\": \"1\",\"tensv\": \"Trần Quang Lộc\",\"hocki\": \"1\",\"namhoc\": \"2020\",\"date\": \"2018-05-27\"}");
	    Assert.assertEquals(Response.Status.OK.getStatusCode(),rp.getStatus());
	    KetQuaDiemDanh_Properties ketqua = (KetQuaDiemDanh_Properties)rp.getEntity();
	    Assert.assertEquals(0, ketqua.getKetqua());
	}
	
	//Phieu diem Restful : DanhSachPhieuDiem
	@Test
	public void testPhieudiemRestFul_DanhSachPhieuDiem() throws Exception{
		PhieuDiemRestful pd_res = new PhieuDiemRestful();
		Response rp = pd_res.DanhSachPhieuDiem();
	    Assert.assertEquals(Response.Status.OK.getStatusCode(),rp.getStatus());
	    List<IPhieuDiem> ketqua = (List<IPhieuDiem>)rp.getEntity();
	    Assert.assertEquals(1, ketqua.size());
	  
	}
	
	//Phieu diem Restful : TraPhieuDiem
	@Test
	public void testPhieudiemRestFul_TraPhieuDiem() throws Exception{
		PhieuDiemRestful pd_res = new PhieuDiemRestful();
		IPhieuDiem pd = new IPhieuDiem();
		pd.setMasv(1);
		pd.setHocki(1);
		pd.setMagv(2);
		
		Response rp = pd_res.TraPhieuDiem(pd);
	    Assert.assertEquals(Response.Status.OK.getStatusCode(),rp.getStatus());
	    KetQuaDiemDanh_Properties ketqua = (KetQuaDiemDanh_Properties)rp.getEntity();
	    Assert.assertEquals(1, ketqua.getKetqua());
	}

	@Test
	public void testPhieudiemRestFul_TraPhieuDiem_2() throws Exception{
		PhieuDiemRestful pd_res = new PhieuDiemRestful();
		IPhieuDiem pd = new IPhieuDiem();
		pd.setMasv(99);
		pd.setHocki(1);
		pd.setMagv(2);
		
		Response rp = pd_res.TraPhieuDiem(pd);
	    Assert.assertEquals(Response.Status.OK.getStatusCode(),rp.getStatus());
	    KetQuaDiemDanh_Properties ketqua = (KetQuaDiemDanh_Properties)rp.getEntity();
	    Assert.assertEquals(1, ketqua.getKetqua());
	}

	//Phieu diem Restful : nhanPhieuDiem
	@Test
	public void testPhieudiemRestFul_nhanPhieuDiem() throws Exception{
		PhieuDiemRestful pd_res = new PhieuDiemRestful();
		IPhieuDiem pd = new IPhieuDiem();
		pd.setMasv(1);	
		Response rp = pd_res.nhanPhieuDiem(pd);
	    Assert.assertEquals(Response.Status.OK.getStatusCode(),rp.getStatus());
	    GenericEntity<List<IThoiKhoaBieu>> list = (GenericEntity<List<IThoiKhoaBieu>>)rp.getEntity();
	    Assert.assertEquals(4, list.getEntity().size());
	}
	
	@Test
	public void testPhieudiemRestFul_nhanPhieuDiem_2() throws Exception{
		PhieuDiemRestful pd_res = new PhieuDiemRestful();
		IPhieuDiem pd = new IPhieuDiem();
		pd.setMasv(99);	
		Response rp = pd_res.nhanPhieuDiem(pd);
	    Assert.assertEquals(Response.Status.OK.getStatusCode(),rp.getStatus());
	    GenericEntity<List<IThoiKhoaBieu>> list = (GenericEntity<List<IThoiKhoaBieu>>)rp.getEntity();
	    Assert.assertEquals(2, list.getEntity().size());
	}
	
	//VanTayRestFul : layDoiTuongVanTay
	@Test
	public void layDoiTuongVanTay(){
		VanTayRestful vtr = new VanTayRestful();
		IVanTay_Properties vantayPro = new IVanTay_Properties();
		vantayPro.setMaVanTay("81DC9BDB52D04DC20036DBD8313ED055");
		Response rp = vtr.layDoiTuongVanTay(vantayPro);
	    Assert.assertEquals(Response.Status.OK.getStatusCode(),rp.getStatus());
	    KetQuaDiemDanh_Properties ketqua = (KetQuaDiemDanh_Properties)rp.getEntity();
	    Assert.assertEquals(1, ketqua.getKetqua());
	}
}
