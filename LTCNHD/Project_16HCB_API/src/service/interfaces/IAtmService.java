package service.interfaces;

import java.util.List;

import backend.entities.Atm;

public interface IAtmService <T> extends IGenericService<T>{
	public List<Atm> GetListATM() throws Exception;
	public Atm GetListObjectATM(String id) throws Exception;
}
