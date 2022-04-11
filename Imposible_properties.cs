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
    public partial class Imposible_properties : Form
    {
        private static string conn_string = "Data Source=database.db";
        public Imposible_properties()
        {
            InitializeComponent();
            using (var cnn = new SqliteConnection(conn_string))
            {
                this.comboBox1.Items.Clear();
                cnn.Open();

                SqliteCommand command = new SqliteCommand("SELECT * FROM Properties", cnn);
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            this.comboBox1.Items.Add(reader.GetValue(0).ToString());
                        }
                    }
                }


            }
        }

        //добавить
        private void button3_Click(object sender, EventArgs e)
        {
            using (var cnn = new SqliteConnection(conn_string))
            {
                string name = this.comboBox1.Text;
                string value = this.textBox1.Text;

                cnn.Open();

                SqliteCommand command = new SqliteCommand();
                command.Connection = cnn;
                command.CommandText = $"INSERT INTO ImposibleProperties (name, value) VALUES ('{name}', '{value}')";

                command.ExecuteNonQuery();

                this.textBox1.Text = "";
            }
            comboBox1_SelectionChangeCommitted(sender, e);
        }

        //удалить
        private void button1_Click(object sender, EventArgs e)
        {
            using (var cnn = new SqliteConnection(conn_string))
            {
                string name = this.comboBox1.Text;
                string value = this.comboBox2.Text;

                cnn.Open();

                SqliteCommand command = new SqliteCommand();
                command.Connection = cnn;
                command.CommandText = $"DELETE FROM ImposibleProperties WHERE name='{name}' and value='{value}'";

                command.ExecuteNonQuery();

                this.comboBox2.Text = "";
            }
            comboBox1_SelectionChangeCommitted(sender, e);

        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            using (var cnn = new SqliteConnection(conn_string))
            {
                string name = this.comboBox1.Text;
                this.comboBox2.Items.Clear();
                cnn.Open();

                SqliteCommand command = new SqliteCommand($"SELECT * FROM ImposibleProperties WHERE name='{name}'", cnn);
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            this.comboBox2.Items.Add(reader.GetValue(0).ToString());
                        }
                    }
                }
            }
        }
    }
}
