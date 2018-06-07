package service.interfaces;

import backend.entities.IMail;
import backend.entities.IMailInfo;


public interface IMailService <T> extends IGenericService<T>{
	public int themNoiDungGuiMail(IMail im) throws Exception;
	public int DangKiMail(IMailInfo info) throws Exception;
}
