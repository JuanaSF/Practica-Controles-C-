using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataGridView
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            alumnos = new List<Alumno>();
        }

        List<Alumno> alumnos;

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.MultiSelect = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            Alumno a1 = new Alumno() { Legajo = 1, Nombre = "Ana", Apellido = "Perez" };
            Alumno a2 = new Alumno() { Legajo = 2, Nombre = "Martin", Apellido = "Sanchez" };
            Alumno a3 = new Alumno() { Legajo = 3, Nombre = "Rocio", Apellido = "Martinez" };

            alumnos.AddRange(new Alumno[] { a1, a2, a3 });

            ActualizarDataGrid();
        }

        private void ActualizarDataGrid()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = alumnos;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Alumno alumno = new Alumno();
            alumno.Legajo = alumnos.Last().Legajo + 1;
            alumno.Nombre = Interaction.InputBox("Nombre: ");
            alumno.Apellido = Interaction.InputBox("Apellido: ");
            alumnos.Add(alumno);
            ActualizarDataGrid();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            alumnos.Remove(dataGridView1.SelectedRows[0].DataBoundItem as Alumno);
            ActualizarDataGrid();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Alumno a1 = dataGridView1.SelectedRows[0].DataBoundItem as Alumno;

            alumnos.Find(a => a.Legajo == a1.Legajo).Nombre = Interaction.InputBox("Nombre: ");
            alumnos.Find(a => a.Legajo == a1.Legajo).Apellido = Interaction.InputBox("Apellido: ");

            ActualizarDataGrid();
        }
    }

    public class Alumno
    {
        public int Legajo { get; set; }
        public string Nombre { get; set; }

        string apellido;
        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }
    }
}
