using System.Collections.Generic;
using SP_Lab_5.Manager.Model;

namespace SP_Lab_5.Manager.ModelsDAO
{
    public class TicketsRepo : DataAccessObject
    {
        public static void Add(Tickets obj)
        {
            Add<Tickets>(obj);
        }
        
        public static void Update(Tickets obj)
        {
            Update<Tickets>(obj);
        }
        
        public static void Delete(Tickets obj)
        {
            Delete<Tickets>(obj);
        }
        
        public static Tickets GetEntityById(int id)
        {
            return GetEntityById<Tickets>(id);
        }
        
        public static IList<Tickets> GetAllEntities()
        {
            return GetAllEntities<Tickets>();
        }
        
        public static IList<Tickets> GetAllEntities(int count)
        {
            return GetAllEntities<Tickets>(count);
        }
    }
}