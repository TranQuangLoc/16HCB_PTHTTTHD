package service.interfaces;

import backend.entities.IVanTay;

public interface IVanTayService <T> extends IGenericService<T>{
	public IVanTay getObjectIVanTay (String maVanTay) throws Exception;
	public int themKetQuaDiemDanh (String maVanTay) throws Exception;
}
