package services;

import manager.DAO;
import org.hibernate.Query;


public class TestSrvs extends DAO {

    public static String getName()
    {
        String query = "SELECT name FROM companies WHERE id = :id";
        return (String) getSession().createSQLQuery(query).setInteger("id", 1).list().get(0);
    }

}
