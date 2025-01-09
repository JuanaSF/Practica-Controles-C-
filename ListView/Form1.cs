using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace ListView
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CargarDatos();
            agregarTootip();
        }


        private void CargarDatos()
        {
            ListViewGroup frutas = new ListViewGroup("Frutas", HorizontalAlignment.Left);
            ListViewGroup verduras = new ListViewGroup("Verduras", HorizontalAlignment.Left);
            ListViewGroup carnes = new ListViewGroup("Carnes", HorizontalAlignment.Left);

            listView1.Items.Add(new ListViewItem("Manzana", frutas));
            listView1.Items.Add(new ListViewItem("Banana", frutas));
            listView1.Items.Add(new ListViewItem("Naranja", frutas));

            listView1.Items.Add(new ListViewItem("Zapallo", verduras));
            listView1.Items.Add(new ListViewItem("Zanahoria", verduras));
            listView1.Items.Add(new ListViewItem("Lechuga", verduras));

            listView1.Items.Add(new ListViewItem("Res", carnes));
            listView1.Items.Add(new ListViewItem("Pollo", carnes));
            listView1.Items.Add(new ListViewItem("Pescado", carnes));

            listView1.Groups.AddRange(new ListViewGroup[] { frutas, verduras, carnes });
            comboBox1.Items.AddRange(new string[] { "Frutas", "Verduras", "Carnes" });
            comboBox1.SelectedIndex = 0;
            button1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int index = comboBox1.SelectedIndex;
            listView1.Items.Add(new ListViewItem(textBox1.Text, listView1.Groups[index]));
            textBox1.Text = String.Empty;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(textBox1.Text))
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string nombreNuevoGrupo = Interaction.InputBox("Nombre del Grupo: ");

            if(!string.IsNullOrWhiteSpace(nombreNuevoGrupo))
            {
                ListViewGroup nuevoGrupo = new ListViewGroup(nombreNuevoGrupo, HorizontalAlignment.Left);
                listView1.Groups.Add(nuevoGrupo);
                comboBox1.Items.Add(nombreNuevoGrupo);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(listView1.SelectedItems.Count != 0)
            {
                listView1.Items.RemoveAt(listView1.SelectedIndices[0]);
            }
        }

        private void agregarTootip()
        {
            toolTip1.IsBalloon = true;
            toolTip1.SetToolTip(button1, "Crea un nuevo item al grupo seleccionado");
            toolTip1.SetToolTip(button2, "Crea un nuevo grupo en el ListView");
            toolTip1.SetToolTip(button3, "Elimina el elemento seleccionado");
            toolTip1.SetToolTip(textBox1, "Nombre del nuevo item, no debe ser una cadena vacia!");
        }
    }
}
