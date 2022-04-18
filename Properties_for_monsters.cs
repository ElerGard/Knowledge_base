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
using System.Windows;

namespace WindowsFormsApp1
{
    public partial class Properties_for_monsters : Form
    {
        private List<string> elemsToSave = new List<string>();
        private List<string> elemsToDel = new List<string>();
        private static string conn_string = "Data Source=database.db";
        public Properties_for_monsters()
        {
            InitializeComponent();
            using (var cnn = new SqliteConnection(conn_string))
            {
                comboBox1.Items.Clear();
                cnn.Open();

                SqliteCommand command = new SqliteCommand("SELECT * FROM Monsters", cnn);
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            comboBox1.Items.Add(reader.GetValue(0).ToString());
                        }
                    }
                }
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        
        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {

            using (var cnn = new SqliteConnection(conn_string))
            {
                string name = comboBox1.Text;
                listBox1.Items.Clear();
                listBox2.Items.Clear();
                cnn.Open();

                SqliteCommand command = new SqliteCommand($"SELECT * FROM Properties EXCEPT SELECT properties_name FROM PropertiesForMonster WHERE monster_name='{name}'", cnn);
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            listBox1.Items.Add(reader.GetValue(0).ToString());
                        }
                    }
                }
                command = new SqliteCommand($"SELECT properties_name FROM PropertiesForMonster WHERE monster_name='{name}'", cnn);
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            listBox2.Items.Add(reader.GetValue(0).ToString());
                        }
                    }
                }
            }
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listBox1.IndexFromPoint(e.Location) != -1)
            {
                elemsToSave.Add(listBox1.SelectedItem.ToString());
                listBox2.Items.Add(listBox1.SelectedItem);
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
        }

        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            //Console.WriteLine(listBox1.IndexFromPoint(e.Location));
            if (listBox1.IndexFromPoint(e.Location) == -1)
            {
                listBox1.ClearSelected();
            }
        }

        private void listBox2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listBox2.IndexFromPoint(e.Location) != -1)
            {
                elemsToDel.Add(listBox2.SelectedItem.ToString());
                listBox1.Items.Add(listBox2.SelectedItem);
                listBox2.Items.RemoveAt(listBox2.SelectedIndex);
            }
        }

        private void listBox2_MouseClick(object sender, MouseEventArgs e)
        {
            //Console.WriteLine(listBox1.IndexFromPoint(e.Location));
            if (listBox2.IndexFromPoint(e.Location) == -1)
            {
                listBox2.ClearSelected();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //var form = new Form1();
            //form.Show(this); // if you need non-modal window
        }

        //Сохранить
        private void button1_Click(object sender, EventArgs e)
        {
            using (var cnn = new SqliteConnection(conn_string))
            {
                string name = this.comboBox1.SelectedItem.ToString();

                cnn.Open();

                SqliteCommand command = new SqliteCommand();
                command.Connection = cnn;

                while (elemsToSave.Count != 0)
                {
                    command.CommandText = $"INSERT INTO PropertiesForMonster (monster_name, properties_name) VALUES ('{name}', '{elemsToSave.First()}')";

                    command.ExecuteNonQuery();
                    elemsToSave.RemoveAt(0);
                }
                while (elemsToDel.Count != 0)
                {
                    command.CommandText = $"DELETE FROM PropertiesForMonster WHERE monster_name='{name}' AND properties_name='{elemsToDel.First()}'";

                    command.ExecuteNonQuery();
                    elemsToDel.RemoveAt(0);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            comboBox1_SelectionChangeCommitted(sender, e);
            elemsToSave.Clear();
            elemsToDel.Clear();
        }
    }
}
