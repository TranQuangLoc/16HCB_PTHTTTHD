package backend.entities;

import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;

@XmlRootElement
public class IKetQuaDiemDanh {
	private int _id;
	private int _maUser;
	private int _maMH;
	private int _maPhong;
	private Date _ngayHoc;
	private int _loaiUS;
	
	@XmlElement
	public int get_id() {
		return _id;
	}
	public void set_id(int _id) {
		this._id = _id;
	}
	@XmlElement
	public int get_maUser() {
		return _maUser;
	}
	public void set_maUser(int _maUser) {
		this._maUser = _maUser;
	}
	@XmlElement
	public int get_maMH() {
		return _maMH;
	}
	public void set_maMH(int _maMH) {
		this._maMH = _maMH;
	}
	@XmlElement
	public int get_maPhong() {
		return _maPhong;
	}
	public void set_maPhong(int _maPhong) {
		this._maPhong = _maPhong;
	}
	@XmlElement
	public Date get_ngayHoc() {
		return _ngayHoc;
	}
	public void set_ngayHoc(Date _ngayHoc) {
		this._ngayHoc = _ngayHoc;
	}
	@XmlElement
	public int get_loaiUS() {
		return _loaiUS;
	}
	public void set_loaiUS(int _loaiUS) {
		this._loaiUS = _loaiUS;
	}
	
}
