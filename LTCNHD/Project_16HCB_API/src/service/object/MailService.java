package service.object;

import java.util.List;

import backend.dal.MailDAL;
import backend.entities.IMail;
import service.interfaces.IMailService;

public class MailService implements IMailService{

	@Override
	public int create(String jsondata) throws Exception {
		// TODO Auto-generated method stub
		return 0;
	}

	@Override
	public int update(String jsondata) throws Exception {
		// TODO Auto-generated method stub
		return 0;
	}

	@Override
	public int delete(String jsondata) throws Exception {
		// TODO Auto-generated method stub
		return 0;
	}

	@Override
	public Object get(String jsondata) throws Exception {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public List getall() throws Exception {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public int themNoiDungGuiMail(IMail im) throws Exception {
		// TODO Auto-generated method stub
		int ketqua = MailDAL.themNoiDungGuiMail(im);
		return ketqua;
	}

	@Override
	public int guiMail(IMail im) throws Exception {
		// TODO Auto-generated method stub
		int ketqua = MailDAL.kiemTraGuiMail(im);
		return ketqua;
	}

	
	
}
