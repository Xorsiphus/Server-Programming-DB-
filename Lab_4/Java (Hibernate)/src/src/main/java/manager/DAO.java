package manager;

import org.hibernate.Session;
import org.hibernate.SessionFactory;
import org.hibernate.Transaction;
import org.hibernate.cfg.Configuration;
import org.hibernate.service.ServiceRegistry;
import org.hibernate.service.ServiceRegistryBuilder;


public class DAO
{
    static ThreadLocal<Session> session = new ThreadLocal<Session>();
    static SessionFactory sessionFactory = configureSessionFactory();
    static Transaction transaction = null;

    public static SessionFactory configureSessionFactory()
    {
        Configuration configuration = new Configuration()
                .configure();
//        Configuration configuration = new Configuration()
//                .setProperty("hibernate.connection.driver_class", "org.postgresql.Driver")
//                .setProperty("hibernate.dialect", "org.hibernate.dialect.PostgreSQL81Dialect")
//                .setProperty("hibernate.connection.url", "jdbc:postgresql://1.1.1.11:5432/Test_DB")
//                .setProperty("hibernate.connection.username", "postgres")
//                .setProperty("hibernate.connection.password", "super")
//                .setProperty("show_sql", "true");
        ServiceRegistry serviceRegistry = new ServiceRegistryBuilder().applySettings(
                configuration.getProperties()).buildServiceRegistry();
        return configuration.buildSessionFactory(serviceRegistry);
    }

    public static Session getSession()
    {
        if (session.get() == null || !session.get().isOpen())
            session.set(sessionFactory.openSession());
        return session.get();
    }

    public static void begin()
    {
        try
        {
            transaction = getSession().beginTransaction();
        } catch (Exception e)
        {
            e.printStackTrace();
        }
    }

    public static void commit()
    {
        if (transaction != null && transaction.isActive())
            transaction.commit();
    }

}
