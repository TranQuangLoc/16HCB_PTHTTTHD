package backend.dal;

import java.sql.CallableStatement;
import java.sql.Connection;
import java.sql.ResultSet;


import backend.config.DBContext;

import backend.entities.IVanTay;

public class VanTayDAL {
	private static Connection conn = DBContext.getConnect();
	public static int layVanTay(String maVanTay)

	{
		int ketqua = 0;
		try
		{
			
			String sql = "{call sp_getVanTay (?)}";
			
			CallableStatement pre = conn.prepareCall(sql);            
            pre.setString(1, maVanTay);
	        
	        ResultSet rs = pre.executeQuery();
	        
	        while(rs.next())
	        {
	        	ketqua = rs.getInt("kq");        	      
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
