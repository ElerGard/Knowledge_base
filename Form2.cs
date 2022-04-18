using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;


namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        private List<string> elemsToSave = new List<string>();
        private List<string> elemsToDel = new List<string>();
        private static string conn_string = "Data Source=database.db";

        public Form2()
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

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            using (var cnn = new SqliteConnection(conn_string))
            {
                string name = comboBox1.Text;
                listBox1.Items.Clear();
                listBox2.Items.Clear();
                comboBox2.Items.Clear();
                cnn.Open();

                SqliteCommand command = new SqliteCommand($"SELECT properties_name FROM PropertiesForMonster WHERE monster_name='{name}'", cnn);
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            comboBox2.Items.Add(reader.GetValue(0).ToString());
                        }
                    }
                }
            }
        }

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            using (var cnn = new SqliteConnection(conn_string))
            {
                string Mname = comboBox1.Text;
                string Pname = comboBox2.Text;

                listBox1.Items.Clear();
                listBox2.Items.Clear();
                cnn.Open();

                SqliteCommand command = new SqliteCommand($"SELECT value FROM ImposibleProperties WHERE name='{Pname}' EXCEPT SELECT value FROM PVFM WHERE monster_name='{Mname}' AND properties_name='{Pname}'", cnn);
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
                command = new SqliteCommand($"SELECT value FROM PVFM WHERE monster_name='{Mname}' AND properties_name='{Pname}'", cnn);
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
    }
}
