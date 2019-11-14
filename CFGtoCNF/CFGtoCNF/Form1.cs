using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
            textBox1.Text = "Gramática Original\n";
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dictionary<String, String> terminales = g.Terminales();

            Dictionary<String, String> noTerminales = g.NoTALA(terminales);
            

            g.removerNoTALA(noTerminales);
            textBox1.Text += "Gramática Terminal\n";
            foreach (KeyValuePair<String, Variable> entry in g.getVariables())
            {
                textBox1.Text += (entry.Key + "->");
                for (int i = 0; i < entry.Value.GetProducciones().Count; i++)
                {
                    textBox1.Text += (entry.Value.GetProducciones()[i] + "/");
                }
                textBox1.Text += "\n";
            }

            Dictionary<String, String> alcanzables = g.Alcanzables();
            Dictionary<String, String> noAlcanzables = g.NoTALA(alcanzables);
            g.removerNoTALA(noAlcanzables);
            textBox1.Text += "Gramática Alcanzable\n";
            foreach (KeyValuePair<String, Variable> entry in g.getVariables())
            {
                textBox1.Text += (entry.Key + "->");
                for (int i = 0; i < entry.Value.GetProducciones().Count; i++)
                {
                    textBox1.Text += (entry.Value.GetProducciones()[i] + "/");
                }
                textBox1.Text += "\n";
            }

            string anulabless = g.anulablesKeys(g.Anulables());
            g.replaceAnulables(anulabless);
            textBox1.Text += "Gramática Anulable\n";
            foreach (KeyValuePair<String, Variable> entry in g.getVariables())
            {
                textBox1.Text += (entry.Key + "->");
                for (int i = 0; i < entry.Value.GetProducciones().Count; i++)
                {
                    textBox1.Text += (entry.Value.GetProducciones()[i] + "/");
                }
                textBox1.Text += "\n";
            }

            Dictionary<String, StringCollection> unitarias = g.Unitarias();
            g.ReemplazarUnitarias(unitarias);
            textBox1.Text += "Gramática Unitaria\n";
            foreach (KeyValuePair<String, Variable> entry in g.getVariables())
            {
                textBox1.Text += (entry.Key + "->");
                for (int i = 0; i < entry.Value.GetProducciones().Count; i++)
                {
                    textBox1.Text += (entry.Value.GetProducciones()[i] + "/");
                }
                textBox1.Text += "\n";
            }
            //textBox1.Text += leerGramatica().ToString() + Environment.NewLine;

            //textBox1.AppendText("\r\n");



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
            string produc = textBox2.Text;
            string [] data = getEntrada(produc);
            textBox1.Text += produc+"\n";
            g.addVariables(data[0], data[1]);
            textBox2.Text = "";
            //textBox1.ResetText();
            
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

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox1.Text = "";
            g = new Grammar();
        }
    }
}
