using System.Collections.Generic;
using SP_Lab_5.Manager.Model;

namespace SP_Lab_5.Manager.ModelsDAO 
{
    public class CinemasRepo : DataAccessObject
    {
        public static void Add(Cinemas obj)
        {
            Add<Cinemas>(obj);
        }
        
        public static void Update(Companies obj)
        {
            Update<Companies>(obj);
        }
        
        public static void Delete(Companies obj)
        {
            Delete<Companies>(obj);
        }
        
        public static Cinemas GetEntityById(int id)
        {
            return GetEntityById<Cinemas>(id);
        }
        
        public static IList<Cinemas> GetAllEntities()
        {
            return GetAllEntities<Cinemas>();
        }
        
        public static IList<Cinemas> GetAllEntities(int count)
        {
            return GetAllEntities<Cinemas>(count);
        }
    }
}