package service.interfaces;

import java.util.List;

import backend.entities.IThoiKhoaBieu;

public interface IThoiKhoaBieuService<T> extends IGenericService<T> {
	public List<IThoiKhoaBieu> DSThoiKhoaBieu(int userid) throws Exception;
}
