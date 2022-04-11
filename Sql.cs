using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using Microsoft.Data.Sqlite;

namespace WindowsFormsApp1
{
    public class Monster
    {
        public string name;
    }

    public class Sql
    {
        private static string conn_string = "Data Source=database.db";
        public static void MonstersList()
        {
            List<string> monsters_list = new List<string>();

            using (var cnn = new SqliteConnection(conn_string))
            {
                cnn.Open();

                SqliteCommand command = new SqliteCommand("SELECT * FROM Monsters", cnn);
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows) // если есть данные
                    {
                        while (reader.Read())   // построчно считываем данные
                        {
                            monsters_list.Add(reader.GetValue(0).ToString());
                        }
                    }
                }
            }
        }

        public static void SaveMonster(Monster monster)
        {
            
        }
    }
}
