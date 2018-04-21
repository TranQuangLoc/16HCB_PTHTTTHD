package service.interfaces;

import java.util.List;

public interface IGenericService<T> {
	
    int create(String jsondata) throws Exception;

    int update(String jsondata) throws Exception;

    int delete(String jsondata) throws Exception;

    T get(String jsondata) throws Exception;

    List<T> getall() throws Exception;
}

