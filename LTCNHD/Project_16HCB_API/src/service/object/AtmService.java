package service.object;
import java.util.List;

import org.codehaus.jettison.json.JSONObject;


import backend.dal.AtmDAL;
import backend.entities.*;
import service.interfaces.IAtmService;
public class AtmService implements IAtmService<Atm>{

	@Override
	public int create(String jsondata) throws Exception {
		// TODO Auto-generated method stub
		return 0;
	}

	@Override
	public int update(String jsondata) throws Exception {
		// TODO Auto-generated method stub
		return 0;
	}

	@Override
	public int delete(String jsondata) throws Exception {
		// TODO Auto-generated method stub
		return 0;
	}

	@Override
	public Atm get(String jsondata) throws Exception {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public List<Atm> getall() throws Exception {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public List<Atm> GetListATM() throws Exception {
		//JSONObject jo = new JSONObject(jsondata);	
		List<Atm> list = AtmDAL.GetListATM();
		return list;
		
	}

	@Override
	public Atm GetListObjectATM(String id) throws Exception {
		//JSONObject jo = new JSONObject(jsondata);
		//int atmid = jo.getInt("atmid");			
		Atm atm = AtmDAL.getObjectATM(id);
		return atm;
	}

}
