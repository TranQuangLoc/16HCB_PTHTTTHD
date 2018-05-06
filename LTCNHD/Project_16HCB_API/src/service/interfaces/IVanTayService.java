package service.interfaces;

import backend.entities.IVanTay;

public interface IVanTayService <T> extends IGenericService<T>{
	public int getObjectIVanTay (String maVanTay) throws Exception;
	
}
