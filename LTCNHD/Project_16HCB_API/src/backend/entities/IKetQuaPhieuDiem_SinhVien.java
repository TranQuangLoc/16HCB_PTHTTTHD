package backend.entities;

import java.text.DecimalFormat;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;

@XmlRootElement
public class IKetQuaPhieuDiem_SinhVien {
	private int masv;
	private String tensv;
	private String tenmh;
	private Double diem;
	private int sotc;
	
	public IKetQuaPhieuDiem_SinhVien(){
		
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
	public String getTenmh() {
		return tenmh;
	}
	public void setTenmh(String tenmh) {
		this.tenmh = tenmh;
	}
	
	@XmlElement
	public Double getDiem() {
		return diem;
	}
	public void setDiem(Double diem) {
		this.diem = diem;
	}
	
	@XmlElement
	public int getSotc() {
		return sotc;
	}
	public void setSotc(int sotc) {
		this.sotc = sotc;
	}
	
	
}
