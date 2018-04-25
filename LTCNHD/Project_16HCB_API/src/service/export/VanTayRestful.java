package service.export;

import javax.ws.rs.Consumes;
import javax.ws.rs.POST;
import javax.ws.rs.Path;
import javax.ws.rs.Produces;
import javax.ws.rs.core.MediaType;
import javax.ws.rs.core.Response;
import backend.entities.IVanTay;
import backend.entities.IVanTay_Properties;
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
			IVanTay vanTay = ivantay.getObjectIVanTay(vantayPro.getMaVanTay());
					
			if(vanTay != null)
			{				
				System.out.println("Lấy thành công");
				return ResponseConfig.OK(vanTay);
			}				
			else
			{
				System.out.println("Lấy thất bại");
				return ResponseConfig.NOT_FOUND();
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
	@Consumes(MediaType.APPLICATION_JSON)
	@Path("/themketquadiemdanh")
	public Response themKetquaDiemDanh(String maVanTay)
	{
		try
		{
			System.out.println(maVanTay);
			VanTayService ivantay = new VanTayService();
			IVanTay vanTay = ivantay.getObjectIVanTay(maVanTay);
					
			if(vanTay != null)
				return ResponseConfig.OK("themThanhCong");
			else
				return ResponseConfig.NOT_FOUND();
		}
		catch(Exception ex)
		{
			ex.printStackTrace();
			return ResponseConfig.SERVER_ERROR();
		}
	} 
}
