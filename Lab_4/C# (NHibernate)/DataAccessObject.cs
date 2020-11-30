using System;
using System.Threading;
using NHibernate;
using NHibernate.Cfg;

namespace SP_Lab_4
{
    public static class DataAccessObject
    {
        private static ISessionFactory _sessionFactory;
        private static readonly ThreadLocal<ISession> Session = new ThreadLocal<ISession>();
        private static ITransaction _transaction;

        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    var cfg = new Configuration();
                    cfg.Configure("Z:/Dev/University/Server-Programming-DB-/Lab_4/C#(NHibernate)/hibernate.cfg.xml");
                    _sessionFactory = cfg.BuildSessionFactory();
                }

                return _sessionFactory;
            }
        }

        public static void LoadNhibernateCfg()
        {
            var cfg = new Configuration();
            cfg.Configure("Z:/Dev/University/Server-Programming-DB-/Lab_4/C#(NHibernate)/hibernate.cfg.xml");
            _sessionFactory = cfg.BuildSessionFactory();
        }
        public static ISession GetSession()
        {
            if (!Session.IsValueCreated || !Session.Value.IsOpen)
                Session.Value = _sessionFactory.OpenSession();
            return Session.Value;
        }

        public static void OpenTransaction()
        {
            try
            {
                _transaction = GetSession().BeginTransaction();
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
            }
        }

        public static void MakeCommit()
        {
            if (_transaction != null && _transaction.IsActive)
                _transaction.Commit();
            else
            {
                OpenTransaction();
            }
        }

    }
}
