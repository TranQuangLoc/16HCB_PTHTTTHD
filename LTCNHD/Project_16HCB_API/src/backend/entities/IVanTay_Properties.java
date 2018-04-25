package backend.entities;

import java.io.Serializable;
import javax.xml.bind.annotation.XmlRootElement;

@XmlRootElement
public class IVanTay_Properties {
	private String maVanTay;

	public String getMaVanTay() {
		return maVanTay;
	}

	public void setMaVanTay(String maVanTay) {
		this.maVanTay = maVanTay;
	}
	
}
