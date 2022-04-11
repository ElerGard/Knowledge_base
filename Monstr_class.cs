using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using Microsoft.Data.Sqlite;

namespace WindowsFormsApp1
{
    public partial class Monstr_class : Form
    {
        public Monstr_class()
        {
            InitializeComponent();
        }

        private static string conn_string = "Data Source=database.db";

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var cnn = new SqliteConnection(conn_string))
            {
                string name = this.textBox1.Text;

                cnn.Open();

                SqliteCommand command = new SqliteCommand();
                command.Connection = cnn;
                command.CommandText = $"INSERT INTO Monsters (name) VALUES ('{name}')";

                command.ExecuteNonQuery();

                this.textBox1.Text = "";
            }
            MonsterLoad(sender, e);
        }
        
        private void MonsterLoad(object sender, EventArgs e)
        {
            using (var cnn = new SqliteConnection(conn_string))
            {
                this.listBox1.Items.Clear();
                this.comboBox1.Items.Clear();
                cnn.Open();

                SqliteCommand command = new SqliteCommand("SELECT * FROM Monsters", cnn);
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows) 
                    {
                        while (reader.Read()) 
                        {
                            this.listBox1.Items.Add(reader.GetValue(0).ToString());
                            this.comboBox1.Items.Add(reader.GetValue(0).ToString());
                        }
                    }
                }

                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var cnn = new SqliteConnection(conn_string))
            {
                string name = this.comboBox1.Text;

                cnn.Open();

                SqliteCommand command = new SqliteCommand();
                command.Connection = cnn;
                command.CommandText = $"DELETE FROM Monsters WHERE name='{name}'";

                command.ExecuteNonQuery();

                this.textBox1.Text = "";
            }
            MonsterLoad(sender, e);
        }
    }
}
