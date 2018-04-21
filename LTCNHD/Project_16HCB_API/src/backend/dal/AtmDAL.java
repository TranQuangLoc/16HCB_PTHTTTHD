package backend.dal;

import java.sql.CallableStatement;
import java.sql.Connection;
import java.sql.ResultSet;
import java.sql.Statement;
import java.util.ArrayList;
import java.util.List;

import backend.config.DBContext;

import backend.entities.Atm;


public class AtmDAL {
	private static Connection conn = DBContext.getConnect();
	public static List<Atm> GetListATM()

	{
		List<Atm> list = new ArrayList<Atm>();
		try
		{
			
			String sql = "{call sp_getListATM}";
			CallableStatement pre = conn.prepareCall(sql);            
            //pre.setString(1, token);
	        
	        ResultSet rs = pre.executeQuery();
	        
	        while(rs.next())
	        {
	        	if (rs.getInt("err") == 0)
	        	{
	        		Atm m = new Atm();
		            
		            m.setDiaChi(rs.getString("DiaChi"));
		            m.setId(rs.getInt("id"));
		            m.setNameBank(rs.getString("NameBank"));
		            
		            
		            list.add(m);
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
	
	public static Atm getObjectATM(String id)
	{
		Atm m = new Atm();
		try
		{
			
			/*System.out.println("ID_1234   " + atmid);
			int id = Integer.parseInt(atmid);*/
			System.out.println("ID_   " + id);
			String sql = "select * from [Bank] where id =" + id ;
	        Statement st = conn.createStatement();
	        
	        ResultSet rs = st.executeQuery(sql);
	        
	        if(rs.next())
	        {
	        	m.setId(rs.getInt("id"));
	        	m.setDiaChi(rs.getString("DiaChi"));	    
	            m.setNameBank(rs.getString("NameBank"));
	           
	        }
	     
	        return m;
		}
		catch(Exception ex)
		{
			//System.out.println("exc");
			ex.printStackTrace();
			return m;
		}

	}
	
}
