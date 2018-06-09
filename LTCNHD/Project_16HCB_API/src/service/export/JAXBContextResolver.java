package service.export;

import javax.ws.rs.ext.ContextResolver;
import javax.xml.bind.JAXBContext;
import com.sun.jersey.api.json.JSONConfiguration;
import com.sun.jersey.api.json.JSONJAXBContext;

import backend.entities.*;

/*public class JAXBContextResolver implements ContextResolver<JAXBContext> {

	private JAXBContext context;
    private Class[] types = {
    		IPhieuDiem.class,
    		IKetQuaPhieuDiem_SinhVien.class
	};
    
    public JAXBContextResolver() throws Exception {
        this.context = new JSONJAXBContext(JSONConfiguration.mapped()
        					.arrays("employee").build(), types);
    }
    
	@Override
	public JAXBContext getContext(Class<?> arg0) {
		// TODO Auto-generated method stub
		 System.out.println("TUG CALL");
        for (Class type : types) {
            if (type == arg0) {
                return context;
            }
        }
	        	        
        return null;
	}

}*/
