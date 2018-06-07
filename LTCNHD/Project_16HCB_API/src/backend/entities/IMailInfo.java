package backend.entities;

import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
@XmlRootElement
public class IMailInfo {
	private String username ;
	private String email ;
	private String sdt ;
	private String cmnd ;
	private String ngaysinh ;
	private String diachi ;
	private int loaiUS ;
	private String password_email ;
	
	@XmlElement
	public String getUsername() {
		return username;
	}
	public void setUsername(String username) {
		this.username = username;
	}
	
	@XmlElement
	public String getEmail() {
		return email;
	}
	public void setEmail(String email) {
		this.email = email;
	}
	
	@XmlElement
	public String getSdt() {
		return sdt;
	}
	public void setSdt(String sdt) {
		this.sdt = sdt;
	}
	
	@XmlElement
	public String getCmnd() {
		return cmnd;
	}
	public void setCmnd(String cmnd) {
		this.cmnd = cmnd;
	}
	
	@XmlElement
	public String getNgaysinh() {
		return ngaysinh;
	}
	public void setNgaysinh(String ngaysinh) {
		this.ngaysinh = ngaysinh;
	}
	
	@XmlElement
	public String getDiachi() {
		return diachi;
	}
	public void setDiachi(String diachi) {
		this.diachi = diachi;
	}
	
	@XmlElement
	public int getLoaiUS() {
		return loaiUS;
	}
	public void setLoaiUS(int loaiUS) {
		this.loaiUS = loaiUS;
	}
	
	@XmlElement
	public String getPassword_email() {
		return password_email;
	}
	public void setPassword_email(String password_email) {
		this.password_email = password_email;
	}
	
	
}
