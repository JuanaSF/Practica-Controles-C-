using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckedListBox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            string[] mylist = { "Yerba Mate", "1k de azucar", "1L de aceite" };
            checkedListBox1.Items.AddRange(mylist);


            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;

            //Propiedad para checkear un item sin tener que hacer doble click
            checkedListBox1.CheckOnClick = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (checkedListBox1.CheckedItems.Contains(textBox1.Text) == false)
                    checkedListBox1.Items.Add(textBox1.Text, CheckState.Checked);
                textBox1.Text = "";
            }

            button3.Enabled = true;
            button4.Enabled = true;
        }

        private void textBox1_TextChanged(object sender, System.EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
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
            listBox1.Items.Clear();
            for (int i = 0; i < checkedListBox1.CheckedItems.Count; i++)
            {
                listBox1.Items.Add(checkedListBox1.CheckedItems[i]);
            }
            button3.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Collections.IEnumerator myEnumerator;
            myEnumerator = checkedListBox1.CheckedIndices.GetEnumerator();
            int y;
            while (myEnumerator.MoveNext() != false)
            {
                y = (int)myEnumerator.Current;
                checkedListBox1.SetItemChecked(y, false);
            }
            button3.Enabled = false;
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Unchecked)
            {
                if (checkedListBox1.CheckedItems.Count == 1)
                {
                    button2.Enabled = false;
                    button3.Enabled = false;
                }
            }
            else
            {
                button2.Enabled = true;
                button3.Enabled = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            checkedListBox1.Items.Clear();
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
        }
    }
}
