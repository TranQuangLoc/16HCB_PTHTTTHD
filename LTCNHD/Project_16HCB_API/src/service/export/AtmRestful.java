package service.export;

import java.util.List;

import javax.ws.rs.Consumes;
import javax.ws.rs.FormParam;
import javax.ws.rs.GET;
import javax.ws.rs.POST;

import javax.ws.rs.Path;
import javax.ws.rs.Produces;
import javax.ws.rs.QueryParam;
import javax.ws.rs.core.GenericEntity;
import javax.ws.rs.core.MediaType;
import javax.ws.rs.core.Response;

import com.sun.media.jfxmedia.Media;

import backend.entities.*;
import service.config.ResponseConfig;
import service.object.AtmService;
@Path("atm")
public class AtmRestful {
	@POST
	@Produces(MediaType.APPLICATION_JSON)
	@Consumes(MediaType.APPLICATION_JSON)
	@Path("/getatmbyid")
	public Response getAtmById(IDATM at)
	{
		try
		{
			System.out.println(at.getId());
			AtmService as = new AtmService();
			Atm us = as.GetListObjectATM(String.valueOf(at.getId()));
					
			if(us != null)
				return ResponseConfig.OK(us);
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
	@Path("/getList")
	public Response getListAtm()
	{
		try
		{
			AtmService as = new AtmService();
			List<Atm> us = as.GetListATM();
					
			if(us != null)
				return ResponseConfig.OK(new GenericEntity<List<Atm>>(us) {});
			else
				return ResponseConfig.NOT_FOUND();
		}
		catch(Exception ex)
		{
			ex.printStackTrace();
			return ResponseConfig.SERVER_ERROR();
		}
	} 
	
	@GET
	@Produces(MediaType.APPLICATION_JSON)
	@Path("/getss")
	public Response getMess()
	{
		try
		{
			
			
				return ResponseConfig.OK("1");
			
		}
		catch(Exception ex)
		{
			ex.printStackTrace();
			return ResponseConfig.SERVER_ERROR();
		}
	} 
}
