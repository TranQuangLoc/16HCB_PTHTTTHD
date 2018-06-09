package service.export;

import java.util.List;

import javax.ws.rs.POST;
import javax.ws.rs.Path;
import javax.ws.rs.Produces;
import javax.ws.rs.core.GenericEntity;
import javax.ws.rs.core.MediaType;
import javax.ws.rs.core.Response;

import org.codehaus.jackson.map.ObjectMapper;

import backend.entities.IMail;
import backend.entities.IThoiKhoaBieu;
import backend.entities.IThoiKhoaBieu_Properties;
import service.config.ResponseConfig;
import service.object.ThoiKhoaBieuService;

@Path("thoikhoabieu")
public class ThoiKhoaBieuRestful {
	@POST
	@Produces(MediaType.APPLICATION_JSON)
	@Path("/thoikhoabieu")
	public Response DanhSachThoiKhoaBieu(IThoiKhoaBieu_Properties thoikhoabieu)
	{
		try
		{

			//ObjectMapper mapper = new ObjectMapper();
			//IMail imail = mapper.readValue(jsondata, IMail.class);
			
			ThoiKhoaBieuService im = new ThoiKhoaBieuService();
			List<IThoiKhoaBieu> listTKB = im.DSThoiKhoaBieu(thoikhoabieu.getUserId());
			
			if(listTKB != null){	
				return ResponseConfig.OK(new GenericEntity<List<IThoiKhoaBieu>>(listTKB) {});		
					
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
