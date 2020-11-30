using System;
using Npgsql;

namespace SP_Lab_4.DriverTest
{
    public class NpgsqlTest
    {
        public static void ShowTable()
        {
            var cs = "Host=localhost;Username=postgres;Password=super;Database=Test_DB";

            var con = new NpgsqlConnection(cs);
            con.Open();

            var sql = "SELECT * FROM companies;";

            var cmd = new NpgsqlCommand(sql, con);

            NpgsqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                Console.WriteLine("{0} {1} {2}", rdr.GetInt32(0), rdr.GetString(1),
                    rdr.GetDate(2));
            }  
        }
    }
}