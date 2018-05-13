package service.interfaces;

import backend.entities.IMail;


public interface IMailService <T> extends IGenericService<T>{
	public int themNoiDungGuiMail(IMail im) throws Exception;
}
