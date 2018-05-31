package backend.dal;

import java.sql.CallableStatement;
import java.sql.Connection;
import java.sql.ResultSet;
import java.util.ArrayList;
import java.util.List;

import backend.config.DBContext;
import backend.entities.IKetQuaPhieuDiem_SinhVien;
import backend.entities.IMail;
import backend.entities.IPhieuDiem;

public class PhieuDiemDAL {
	private static Connection conn = DBContext.getConnect();
	public static int nhanThongTinPhieuDiem(IPhieuDiem pd)
	{
		int ketqua = 0;
		try
		{
			
			
			String sql = "{call sp_taophieudiem (?,?,?)}";
			
			CallableStatement pre = conn.prepareCall(sql);            
            pre.setInt(1, pd.getMasv());
            pre.setInt(2, pd.getHocki());
            pre.setInt(3, pd.getNamhoc());
	        ResultSet rs = pre.executeQuery();
	        
	        while(rs.next())
	        {
	        	if (rs.getInt("err") == 0)
	        	{
	        		 
	        		ketqua = 1;
	        			         	            		           
	        	}
	        	      
	        }
		}
		catch(Exception ex)
		{
			//System.out.println("exc");
			ex.printStackTrace();
			
		}
		
		return ketqua;

	}
	
	public static List<IPhieuDiem> DanhSachPhieuDiem()

	{
		int ketqua = 0;
		List<IPhieuDiem> list = new ArrayList<IPhieuDiem>();
		try
		{
			
			
			String sql = "{call sp_danhsachphieudiem}";
			
			CallableStatement pre = conn.prepareCall(sql);                  
	        ResultSet rs = pre.executeQuery();
	        
	        while(rs.next())
	        {
	        	if (rs.getInt("err") == 0)
	        	{
	        		 
	        		IPhieuDiem pd = new IPhieuDiem();
	        		pd.setMasv(rs.getInt("masv"));
	        		pd.setTensv(rs.getString("tensv"));
	        		pd.setHocki(rs.getInt("hocki"));
	        		pd.setNamhoc(rs.getInt("namhoc"));
	        		pd.setTinhtrang(rs.getInt("tinhtrang"));
	        		
	        		
	        		list.add(pd);
	        			         	            		           
	        	}
	        	      
	        }
		}
		catch(Exception ex)
		{
			//System.out.println("exc");
			ex.printStackTrace();
			
		}
		
		return list;

	}
	
	public static int TraPhieuDiem(IPhieuDiem pd)
	{
		int ketqua = 0;
		try
		{
			
			
			String sql = "{call sp_thongtinxulyphieudiem (?,?,?)}";
			
			CallableStatement pre = conn.prepareCall(sql);            
            pre.setInt(1, pd.getMasv());
            pre.setInt(2, pd.getHocki());
            pre.setInt(3, pd.getMagv());
	        ResultSet rs = pre.executeQuery();
	        
	        while(rs.next())
	        {
	        	if (rs.getInt("err") == 0)
	        	{
	        		 
	        		ketqua = 1;
	        			         	            		           
	        	}
	        	      
	        }
		}
		catch(Exception ex)
		{
			//System.out.println("exc");
			ex.printStackTrace();
			
		}
		
		return ketqua;

	}
	
	public static List<IKetQuaPhieuDiem_SinhVien> NhanPhieuDiem(int masv)

	{
		
		List<IKetQuaPhieuDiem_SinhVien> list = new ArrayList<IKetQuaPhieuDiem_SinhVien>();
		try
		{
			
			
			String sql = "{call sp_nhanphieudiem(?)}";
			
			CallableStatement pre = conn.prepareCall(sql);  
			pre.setInt(1, masv);
	        ResultSet rs = pre.executeQuery();
	        
	        while(rs.next())
	        {
	        	if (rs.getInt("err") == 0)
	        	{
	        		 
	        		IKetQuaPhieuDiem_SinhVien pd_sv = new IKetQuaPhieuDiem_SinhVien();
	        		pd_sv.setMasv(rs.getInt("masv"));
	        		pd_sv.setTensv(rs.getString("tensv"));
	        		pd_sv.setTenmh(rs.getString("tenmh"));
	        		pd_sv.setDiem(rs.getDouble("diem"));
	        		pd_sv.setSotc(rs.getInt("sotc"));
	        		
	        		
	        		list.add(pd_sv);
	        			         	            		           
	        	}
	        	      
	        }
		}
		catch(Exception ex)
		{
			//System.out.println("exc");
			ex.printStackTrace();
			
		}
		
		return list;

	}
}
