using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebBrowser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "http://www.google.com";
            webBrowser1.Navigate("http://www.google.com");
        }

        List<string> links = new List<string>();

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Marca que el link ya fue visitado y cambia su color
            this.linkLabel1.LinkVisited = true;

            // Abre una ventana del navegador
            System.Diagnostics.Process.Start("https://ucema.edu.ar/");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            webBrowser1.Navigate("https://ucema.edu.ar/");
        }

        private void NavegarConWebBrowser(object sender, EventArgs e)
        {
            try
            {
                webBrowser1.Navigate(textBox1.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            if(links.Count == 0)
            {
                links.Add(webBrowser1.Url.ToString());
            }
            else
            {
                bool isNew = false;

                for(int i = 0; i < links.Count; i++)
                {
                    if (links[i].Equals(webBrowser1.Url.ToString()))
                    {
                        isNew = false;
                        break;
                    }
                    else
                    {
                        isNew = true;
                    }
                }

                if (isNew)
                {
                    links.Add(webBrowser1.Url.ToString());
                    int i = 0;
                    vistoRecientementeToolStripMenuItem.DropDownItems.Clear();
                    links.ForEach(l => {
                        vistoRecientementeToolStripMenuItem.DropDownItems.Add(l.ToString());
                        vistoRecientementeToolStripMenuItem.DropDownItems[i].Click += new EventHandler(ClickMenuItemHistorial);
                        i++;
                    });
                }
            }
        }

        private void ClickMenuItemHistorial(object sender, EventArgs e)
        {
            try
            {
                webBrowser1.Navigate(sender.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
