using SP_Lab_4.ORMLibraryTest;

namespace SP_Lab_4
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            DataAccessObject.LoadNhibernateCfg();
            TestSrvc.GetName();
            TestSrvc.GetStringsFromInterval(32, 48);
            TestSrvc.AddRecordsToDb();
            
            // NpgsqlTest.ShowTable();
        }
    }
}
