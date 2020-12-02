using System.Collections;
using NHibernate.Criterion;
using NHibernate.Transform;
using SP_Lab_5.Manager;
using SP_Lab_5.Manager.Model;

namespace SP_Lab_5
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            DataAccessObject.LoadNhibernateCfg();

            // Console.WriteLine(DataAccessObject.ListPrinter(CompaniesRepo.GetAllEntities()));
            // Console.WriteLine(DataAccessObject.ListPrinter(CompaniesRepo.GetByArgs(new[] { "10/14/2007 00:00:00", 
            //     "1", "Bthrvceuaada" } )));
            // Console.WriteLine(MoviesRepo.GetEntityById(1));
            
            // var dicts = DataAccessObject.GetSession().CreateCriteria<Tickets>()
            //     .CreateAlias("CinemaId", "cin")
            //     .CreateAlias("cin.SharedFilm", "mov")
            //     .CreateAlias("mov.CompanyId", "com")
            //     .Add(Restrictions.Le("id", 20))
            //     .SetResultTransformer(Transformers.AliasToEntityMap)
            //     .List<IDictionary>(); 
            //     foreach ( IDictionary map in dicts )
            // {
            //     var main = map[CriteriaSpecification.RootAlias];
            // };

            // CompaniesRepo.Add(new Companies { Name = "SuperComp5", 
            //     Date = new DateTime(2001, 10, 10)});
            // var copmId = CompaniesRepo.GetByArgs(new[] { "SuperComp5" } )[0];
            // PersonalRepo.Add(new Personal { CompanyId = copmId, Name = "Persona21", 
            //     BDate = new DateTime(2002, 01, 02), Position = "Pos1"});
            // PersonalRepo.Add(new Personal { CompanyId = copmId, Name = "Persona22", 
            //     BDate = new DateTime(2004, 01, 02), Position = "Pos2"});
            // PersonalRepo.Add(new Personal { CompanyId = copmId, Name = "Persona23", 
            //     BDate = new DateTime(2006, 01, 02), Position = "Pos3"});

            var dicts = DataAccessObject.GetSession().CreateCriteria<Companies>()
                .CreateAlias("this.Personal", "per")
                .Add(Restrictions.Eq("this.id", 112))
                .SetResultTransformer(Transformers.AliasToEntityMap)
                .List<IDictionary>(); 
                foreach ( IDictionary map in dicts )
            {
                var main = map[CriteriaSpecification.RootAlias];
            }
        }
    }
}
