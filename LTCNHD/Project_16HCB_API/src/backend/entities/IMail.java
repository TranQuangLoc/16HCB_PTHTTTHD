package backend.entities;

import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;

@XmlRootElement
public class IMail {
	
	private String _tieuDe;
    private String _noiDung; 
	private int userID;
	private String irecipients;
	
    public IMail() {
		// TODO Auto-generated constructor stub
	}
    
	@XmlElement
	public String get_tieuDe() {
		return _tieuDe;
	}
	public void set_tieuDe(String _tieuDe) {
		this._tieuDe = _tieuDe;
	}
	
	
	
	@XmlElement
	public String get_noiDung() {
		return _noiDung;
	}
	public void set_noiDung(String _noiDung) {
		this._noiDung = _noiDung;
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
