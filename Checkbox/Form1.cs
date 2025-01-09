using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Checkbox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void colorRandom(object sender, EventArgs e)
        {
            int rojo = checkBox1.Checked ? 255 : 0;
            int verde = checkBox2.Checked ? 255 : 0;
            int azul = checkBox3.Checked ? 255 : 0;

            BackColor = Color.FromArgb(rojo, verde, azul);
        }

        Random r = new Random();

        private void button1_Click(object sender, EventArgs e)
        {
            BackColor = Color.FromArgb(r.Next(256), r.Next(256), r.Next(256));
        }
    }
}
