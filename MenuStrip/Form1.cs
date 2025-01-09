using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace MenuStrip
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Se carga el archivo rtf
                richTextBox1.LoadFile(openFileDialog1.FileName);
            }
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Se guarde el documento rtf
                richTextBox1.SaveFile(saveFileDialog1.FileName);
            }
        }

        private void fuenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(fontDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionFont = fontDialog1.Font;
            }
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(colorDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionColor = colorDialog1.Color;
            }
        }

        private void ingresarPalabraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string text = Interaction.InputBox("Ingrese palabra de busqueda: ");
            richTextBox1.Find(text, RichTextBoxFinds.None);
        }

        private void imprimirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintDocument archivoAImprimir = new PrintDocument();
            archivoAImprimir.PrintPage += Imprimir;

            if(printDialog1.ShowDialog() == DialogResult.OK)
            {
                archivoAImprimir.Print();
            }

        }

        private void Imprimir(object sender, PrintPageEventArgs e)
        {
            Font fuente = richTextBox1.SelectionFont;
            string texto = richTextBox1.Text;

            e.Graphics.DrawString(texto, fuente, Brushes.Black, 10, 10);
        }
    }
}
