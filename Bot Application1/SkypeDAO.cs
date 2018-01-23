using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bot_Application1 {
    public class SkypeDAO {
        public void Open() {
            using (var conn = new NpgsqlConnection("")) {
                conn.Open();


                // Retrieve all rows
                using (var cmd = new NpgsqlCommand("select * from yo", conn))
                using (var reader = cmd.ExecuteReader()) {
                    //  Console.WriteLine("catalog              table schema              table_name");
                    while (reader.Read()) {
                        Console.WriteLine(reader.GetString(0) + " " + reader.GetString(1));
                        //     Console.WriteLine(reader.GetString(0) + "  " + reader.GetString(1) + "  " + reader.GetString(2) + "  " + reader.GetString(3));
                    }
                }

            }
        }
    }
}