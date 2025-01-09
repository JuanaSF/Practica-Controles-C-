using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgressBar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CargarProductos();
            timer1.Enabled = true;
            timer1.Stop();

            notifyIcon1.Icon = new Icon("coffee-cup.ico");
            notifyIcon1.Visible = true;
            notifyIcon1.BalloonTipTitle = "Notificacion de la Cafeteria";
        }

        List<Pedido> productos = new List<Pedido>();
        int contador = 0;
        int maxProgressBar = 0;

        private void CargarProductos()
        {
            Pedido p1 = new Pedido("Cappuccino", 12);
            Pedido p2 = new Pedido("Latte", 10);
            Pedido p3 = new Pedido("Latte Macchiato", 15);
            Pedido p4 = new Pedido("Mocha", 20);
            Pedido p5 = new Pedido("Mocha Blanco Helado", 30);
            Pedido p6 = new Pedido("Cafe Frappuccino", 35);

            productos.AddRange(new Pedido[] { p1, p2, p3, p4, p5, p6});

            productos.ForEach(p => comboBox1.Items.Add(p.Nombre));

            comboBox1.SelectedIndex = 0;

            cargarTiempo(null, null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            comboBox1.Enabled = false;
            numericUpDown1.Enabled = false;

            progressBar1.Value = 0;
            label2.Visible = true;
            label5.Text = "0";
            label5.Visible = true;
            progressBar1.Maximum = maxProgressBar;

            timer1.Start();
            timer1.Interval = 1000;
            contador = 0;

            mostrarNotificacion("Estamos preparando tu pedido!", "Tu pedido pronto estara listo, espere por favor");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            if (progressBar1.Value < maxProgressBar)
            {
                contador++;
                label5.Text = contador.ToString();
                progressBar1.Value++;
            }
            if(progressBar1.Value == maxProgressBar)
            {
                timer1.Stop();
                mostrarNotificacion("Tu pedido esta listo!", "El tiempo de espera termino!");
                label2.Visible = false;
                label5.Visible = false;
                habilitarControles();
                progressBar1.Value = 0;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            contador = 0;
            progressBar1.Value = 0;
            label2.Visible = false;
            label5.Visible = false;
            timer1.Stop();
            habilitarControles();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void cargarTiempo(object sender, EventArgs e)
        {
            int tiempoTotal = productos[comboBox1.SelectedIndex].TiempoDeEspera * (int)numericUpDown1.Value;
            label1.Text = $"Tiempo de Espera : {tiempoTotal}";
            maxProgressBar = tiempoTotal;
        }

        private void habilitarControles()
        {
            comboBox1.Enabled = true;
            numericUpDown1.Enabled = true;
            comboBox1.SelectedIndex = 0;
            numericUpDown1.Value = 1;
        }

        private void mostrarNotificacion(string textoNotificacion, string textoToolTip)
        {
            notifyIcon1.Text = textoNotificacion;
            notifyIcon1.BalloonTipText = textoToolTip;
            notifyIcon1.ShowBalloonTip(1000);
        }
    }

    public class Pedido
    {
        public Pedido(string nombre, int tiempo)
        {
            Nombre = nombre;
            TiempoDeEspera = tiempo;
        }

        public string Nombre { get; set; }
        public int TiempoDeEspera { get; set; }
    }
}
