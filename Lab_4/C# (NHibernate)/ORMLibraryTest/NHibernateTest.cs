using System;
using System.Collections;

namespace SP_Lab_4.ORMLibraryTest
{
    public class TestSrvc
    {
        public static void GetName()
        {
            IList list = DataAccessObject
                .GetSession()
                .CreateSQLQuery("SELECT * FROM companies;")
                .List();

            foreach (var obj in list)
            {
                object[] temp = (object[])obj;
                Console.WriteLine($"{temp[0], 3}) {temp[1], 14};  {temp[2]}");
            }
        }

        public static void GetStringsFromInterval(int begin, int end)
        {
            IList list = DataAccessObject
                .GetSession()
                .CreateSQLQuery($"SELECT * FROM companies WHERE id BETWEEN {begin} AND {end};")
                .List();
            
            foreach (var obj in list)
            {
                object[] temp = (object[])obj;
                Console.WriteLine($"{temp[0], 3}) {temp[1], 14};  {temp[2]}");
            }
        }

        public static void AddRecordsToDb()
        {
            IList list1 = DataAccessObject
                .GetSession()
                .CreateSQLQuery("SELECT MAX(id) FROM cinemas;")
                .List();

            IList list2 = DataAccessObject
                .GetSession()
                .CreateSQLQuery("SELECT MAX(id) FROM movies;")
                .List();

            if (list1 != null && list2 != null)
            {
                var maxC = (int)list1[0];
                var maxM = (int)list2[0];
            
                Random rnd = new Random();
                
                DataAccessObject.OpenTransaction();
            
                var list = DataAccessObject
                    .GetSession()
                    .CreateSQLQuery($"INSERT INTO tickets (cinema_id, film_id) VALUES " +
                                    $"(\'{rnd.Next(1, maxC)}\', \'{rnd.Next(1, maxM)}\');")
                    .List();
                
                DataAccessObject.MakeCommit();
            }
        }
    }
}