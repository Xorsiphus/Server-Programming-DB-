using System.Collections.Generic;
using System.Threading;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Mapping.Attributes;
using SP_Lab_5.Manager.Model;

namespace SP_Lab_5.Manager
{
    public class DataAccessObject
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
                    cfg.Configure("Z:/Dev/University/Server-Programming-DB-/Lab_5/NHibernate/hibernate.cfg.xml");
                    HbmSerializer.Default.Validate = true;
                    var stream = HbmSerializer.Default.Serialize(typeof(Tickets).Assembly);
                    cfg.AddInputStream(stream);
                    _sessionFactory = cfg.BuildSessionFactory();
                }

                return _sessionFactory;
            }
        }
        public static void LoadNhibernateCfg()
        {
            var cfg = new Configuration();
            cfg.Configure("Z:/Dev/University/Server-Programming-DB-/Lab_5/NHibernate/hibernate.cfg.xml");
            HbmSerializer.Default.Validate = true;
            var stream = HbmSerializer.Default.Serialize(typeof(Tickets).Assembly);
            cfg.AddInputStream(stream);
            _sessionFactory = cfg.BuildSessionFactory();
        }
        public static ISession GetSession()
        {
            if (!Session.IsValueCreated || !Session.Value.IsOpen)
                Session.Value = _sessionFactory.OpenSession();
            return Session.Value;
        }

        public static ITransaction OpenTransaction()
        {
            _transaction = GetSession().BeginTransaction();
            return _transaction;
        }

        public static void MakeCommit()
        {
            if (_transaction != null && _transaction.IsActive)
                _transaction.Commit();
            else
            {
                OpenTransaction();
                _transaction?.Commit();
            }
        }
        
        public static void Add<T>(T obj) where T : Entity
        {
            OpenTransaction();
            
            if (obj.Id != 0)
                GetSession().Save(obj, obj.Id);
            else
            {
                GetSession().Save(obj);
            }
            
            MakeCommit();
        }

        public static void Update<T>(T obj) where T : Entity
        {
            GetSession().Update(obj);
            MakeCommit();
        }

        public static void Delete<T>(T obj) where T : Entity
        {
            GetSession().Delete(obj);
            MakeCommit();
        }

        public static T GetEntityById<T>(int id) where T : Entity
        {
            ICriteria criteria = GetSession().CreateCriteria<T>();
            criteria.Add(Restrictions.Eq("id", id));
            return criteria.List<T>().Count > 0 ? criteria.List<T>()[0] : null;
        }

        public static IList<T> GetAllEntities<T>() where T : Entity
        {
            return GetSession().CreateCriteria<T>().List<T>();
        }
        
        public static IList<T> GetAllEntities<T>(int count) where T : Entity
        {
            return GetSession().CreateCriteria<T>().SetMaxResults(count).List<T>();
        }

        public static string ListPrinter<T>(IList<T> list)
        {
            var res = ""; 
            
            foreach (var entity in list)
            {
                res += entity + "\n";
            }

            return res;
        }
    }
}
