using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DateTimePicker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label2.Text = fechaActual();
            label1.Visible = false;
            button1.Enabled = false;
            setToolTip();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime fecha = dateTimePicker1.Value;
            DateTime hoy = DateTime.Today.AddHours(fecha.Hour).AddMinutes(fecha.Minute).AddSeconds(fecha.Second);
            int diferencia = (fecha - hoy).Days;

            if(diferencia == 0)
            {
                label1.Text = "Hoy";
            }
            else if(diferencia > 0)
            {
                label1.Text = $"Dentro de {diferencia} {((diferencia == 1)?"dia":"dias")}";
            }
            else
            {
                label1.Text = $"Hace {(diferencia*(-1))} {((diferencia == -1) ? "dia" : "dias")}";
            }

            label1.Visible = true;
        }

        private string fechaActual()
        {
            DateTime fecha = DateTime.Now;
            string diaDeSemana = "";
            string mes = "";
            
            switch(fecha.DayOfWeek)
            {
                case DayOfWeek.Sunday: diaDeSemana = "Domingo";
                    break;
                case DayOfWeek.Monday: diaDeSemana = "Lunes";
                    break;
                case DayOfWeek.Tuesday: diaDeSemana = "Martes";
                    break;
                case DayOfWeek.Wednesday: diaDeSemana = "Miercoles";
                    break;
                case DayOfWeek.Thursday: diaDeSemana = "Jueves";
                    break;
                case DayOfWeek.Friday: diaDeSemana = "Viernes";
                    break;
                case DayOfWeek.Saturday: diaDeSemana = "Sabado";
                    break;
            }

            switch (fecha.Month)
            {
                case 1: mes = "Enero";
                    break;
                case 2: mes = "Febrero";
                    break;
                case 3: mes = "Marzo";
                    break;
                case 4: mes = "Abril";
                    break;
                case 5: mes = "Mayo";
                    break;
                case 6: mes = "Junio";
                    break;
                case 7: mes = "Julio";
                    break;
                case 8: mes = "Agosto";
                    break;
                case 9: mes = "Septiembre";
                    break;
                case 10: mes = "Octubre";
                    break;
                case 11: mes = "Noviembre";
                    break;
                case 12: mes = "Diciembre";
                    break;
            }

            return $"Hoy es {diaDeSemana}, {fecha.Day} de {mes} de {fecha.Year}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int dias = int.Parse(textBox1.Text);
                dateTimePicker1.Value = DateTime.Today.AddDays(dias);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

        private void setToolTip()
        {
            toolTip1.SetToolTip(textBox1, "Ingrese numero de dias para conocer la fecha");
            toolTip1.SetToolTip(button1, "La fecha calculada se mostrara en el DateTimePicker");
        }
    }
}
