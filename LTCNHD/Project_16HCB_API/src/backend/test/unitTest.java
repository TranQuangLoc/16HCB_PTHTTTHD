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
	/*@Test
	public void testThoiKhoaBieuRestFul() throws Exception{
		ThoiKhoaBieuRestful tkb_res = new ThoiKhoaBieuRestful();
		IThoiKhoaBieu_Properties tkb_pro = new IThoiKhoaBieu_Properties();
		tkb_pro.setUserId(1);
		Response rp = tkb_res.DanhSachThoiKhoaBieu(tkb_pro);
	    Assert.assertEquals(Response.Status.OK.getStatusCode(),rp.getStatus());
	    GenericEntity<List<IThoiKhoaBieu>> list = (GenericEntity<List<IThoiKhoaBieu>>)rp.getEntity();
	    Assert.assertEquals(5, list.getEntity().size());
	  
	}*/
	
	//Gửi mail
	/*@Test
	public void testMailRestFul() throws Exception{
		MailResful mail_res = new MailResful();
		Response rp = mail_res.themNoiDungGuiMail("{\"userID\": \"3\", \"_tieuDe\": \"aaaaa\", \"irecipients\": \"tranquangloc2906@gmail.com\", \"_noiDung\": \"aaaaaaa\"}");
	    Assert.assertEquals(Response.Status.OK.getStatusCode(),rp.getStatus());
	    KetQuaDiemDanh_Properties ketqua = (KetQuaDiemDanh_Properties)rp.getEntity();
	    Assert.assertEquals(1, ketqua.getKetqua());
	  
	}*/
	
	//Phieu diem Restful : nhanThongTinPhieuDiem
	/*@Test
	public void testPhieudiemRestFul_nhanThongTinPhieuDiem() throws Exception{
		PhieuDiemRestful pd_res = new PhieuDiemRestful();
		Response rp = pd_res.nhanThongTinPhieuDiem("{\"masv\": \"1\",\"tensv\": \"Trần Quang Lộc\",\"hocki\": \"1\",\"namhoc\": \"2020\",\"date\": \"2018-05-27\"}");
	    Assert.assertEquals(Response.Status.OK.getStatusCode(),rp.getStatus());
	    KetQuaDiemDanh_Properties ketqua = (KetQuaDiemDanh_Properties)rp.getEntity();
	    Assert.assertEquals(1, ketqua.getKetqua());
	  
	}*/
	
	//Phieu diem Restful : DanhSachPhieuDiem
	/*@Test
	public void testPhieudiemRestFul_DanhSachPhieuDiem() throws Exception{
		PhieuDiemRestful pd_res = new PhieuDiemRestful();
		Response rp = pd_res.DanhSachPhieuDiem();
	    Assert.assertEquals(Response.Status.OK.getStatusCode(),rp.getStatus());
	    List<IPhieuDiem> ketqua = (List<IPhieuDiem>)rp.getEntity();
	    Assert.assertEquals(1, ketqua.size());
	  
	}*/
	
	//Phieu diem Restful : TraPhieuDiem
	/*@Test
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
	}*/
	
	//Phieu diem Restful : nhanPhieuDiem
	/*@Test
	public void testPhieudiemRestFul_nhanPhieuDiem() throws Exception{
		PhieuDiemRestful pd_res = new PhieuDiemRestful();
		IPhieuDiem pd = new IPhieuDiem();
		pd.setMasv(1);	
		Response rp = pd_res.nhanPhieuDiem(pd);
	    Assert.assertEquals(Response.Status.OK.getStatusCode(),rp.getStatus());
	    GenericEntity<List<IThoiKhoaBieu>> list = (GenericEntity<List<IThoiKhoaBieu>>)rp.getEntity();
	    Assert.assertEquals(4, list.getEntity().size());
	}*/
	
	
}
