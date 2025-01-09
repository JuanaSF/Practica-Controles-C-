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

namespace monthcalendar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            agenda = new List<Evento>();
            DateTime f = monthCalendar1.SelectionStart;
            string hoy = $"{f.DayOfWeek}, {getMonth(f.Month)} {f.Day}, {f.Year}";
            label2.Text = hoy;
        }

        List<Evento> agenda;
        private void button1_Click(object sender, EventArgs e)
        {
            Evento evento = new Evento();
            evento.fecha = monthCalendar1.SelectionStart;
            evento.descripcion = Interaction.InputBox("Descripcion: ");
            agenda.Add(evento);
            monthCalendar1.AddBoldedDate(evento.fecha);
            monthCalendar1.UpdateBoldedDates();
            ActualizarDataGrid();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

            label2.Text = $"{e.Start.DayOfWeek}, {getMonth(e.Start.Month)} {e.Start.Day}, {e.Start.Year}";
        }

        private void ActualizarDataGrid()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = agenda;
        }

        private string getMonth(int month)
        {
            switch (month)
            {
                case 1: return "January";
                case 2: return "February";
                case 3: return "March";
                case 4: return "April";
                case 5: return "May";
                case 6: return "June";
                case 7: return "July";
                case 8: return "August";
                case 9: return "September";
                case 10: return "October";
                case 11: return "November";
                case 12: return "December";
                default: return "";
            }
        }
    }

    public class Evento
    {
        public DateTime fecha { get; set; }
        public string descripcion { get; set; }
    }
}
