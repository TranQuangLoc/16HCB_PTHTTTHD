package backend.entities;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
@XmlRootElement
public class Atm {
	private int id;
	private String NameBank;
	private String DiaChi;
	@XmlElement
	public int getId() {
		return id;
	}
	public void setId(int id) {
		this.id = id;
	}
	@XmlElement
	public String getNameBank() {
		return NameBank;
	}
	public void setNameBank(String nameBank) {
		NameBank = nameBank;
	}
	@XmlElement
	public String getDiaChi() {
		return DiaChi;
	}
	public void setDiaChi(String diaChi) {
		DiaChi = diaChi;
	}
	public Atm() {
		super();
	}
	
	
}
