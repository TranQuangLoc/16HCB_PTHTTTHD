package backend.entities;

import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;

@XmlRootElement
public class IMail {
	private int _id;
	private String _tieuDe;
	private int _maNguoiGui;
	private int _maNguoiNhan;
    private String _noiDung;
    private String _loaiThu;
    private Date _ngay;
    
	private int userID;
	private String irecipients;


    @XmlElement
	public int get_id() {
		return _id;
	}
	public void set_id(int _id) {
		this._id = _id;
	}
	
	@XmlElement
	public String get_tieuDe() {
		return _tieuDe;
	}
	public void set_tieuDe(String _tieuDe) {
		this._tieuDe = _tieuDe;
	}
	
	@XmlElement
	public int get_maNguoiGui() {
		return _maNguoiGui;
	}
	public void set_maNguoiGui(int _maNguoiGui) {
		this._maNguoiGui = _maNguoiGui;
	}
	
	@XmlElement
	public int get_maNguoiNhan() {
		return _maNguoiNhan;
	}
	public void set_maNguoiNhan(int _maNguoiNhan) {
		this._maNguoiNhan = _maNguoiNhan;
	}
	
	@XmlElement
	public String get_noiDung() {
		return _noiDung;
	}
	public void set_noiDung(String _noiDung) {
		this._noiDung = _noiDung;
	}
	
	@XmlElement
	public String get_loaiThu() {
		return _loaiThu;
	}
	public void set_loaiThu(String _loaiThu) {
		this._loaiThu = _loaiThu;
	}
	
	@XmlElement
	public Date get_ngay() {
		return _ngay;
	}
	public void set_ngay(Date _ngay) {
		this._ngay = _ngay;
	}
    
	@XmlElement
	public int getUserID() {
		return userID;
	}
	public void setUserID(int userID) {
		this.userID = userID;
	}
	
	@XmlElement
	public String getIrecipients() {
		return irecipients;
	}
	public void setIrecipients(String irecipients) {
		this.irecipients = irecipients;
	}
	
	

}
