using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TreeView
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button1.Enabled = false;
            button2.Enabled = false;
            CargarValoresArbol();
        }

        private void CargarValoresArbol()
        {
            treeView1.Nodes.Add("Vertebrados");
            treeView1.Nodes[0].Nodes.Add("Mamiferos");
            treeView1.Nodes[0].Nodes[0].Nodes.AddRange(new TreeNode[] {new TreeNode("perro"), 
                new TreeNode("gato"), new TreeNode("vaca") });

            treeView1.Nodes[0].Nodes.Add("Aves");
            treeView1.Nodes[0].Nodes[1].Nodes.AddRange(new TreeNode[] {new TreeNode("pinguino"),
                new TreeNode("tucan"), new TreeNode("paloma") });

            treeView1.Nodes[0].Nodes.Add("Reptiles");
            treeView1.Nodes[0].Nodes[2].Nodes.AddRange(new TreeNode[] {new TreeNode("cocodrilo"),
                new TreeNode("tortuga"), new TreeNode("serpiente") });

            treeView1.Nodes[0].Nodes.Add("Anfibios");
            treeView1.Nodes[0].Nodes[3].Nodes.AddRange(new TreeNode[] {new TreeNode("rana"),
                new TreeNode("sapo"), new TreeNode("salamandra") });

            treeView1.Nodes[0].Nodes.Add("Peces");
            treeView1.Nodes[0].Nodes[4].Nodes.AddRange(new TreeNode[] {new TreeNode("caballa"),
                new TreeNode("atun"), new TreeNode("salmon") });

            treeView1.Nodes.Add("Invertebrados");
            treeView1.Nodes[1].Nodes.Add("Con Protecccion Corporal");
            treeView1.Nodes[1].Nodes[0].Nodes.Add("Artropodos");
            treeView1.Nodes[1].Nodes[0].Nodes[0].Nodes.Add("Insectos");
            treeView1.Nodes[1].Nodes[0].Nodes[0].Nodes.Add("Aracnidos");
            treeView1.Nodes[1].Nodes[0].Nodes[0].Nodes.Add("Crustaceos");
            treeView1.Nodes[1].Nodes[0].Nodes[0].Nodes.Add("Miriapodos");

            treeView1.Nodes[1].Nodes[0].Nodes.Add("Moluscos");
            treeView1.Nodes[1].Nodes[0].Nodes[1].Nodes.Add("Gasteropodos");
            treeView1.Nodes[1].Nodes[0].Nodes[1].Nodes.Add("Bivalvos");
            treeView1.Nodes[1].Nodes[0].Nodes[1].Nodes.Add("Cefalopodos");

            treeView1.Nodes[1].Nodes[0].Nodes.Add("Equinodermos");

            treeView1.Nodes[1].Nodes.Add("Sin Protecccion Corporal");
            treeView1.Nodes[1].Nodes[1].Nodes.Add("Cnidarios");
            treeView1.Nodes[1].Nodes[1].Nodes.Add("Poriferos");
            treeView1.Nodes[1].Nodes[1].Nodes.Add("Gusanos");
            treeView1.Nodes[1].Nodes[1].Nodes[2].Nodes.Add("Anelidos");
            treeView1.Nodes[1].Nodes[1].Nodes[2].Nodes.Add("Nematodos");
            treeView1.Nodes[1].Nodes[1].Nodes[2].Nodes.Add("Platelmintos");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            treeView1.Nodes.Add(textBox1.Text);
            textBox1.Text = String.Empty;
            button3.Enabled = true;
            button4.Enabled = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(textBox1.Text))
            {
                button1.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(treeView1.SelectedNode != null)
            {
                treeView1.SelectedNode.Nodes.Add(textBox2.Text);
                textBox2.Text = String.Empty;
            }
            else
            {
                MessageBox.Show("Seleccione un nodo para agregar el elemento.");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                button2.Enabled = false;
            }
            else
            {
                button2.Enabled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(treeView1.Nodes.Count > 0)
            {
                treeView1.Nodes.Remove(treeView1.SelectedNode);
            }

            if (treeView1.Nodes.Count == 0)
            {
                button3.Enabled = false;
                button4.Enabled = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
            button3.Enabled = false;
            button4.Enabled = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
            CargarValoresArbol();
            button3.Enabled = true;
            button4.Enabled = true;
        }
    }
}
