package service.export;

import java.util.ArrayList;
import java.util.List;

import javax.ws.rs.GET;
import javax.ws.rs.POST;
import javax.ws.rs.Path;
import javax.ws.rs.Produces;
import javax.ws.rs.core.GenericEntity;
import javax.ws.rs.core.MediaType;
import javax.ws.rs.core.Response;

import org.codehaus.jackson.map.ObjectMapper;

import backend.entities.Atm;
import backend.entities.IKetQuaPhieuDiem_SinhVien;
import backend.entities.IPhieuDiem;
import backend.entities.IThoiKhoaBieu;
import backend.entities.KetQuaDiemDanh_Properties;
import service.config.ResponseConfig;
import service.object.AtmService;
import service.object.PhieuDiemService;

@Path("phieudiem")
public class PhieuDiemRestful {
	@POST
	@Produces(MediaType.APPLICATION_JSON)
	@Path("/layphieudiem")
	public Response nhanThongTinPhieuDiem(String jsondata)
	{
		try
		{


			ObjectMapper mapper = new ObjectMapper();
			IPhieuDiem pd = mapper.readValue(jsondata, IPhieuDiem.class);
			PhieuDiemService im = new PhieuDiemService();
			int ketquacheck = im.nhanThongTinPhieuDiem(pd);
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
	
	@GET
	@Produces(MediaType.APPLICATION_JSON)
	@Path("/danhsachphieudiem")
	public Response DanhSachPhieuDiem()
	{
		
		PhieuDiemService pd = new PhieuDiemService();
		List<IPhieuDiem> list = new ArrayList<IPhieuDiem>();
		try
		{
			list = pd.DanhSachPhieuDiem();		
			list.add(new IPhieuDiem());
			if(list != null)
			{
					return ResponseConfig.OK(new GenericEntity<List<IPhieuDiem>>(list) {});
			}
				
			else
				return ResponseConfig.NOT_FOUND();
		}
		catch(Exception ex)
		{
			ex.printStackTrace();
			return ResponseConfig.SERVER_ERROR();
		}
									
	} 
	
	@POST
	@Produces(MediaType.APPLICATION_JSON)
	@Path("/traphieudiem")
	public Response TraPhieuDiem(IPhieuDiem pd)
	{
		try
		{

			PhieuDiemService im = new PhieuDiemService();
			int ketquacheck = im.TraTinPhieuDiem(pd);
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
	
	@POST
	@Produces(MediaType.APPLICATION_JSON)
	@Path("/nhanphieudiem")
	public Response nhanPhieuDiem(IPhieuDiem pd)
	{
		try
		{
			
			PhieuDiemService im = new PhieuDiemService();
			
			List<IKetQuaPhieuDiem_SinhVien> listKetqua = im.NhanPhieuDiem(pd.getMasv());
			
			if(listKetqua.size()  > 0){
				
				return ResponseConfig.OK(new GenericEntity<List<IKetQuaPhieuDiem_SinhVien>>((List<IKetQuaPhieuDiem_SinhVien>)listKetqua) {});	
				
							
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
