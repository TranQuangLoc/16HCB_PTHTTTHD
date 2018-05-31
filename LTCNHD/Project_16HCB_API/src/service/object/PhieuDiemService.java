package service.object;

import java.util.List;

import backend.dal.PhieuDiemDAL;
import service.interfaces.IPhieuDiem;

public class PhieuDiemService implements IPhieuDiem{

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
	public int nhanThongTinPhieuDiem(backend.entities.IPhieuDiem pd) throws Exception {
		// TODO Auto-generated method stub
		
		return PhieuDiemDAL.nhanThongTinPhieuDiem(pd);
	}

	@Override
	public List<backend.entities.IPhieuDiem> DanhSachPhieuDiem() throws Exception {
		// TODO Auto-generated method stub
		
		return PhieuDiemDAL.DanhSachPhieuDiem();
	}

	@Override
	public int TraTinPhieuDiem(backend.entities.IPhieuDiem pd) throws Exception {
		// TODO Auto-generated method stub
		return PhieuDiemDAL.TraPhieuDiem(pd);
	}

	@Override
	public List NhanPhieuDiem(int masv) throws Exception {
		// TODO Auto-generated method stub
		return PhieuDiemDAL.NhanPhieuDiem(masv);
	}
	

}
