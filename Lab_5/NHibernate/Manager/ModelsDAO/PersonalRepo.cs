

using System.Collections.Generic;
using SP_Lab_5.Manager.Model;

namespace SP_Lab_5.Manager.ModelsDAO
{
    public class PersonalRepo : DataAccessObject
    {
        public static void Add(Personal obj)
        {
            Add<Personal>(obj);
        }
        
        public static void Update(Personal obj)
        {
            Update<Personal>(obj);
        }
        
        public static void Delete(Personal obj)
        {
            Delete<Personal>(obj);
        }
        
        public static Personal GetEntityById(int id)
        {
            return GetEntityById<Personal>(id);
        }
        
        public static IList<Personal> GetAllEntities()
        {
            return GetAllEntities<Personal>();
        }
        
        public static IList<Personal> GetAllEntities(int count)
        {
            return GetAllEntities<Personal>(count);
        }
    }
}