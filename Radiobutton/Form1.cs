using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Radiobutton
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string comida;
        private string guarnicion;
        private string bebida; 

        private void comidaRadioButton_CheckedChanged(object Sender, EventArgs e)
        {
            RadioButton rb = Sender as RadioButton;

            if (rb.Checked)
            {
                button1.Enabled = true;
                comida = rb.Text;
            }
        }

        private void guarnicionRadioButton_CheckedChanged(object Sender, EventArgs e)
        {
            RadioButton rb = Sender as RadioButton;

            if (rb.Checked)
            {
                button1.Enabled = true;
                guarnicion = rb.Text;
            }
        }

        private void bebidaRadioButton_CheckedChanged(object Sender, EventArgs e)
        {
            RadioButton rb = Sender as RadioButton;

            if (rb.Checked)
            {
                button1.Enabled = true;
                bebida = rb.Text;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show($"Se confirmo su menu de {comida + ","} {guarnicion} {"y " + bebida}.");
            MessageBox.Show("Se confirmo su menu de "+ (String.IsNullOrEmpty(comida) ? "": comida) +
                (string.IsNullOrEmpty(guarnicion) ? "" : $" - {guarnicion}") +
                (string.IsNullOrEmpty(bebida) ? "" : $" - {bebida}"));
            limpiar_menu();
        }

        private void limpiar_menu()
        {
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            radioButton5.Checked = false;
            radioButton6.Checked = false;
            radioButton7.Checked = false;
            radioButton8.Checked = false;
            radioButton9.Checked = false;
            radioButton10.Checked = false;
            button1.Enabled=false;
            comida = null;
            guarnicion = null;
            bebida = null;
        }
    }
}
