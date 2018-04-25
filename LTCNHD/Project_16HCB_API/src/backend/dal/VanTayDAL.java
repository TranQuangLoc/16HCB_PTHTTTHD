package backend.dal;

import java.sql.CallableStatement;
import java.sql.Connection;
import java.sql.ResultSet;


import backend.config.DBContext;

import backend.entities.IVanTay;

public class VanTayDAL {
	private static Connection conn = DBContext.getConnect();
	public static IVanTay layVanTay(String maVanTay)

	{
		IVanTay vanTay = null;
		try
		{
			
			String sql = "{call sp_getVanTay (?)}";
			
			CallableStatement pre = conn.prepareCall(sql);            
            pre.setString(1, maVanTay);
	        
	        ResultSet rs = pre.executeQuery();
	        
	        while(rs.next())
	        {
	        	if (rs.getInt("err") == 0)
	        	{
	        		vanTay = new IVanTay();        
	        		vanTay.set_id(rs.getInt("_id"));
	        		vanTay.set_userId(rs.getInt("_userId"));
	        				         	            		           
	        	}
	        	      
	        }
		}
		catch(Exception ex)
		{
			//System.out.println("exc");
			ex.printStackTrace();
			
		}
		
		return vanTay;

	}
	
	public static int themKetQuadiemDanh(int mssv, int maMH, int maPhong)

	{
		int ketqua = 0;
		try
		{
			
			String sql = "{call sp_themKetQuaDiemDanh (?,?,?)}";
			
			//Truyền param cho store
			CallableStatement pre = conn.prepareCall(sql);            
            pre.setInt(1, mssv);
            pre.setInt(2, maMH);
            pre.setInt(3, maPhong);
            
            System.out.println(sql);
	        ResultSet rs = pre.executeQuery();
	        
	        while(rs.next())
	        {
	        	//Thêm thành công
	        	if (rs.getInt("kq") == 1)
	        	{
	        		
	        		ketqua = rs.getInt("kq");	
	        				         	            		           
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
	
}
