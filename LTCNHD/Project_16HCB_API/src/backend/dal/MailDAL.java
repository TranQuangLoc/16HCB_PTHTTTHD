package backend.dal;

import java.sql.CallableStatement;
import java.sql.Connection;
import java.sql.ResultSet;

import backend.config.DBContext;
import backend.entities.IMail;
import backend.entities.IMailInfo;

public class MailDAL {
	private static Connection conn = DBContext.getConnect();
	public static int themNoiDungGuiMail(IMail imail)
	{
		int ketqua = 0;
		try
		{
			
			String sql = "{call sp_guiMail (?,?,?,?)}";
			
			CallableStatement pre = conn.prepareCall(sql);            
            pre.setInt(1, imail.getUserID());
            pre.setString(2, imail.getIrecipients());
            pre.setString(3, imail.get_tieuDe());
            pre.setString(4, imail.get_noiDung());
	        ResultSet rs = pre.executeQuery();
	        System.out.println(imail.getUserID());
	        System.out.println(imail.getIrecipients());
	        System.out.println(imail.get_tieuDe());
	        System.out.println(imail.get_noiDung());
	        while(rs.next())
	        {
	        	if (rs.getInt("err") == 0)
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
	
	/*public static int kiemTraGuiMail(IMail imail)

	{
		int ketqua = 0;
		try
		{
			
			
			String sql = "{call sp_guiMail (?,?,?,?)}";
			
			CallableStatement pre = conn.prepareCall(sql);            
            pre.setInt(1, imail.getUserID());
            pre.setString(2, imail.getIrecipients());
            pre.setString(3, imail.get_tieuDe());
            pre.setString(4, imail.get_noiDung());
         
	        ResultSet rs = pre.executeQuery();
	        
	        while(rs.next())
	        {
	        	if (rs.getInt("err") == 0)
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

	}*/
	
	public static int DangKiMail(IMailInfo info)
	{
		int ketqua = 0;
		try
		{
			
			
			String sql = "{call sp_dangKyTK (?,?,?,?,?,?,?,?)}";
			
			CallableStatement pre = conn.prepareCall(sql);            
            pre.setString(1, info.getUsername());
            pre.setString(2, info.getEmail());
            pre.setString(3, info.getSdt());
            pre.setString(4, info.getCmnd());
            pre.setString(5, info.getNgaysinh());
            pre.setString(6, info.getDiachi());
            pre.setInt(7, info.getLoaiUS());
            pre.setString(8, info.getPassword_email());
	        ResultSet rs = pre.executeQuery();
	        
	        while(rs.next())
	        {
	        	if (rs.getInt("err") == 0)
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
