package service.export;

import javax.ws.rs.Consumes;
import javax.ws.rs.POST;
import javax.ws.rs.Path;
import javax.ws.rs.Produces;
import javax.ws.rs.core.MediaType;
import javax.ws.rs.core.Response;

import backend.entities.IMail;
import backend.entities.IVanTay_Properties;
import backend.entities.KetQuaDiemDanh_Properties;
import service.config.ResponseConfig;
import service.object.MailService;
import service.object.VanTayService;

@Path("mail")
public class MailResful {
	@POST
	@Produces(MediaType.APPLICATION_JSON)
	@Consumes(MediaType.APPLICATION_JSON)
	@Path("/guimail")
	public Response themNoiDungGuiMail(IMail imail)
	{
		try
		{
			
			MailService im = new MailService();
			int ketquacheck = im.guiMail(imail);
			if(ketquacheck == 1){
				int ketqua = im.themNoiDungGuiMail(imail);
				
				KetQuaDiemDanh_Properties ketqua_diemdanh = new KetQuaDiemDanh_Properties();
				ketqua_diemdanh.setKetqua(ketqua);
				if(ketqua == 1)
				{				
					
					System.out.println("Lấy thành công");
					return ResponseConfig.OK(ketqua_diemdanh);
				}				
				else
				{
					System.out.println("Lấy thất bại");
					return ResponseConfig.NOT_FOUND();
				}
					
			}else{
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
