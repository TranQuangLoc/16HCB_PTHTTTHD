package service.config;

import java.util.List;

import javax.ws.rs.core.Response;


public class ResponseConfig {
	
	
	public static Response OK(Object val)
	{
		return Response.ok(val)
				.header("Access-Control-Allow-Origin", "*")   //.entity(new GenericEntity<ArrayList<Product>>(list) {})
				.header("Access-Control-Allow-Credentials","true")
				.header("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE, OPTIONS, HEAD")
				.build();
	}
	
	
	
	public static Response OK()
	{
		return Response.ok()
				.header("Access-Control-Allow-Origin", "*")   //.entity(new GenericEntity<ArrayList<Product>>(list) {})
				.header("Access-Control-Allow-Credentials","true")
				.header("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE, OPTIONS, HEAD")
				.build();
	}
	
	public static Response SERVER_ERROR ()
	{
		return Response.serverError().build();
	}
	
	public static Response NOT_FOUND()
	{
		return Response.noContent().build();
	}
}
