package service.object;

import java.util.List;

import backend.dal.VanTayDAL;
import backend.entities.IVanTay;
import service.interfaces.IVanTayService;

public class VanTayService implements IVanTayService{

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
	public IVanTay getObjectIVanTay(String maVanTay) throws Exception {
		// TODO Auto-generated method stub
		IVanTay vanTay = (IVanTay) VanTayDAL.layVanTay(maVanTay);
		return vanTay;
	}

	@Override
	public int themKetQuaDiemDanh(String maVanTay) throws Exception {
		// TODO Auto-generated method stub
		return 0;
	}

}
