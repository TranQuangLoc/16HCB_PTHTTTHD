package service.export;

import javax.ws.rs.Consumes;
import javax.ws.rs.POST;
import javax.ws.rs.Path;
import javax.ws.rs.Produces;
import javax.ws.rs.core.MediaType;
import javax.ws.rs.core.Response;

import org.codehaus.jackson.map.ObjectMapper;

import backend.entities.IMail;
import backend.entities.IMailInfo;
import backend.entities.IVanTay_Properties;
import backend.entities.KetQuaDiemDanh_Properties;
import service.config.ResponseConfig;
import service.object.MailService;
import service.object.VanTayService;

@Path("mail")
public class MailResful {
	@POST
	@Produces(MediaType.APPLICATION_JSON)
	@Path("/guimail")
	public Response themNoiDungGuiMail(String jsondata)
	{
		try
		{


			ObjectMapper mapper = new ObjectMapper();
			IMail imail = mapper.readValue(jsondata, IMail.class);
			MailService im = new MailService();
			int ketquacheck = im.themNoiDungGuiMail(imail);
			if(ketquacheck == 1){
				
				
				KetQuaDiemDanh_Properties ketqua_diemdanh = new KetQuaDiemDanh_Properties();
				ketqua_diemdanh.setKetqua(ketquacheck);
				return ResponseConfig.OK(ketqua_diemdanh);
				
					
			}else{
				System.out.println("FAILD");
				KetQuaDiemDanh_Properties ketqua_diemdanh = new KetQuaDiemDanh_Properties();
				ketqua_diemdanh.setKetqua(ketquacheck);
				return ResponseConfig.OK(ketqua_diemdanh);
				
			}
			
		}
		catch(Exception ex)
		{
			ex.printStackTrace();
			return ResponseConfig.SERVER_ERROR();
		}
	} 
	
	@POST
	@Produces(MediaType.APPLICATION_JSON)
	@Path("/dangkimail")
	public Response DangKiGuiMail(IMailInfo info)
	{
		try
		{
		
			MailService im = new MailService();
			int ketquacheck = im.DangKiMail(info);
			if(ketquacheck == 1){
							
				KetQuaDiemDanh_Properties ketqua_diemdanh = new KetQuaDiemDanh_Properties();
				ketqua_diemdanh.setKetqua(ketquacheck);
						
				return ResponseConfig.OK(ketqua_diemdanh);
				
					
			}else{
				System.out.println("FAILD");
				return ResponseConfig.NOT_FOUND();
			}
			
		}
		catch(Exception ex)
		{
			ex.printStackTrace();
			return ResponseConfig.SERVER_ERROR();
		}
	} 
}
