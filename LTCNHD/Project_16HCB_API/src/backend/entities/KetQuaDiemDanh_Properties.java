package backend.entities;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;

@XmlRootElement
public class KetQuaDiemDanh_Properties {

	private int ketqua;

	@XmlElement
	public int getKetqua() {
		return ketqua;
	}

	public void setKetqua(int ketqua) {
		this.ketqua = ketqua;
	}
	
}
