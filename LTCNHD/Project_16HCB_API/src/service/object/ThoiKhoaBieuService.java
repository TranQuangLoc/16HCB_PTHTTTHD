package service.object;


import java.util.List;
import backend.dal.ThoiKhoaBieuDAL;
import backend.entities.IThoiKhoaBieu;
import service.interfaces.IThoiKhoaBieuService;



public class ThoiKhoaBieuService implements IThoiKhoaBieuService {

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
	public Object get(String jsondata) throws Exception {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public List getall() throws Exception {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public List<IThoiKhoaBieu> DSThoiKhoaBieu(int userId) throws Exception {
		// TODO Auto-generated method stub
		List<IThoiKhoaBieu> list = ThoiKhoaBieuDAL.layThoiKhoaBieu(userId);
		return list;
	}

	
}
