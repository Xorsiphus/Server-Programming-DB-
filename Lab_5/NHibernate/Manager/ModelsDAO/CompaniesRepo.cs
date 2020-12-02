using System;
using System.Collections.Generic;
using NHibernate.Criterion;
using SP_Lab_5.Manager.Model;

namespace SP_Lab_5.Manager.ModelsDAO
{
    public class CompaniesRepo : DataAccessObject
    {
        public static IList<Companies> GetByArgs(string[] args)
        {
            if (args.Length < 1 || args.Length > 3)
                return GetAllEntities();

            var criteria = GetSession().CreateCriteria<Companies>();

            foreach (var arg in args)
            {
                try
                {
                    var i = int.Parse(arg);
                    criteria.Add(Restrictions.Eq("id", i));
                    continue;
                }
                catch (Exception e)
                {
                    // ignored
                }

                try
                {
                    var i = DateTime.Parse(arg);
                    criteria.Add(Restrictions.Eq("Date", i));
                    continue;
                }
                catch (Exception e)
                {
                    // ignored
                }

                try
                {
                    criteria.Add(Restrictions.Eq("Name", arg));
                }
                catch (Exception e)
                {
                    // ignored
                }
            }
            
            return criteria.List<Companies>();
        }

        public static void Add(Companies obj)
        {
            Add<Companies>(obj);
        }
        
        public static void Update(Companies obj)
        {
            Update<Companies>(obj);
        }
        
        public static void Delete(Companies obj)
        {
            Delete<Companies>(obj);
        }
        
        public static Companies GetEntityById(int id)
        {
            return GetEntityById<Companies>(id);
        }
        
        public static IList<Companies> GetAllEntities()
        {
            return GetAllEntities<Companies>();
        }
        
        public static IList<Companies> GetAllEntities(int count)
        {
            return GetAllEntities<Companies>(count);
        }
    }
}