package backend.helpers;
import java.security.*;


/*public class JavaHelpers {

	public static String getMD5(String yourString)
	{
		try
		{
			byte[] bytesOfMessage = yourString.getBytes("UTF-8");
	
			MessageDigest md = MessageDigest.getInstance("MD5");

			byte[] mdbytes = md.digest(bytesOfMessage);
			
			StringBuffer hexString = new StringBuffer();
	    	for (int i=0;i<mdbytes.length;i++) {
	    		String hex=Integer.toHexString(0xff & mdbytes[i]);
	   	     	if(hex.length()==1) hexString.append('0');
	   	     	hexString.append(hex);
	    	}
	    	
	    	return hexString.toString();
			
		}
		catch(Exception ex)
		{
			return "";
		}
	}
}
*/