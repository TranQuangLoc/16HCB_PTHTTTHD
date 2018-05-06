package backend.entities;

import javax.xml.bind.annotation.XmlRootElement;

@XmlRootElement
public class KetQuaDiemDanh_Properties {
	private int ketqua;

	public int getKetqua() {
		return ketqua;
	}

	public void setKetqua(int ketqua) {
		this.ketqua = ketqua;
	}
	
}
