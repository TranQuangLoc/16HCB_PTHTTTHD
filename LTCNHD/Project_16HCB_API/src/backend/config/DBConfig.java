package backend.config;

public class DBConfig {
	private static String m_userid = "sa";
    private static String m_password = "123456";
    private static String m_database = "ATMDB";
    
	public static String getM_userid() {
		return m_userid;
	}
	public static void setM_userid(String m_userid) {
		DBConfig.m_userid = m_userid;
	}
	public static String getM_password() {
		return m_password;
	}
	public static void setM_password(String m_password) {
		DBConfig.m_password = m_password;
	}
	public static String getM_database() {
		return m_database;
	}
	public static void setM_database(String m_database) {
		DBConfig.m_database = m_database;
	}
    
    public static String getConnectionString()
    {
    	return "jdbc:sqlserver://localhost:1433;databaseName=" + m_database + ";CharacterSet=UTF-8";
    }
}
