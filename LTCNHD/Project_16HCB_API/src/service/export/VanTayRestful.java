package service.export;

import javax.ws.rs.Consumes;
import javax.ws.rs.POST;
import javax.ws.rs.Path;
import javax.ws.rs.Produces;
import javax.ws.rs.core.MediaType;
import javax.ws.rs.core.Response;
import backend.entities.IVanTay;
import backend.entities.IVanTay_Properties;
import backend.entities.KetQuaDiemDanh_Properties;
import service.config.ResponseConfig;
import service.object.VanTayService;

@Path("vantay")
public class VanTayRestful {
	
	@POST
	@Produces(MediaType.APPLICATION_JSON)
	@Consumes(MediaType.APPLICATION_JSON)
	@Path("/getvantaybyid")
	public Response layDoiTuongVanTay(IVanTay_Properties vantayPro)
	{
		try
		{
		
			VanTayService ivantay = new VanTayService();
			int ketqua = ivantay.getObjectIVanTay(vantayPro.getMaVanTay());
			KetQuaDiemDanh_Properties ketqua_diemdanh = new KetQuaDiemDanh_Properties();
			ketqua_diemdanh.setKetqua(ketqua);
			if(ketqua == 1)
			{				
				
				
				return ResponseConfig.OK(ketqua_diemdanh);
			}				
			else
			{
				
				return ResponseConfig.OK(ketqua_diemdanh);
				//return ResponseConfig.NOT_FOUND();
			}
				
		}
		catch(Exception ex)
		{
			ex.printStackTrace();
			return ResponseConfig.SERVER_ERROR();
		}
	} 
	
}
