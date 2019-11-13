using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CFGtoCNF
{
    public partial class Form1 : Form
    {
        static Grammar g = new Grammar();
        
        public Form1()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dictionary<String, String> terminales = g.Terminales();

            Dictionary<String, String> noTerminales = g.NoTALA(terminales);

            g.removerNoTALA(noTerminales);

            textBox1.AppendText(leerGramatica().ToString());

            textBox1.AppendText("\r\n");


            
        }

        private StringBuilder leerGramatica() {
            StringBuilder grama = new StringBuilder();
            foreach (KeyValuePair<String, Variable> entry in g.getVariables())
            {
                
                grama.Append(entry.Key + "->");

                for (int i = 0; i < entry.Value.GetProducciones().Count; i++)
                {
                    grama.Append(entry.Value.GetProducciones()[i] + "/");
                }

            }
            return grama;
        }

        private void label1_Click(object sender, EventArgs e)
        {
           
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string [] data = getEntrada(textBox2.Text);
            g.addVariables(data[0], data[1]);
            textBox1.ResetText();
            
        }

        private string[] getEntrada(string entry) {
            string[] data = entry.Split('>');
            return data;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
