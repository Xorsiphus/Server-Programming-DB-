using System.Collections.Generic;
using SP_Lab_5.Manager.Model;

namespace SP_Lab_5.Manager.ModelsDAO
{
    public class MoviesRepo : DataAccessObject
    {
        public static void Add(Movies obj)
        {
            Add<Movies>(obj);
        }
        
        public static void Update(Movies obj)
        {
            Update<Movies>(obj);
        }
        
        public static void Delete(Movies obj)
        {
            Delete<Movies>(obj);
        }
        
        public static Movies GetEntityById(int id)
        {
            return GetEntityById<Movies>(id);
        }
        
        public static IList<Movies> GetAllEntities()
        {
            return GetAllEntities<Movies>();
        }
        
        public static IList<Movies> GetAllEntities(int count)
        {
            return GetAllEntities<Movies>(count);
        }
    }
}