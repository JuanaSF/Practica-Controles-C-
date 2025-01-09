using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FolderBrowserDialog
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                string nombreCarpeta = folderBrowserDialog1.SelectedPath;
                listBox1.Items.Clear();

                foreach(string archivo in Directory.GetFiles(nombreCarpeta))
                {
                    listBox1.Items.Add(archivo);
                }
            }
        }
    }
}
