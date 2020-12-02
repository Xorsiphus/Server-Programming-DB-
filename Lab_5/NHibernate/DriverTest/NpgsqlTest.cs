using System;
using Npgsql;

namespace SP_Lab_5.DriverTest
{
    public class NpgsqlTest
    {
        public static void ShowTable()
        {
            var cs = "Host=localhost;Username=postgres;Password=super;Database=Test_DB_2";

            var con = new NpgsqlConnection(cs);
            con.Open();

            var sql = "SELECT * FROM movies;";

            var cmd = new NpgsqlCommand(sql, con);

            NpgsqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                Console.WriteLine("{0} {1} {2} {3} {4}", rdr.GetInt32(0), rdr.GetInt32(1), 
                    rdr.GetString(2), rdr.GetDate(3), rdr.GetString(4));
            }  
        }
    }
}