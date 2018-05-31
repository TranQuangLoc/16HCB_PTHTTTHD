package service.interfaces;

import java.util.List;

public interface IPhieuDiem <T> extends IGenericService<T>{
	public int nhanThongTinPhieuDiem(backend.entities.IPhieuDiem pd) throws Exception;
	public List<backend.entities.IPhieuDiem> DanhSachPhieuDiem() throws Exception;
	public int TraTinPhieuDiem(backend.entities.IPhieuDiem pd) throws Exception;
	public List<backend.entities.IPhieuDiem> NhanPhieuDiem(int masv) throws Exception;
}
