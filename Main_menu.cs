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
    public partial class Main_menu : Form
    {
        public Main_menu()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Classification form = new Classification();
            form.Show(this);
            //this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Rbz form = new Rbz();
            form.Show(this);
            //this.Hide();
        }
    }
}
