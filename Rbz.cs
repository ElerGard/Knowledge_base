using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Rbz : Form
    {
        public Rbz()
        {
            InitializeComponent();
        }

        private void monstr_class_Click(object sender, EventArgs e)
        {
            Monstr_class form = new Monstr_class();
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Properties_class form = new Properties_class();
            form.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Imposible_properties form = new Imposible_properties();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Properties_for_monsters form = new Properties_for_monsters();
            form.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.Show();
        }
    }
}
