using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CFGtoCNF
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            
            Grammar g = new Grammar();
            g.addVariables("S", "aAb/cEB/CG");
            g.addVariables("A", "dBG/ebC");
            g.addVariables("B", "f/E");
            g.addVariables("C", "gEB/ah");
            g.addVariables("E", "dcGGGG/cE");
            g.addVariables("G", "Gam");
            Dictionary<String, String> terminales = g.Terminales();
            foreach (String key in terminales.Keys)
            {
                Console.WriteLine(key);
            }
                
        }
    }
}
