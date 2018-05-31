package backend.entities;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;

@XmlRootElement
public class IPhieuDiem {
	private int masv;
	private int magv;
	private String tensv;
	private int hocki;
	private int namhoc;
	private String date; 
	private int tinhtrang;
	
	@XmlElement
	public String getDate() {
		return date;
	}

	public void setDate(String date) {
		this.date = date;
	}

	public IPhieuDiem() {
		// TODO Auto-generated constructor stub
	}
	
	@XmlElement
	public int getMasv() {
		return masv;
	}
	public void setMasv(int masv) {
		this.masv = masv;
	}
	
	@XmlElement
	public String getTensv() {
		return tensv;
	}
	public void setTensv(String tensv) {
		this.tensv = tensv;
	}
	
	@XmlElement
	public int getHocki() {
		return hocki;
	}
	public void setHocki(int hocki) {
		this.hocki = hocki;
	}
	
	@XmlElement
	public int getNamhoc() {
		return namhoc;
	}
	public void setNamhoc(int namhoc) {
		this.namhoc = namhoc;
	}

	@XmlElement
	public int getTinhtrang() {
		return tinhtrang;
	}

	public void setTinhtrang(int tinhtrang) {
		this.tinhtrang = tinhtrang;
	}

	@XmlElement
	public int getMagv() {
		return magv;
	}

	public void setMagv(int magv) {
		this.magv = magv;
	}
	
	
	
}
