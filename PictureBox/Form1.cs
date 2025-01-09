using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PictureBox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Image imagen1 = Image.FromFile("imagen1.jpg");
            Image imagen2 = Image.FromFile("imagen2.jpg");
            Image imagen3 = Image.FromFile("imagen3.jpg");

            imagenes.Add(imagen1);
            imagenes.Add(imagen2);
            imagenes.Add(imagen3);

            pictureBox1.Image = imagenes[0];

            timer1.Interval = (int)(numericUpDown1.Value*1000);
            timer1.Enabled = true;
            timer1.Start();
        }

        List<Image> imagenes = new List<Image>();
        int index = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (index < imagenes.Count)
            {
                pictureBox1.Image = imagenes[index];
                index++;
            }

            if(index == imagenes.Count)
            {
                index = 0;
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            timer1.Interval = (int)(numericUpDown1.Value*1000);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Image nuevaImagen = null; 

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string ruta = openFileDialog1.FileName;
                nuevaImagen = Image.FromFile(ruta);
            }

            if(nuevaImagen != null)
            {
                imagenes.Add(nuevaImagen);
                index = 0;
                pictureBox1.Image = imagenes.Last();
            }
        }
    }

    

}
