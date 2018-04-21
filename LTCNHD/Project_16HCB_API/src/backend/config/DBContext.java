package backend.config;

import java.sql.Connection;
import java.sql.DriverManager;

public class DBContext {
  
    public static Connection getConnect()
    {
        try {
        	
        	//lay thong tin cau hinh server sql
        	String db_connect_string = DBConfig.getConnectionString();
        	String db_userid = DBConfig.getM_userid();
        	String db_password = DBConfig.getM_password();
        	
        	//tao ket noi den server
            Class.forName("com.microsoft.sqlserver.jdbc.SQLServerDriver");
            Connection conn = DriverManager.getConnection(db_connect_string,db_userid, db_password);
            
            if (conn != null)
            {
                System.out.println("connect success");
                return conn;
            }

        } catch (Exception e) {
           e.printStackTrace();
        }
        
        return null;
   } 
}
