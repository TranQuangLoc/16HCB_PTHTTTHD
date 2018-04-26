package backend.entities;

import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;

@XmlRootElement
public class IVanTay {
	private int _id;
	private int _userId;
	private String _mavanTay;
	private Date _ngayTao;

	
	@XmlElement
	public int get_id() {
		return _id;
	}
	public void set_id(int _id) {
		this._id = _id;
	}
	
	@XmlElement
	public int get_userId() {
		return _userId;
	}
	public void set_userId(int _userId) {
		this._userId = _userId;
	}
	
	@XmlElement
	public String get_mavanTay() {
		return _mavanTay;
	}
	public void set_mavanTay(String _mavanTay) {
		this._mavanTay = _mavanTay;
	}
	
	@XmlElement
	public Date get_ngayTao() {
		return _ngayTao;
	}
	public void set_ngayTao(Date _ngayTao) {
		this._ngayTao = _ngayTao;
	}
}
