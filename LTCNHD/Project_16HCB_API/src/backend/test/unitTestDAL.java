package backend.test;

import java.util.ArrayList;
import java.util.List;

import org.junit.Assert;
import org.junit.Test;

import backend.dal.*;
import backend.entities.*;


public class unitTestDAL {
	
	//MailDAL
	@Test
	public void testthemNoiDungGuiMail(){
		IMail im = new IMail();
		im.setUserID(2);
		im.set_tieuDe("Đuổi học");
		im.setIrecipients("tranquangloc2906@gmail.com");
		im.set_noiDung("đuổi học");
		int ketqua = MailDAL.themNoiDungGuiMail(im);
	    Assert.assertEquals(1, ketqua);
	}
		
	
	@Test
	public void testDangKiMail(){
		IMailInfo info = new IMailInfo();
		info.setUsername("Nguyễn An Bình");
		info.setEmail("tranquanglocit2906@gmail.com");
		info.setSdt("018237664");
		info.setCmnd("384735743");
		info.setNgaysinh("1988-2-4");
		info.setDiachi("TP HCM");
		info.setLoaiUS(1);
		info.setPassword_email("quangloc@@290694");
		int ketqua = MailDAL.DangKiMail(info);
	    Assert.assertEquals(0, ketqua);
	}
		
	
	//PhieuDiemDAL
	@Test
	public void testnhanThongTinPhieuDiem(){
		IPhieuDiem pd = new IPhieuDiem();
		pd.setMasv(1);
		pd.setTensv("Trần Quang Lộc");
		pd.setHocki(1);
		pd.setNamhoc(2018);//2019
		pd.setDate("2018-05-27");
		int ketqua = PhieuDiemDAL.nhanThongTinPhieuDiem(pd);
	    Assert.assertEquals(1, ketqua);
	}
	
	
	@Test
	public void testDanhSachPhieuDiem(){
		List<IPhieuDiem> list = new ArrayList<IPhieuDiem>();
		list = PhieuDiemDAL.DanhSachPhieuDiem();	
	    Assert.assertEquals(1, list.size());
	}
	
	@Test
	public void testDanhSachPhieuDiem_2(){
		List<IPhieuDiem> list = new ArrayList<IPhieuDiem>();
		list = PhieuDiemDAL.DanhSachPhieuDiem();	
	    Assert.assertEquals(0, list.size());
	}
	
	
	@Test
	public void testTraPhieuDiem(){
		List<IPhieuDiem> list = new ArrayList<IPhieuDiem>();
		list = PhieuDiemDAL.DanhSachPhieuDiem();	
	    Assert.assertEquals(1, list.size());
	}
	
	@Test
	public void testTraPhieuDiem_2(){
		List<IPhieuDiem> list = new ArrayList<IPhieuDiem>();
		list = PhieuDiemDAL.DanhSachPhieuDiem();	
	    Assert.assertEquals(0, list.size());
	}
	
	//ThoiKhoaBieu DAL
	@Test 
	public void testlayThoiKhoaBieu(){
		List<IThoiKhoaBieu> list = new ArrayList<IThoiKhoaBieu>();
		list = ThoiKhoaBieuDAL.layThoiKhoaBieu(1);	
	    Assert.assertEquals(5, list.size());
	}
	
	
	//VanTayDAL
	@Test 
	public void testlayVanTay(){
		int ketqua = VanTayDAL.layVanTay("81dc9bdb52d04dc20036dbd8313ed055");
		Assert.assertEquals(1, ketqua);
	}
	
	
	
}
