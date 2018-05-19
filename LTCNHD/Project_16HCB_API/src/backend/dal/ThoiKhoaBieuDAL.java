package backend.dal;

import java.sql.CallableStatement;
import java.sql.Connection;
import java.sql.ResultSet;
import java.util.ArrayList;
import java.util.List;

import backend.config.DBContext;
import backend.entities.IThoiKhoaBieu;

public class ThoiKhoaBieuDAL {
	private static Connection conn = DBContext.getConnect();
	public static List<IThoiKhoaBieu> layThoiKhoaBieu(int userId)
	{
			List<IThoiKhoaBieu> list = new ArrayList<IThoiKhoaBieu>();
		try
		{
			
			String sql = "{call sp_xemThoiKhoaBieu (?)}";
			
			CallableStatement pre = conn.prepareCall(sql);            
            pre.setInt(1, userId);
	        
	        ResultSet rs = pre.executeQuery();
	        
	        while(rs.next())
	        {
	        	if (rs.getInt("err") == 0)
	        	{
	        		IThoiKhoaBieu tkb = new IThoiKhoaBieu();
		            
	        		tkb.setThu(rs.getInt("thu"));
	        		tkb.setNgayBatDau(rs.getString("ngayBatDau"));
	        		tkb.setNgayKetThuc(rs.getString("ngayKetThuc"));
	        		tkb.setMaPhong(rs.getInt("maPhong"));
		            
		            list.add(tkb);
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
