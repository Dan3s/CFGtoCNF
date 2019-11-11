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
            Console.WriteLine("Terminales");
            foreach (String key in terminales.Keys)
            {
                Console.Write(key+" ");
            }
            Dictionary<String, String> noTerminales = g.NoTerminales(terminales);
            Console.WriteLine("\nNo Terminales");
            foreach (String key in noTerminales.Keys)
            {
                Console.Write(key + " ");
            }
            Console.WriteLine("\nNueva gramatica");
            g.removerNoTerminales(noTerminales);
            foreach (String key in g.getVariables().Keys)
            {
                Console.Write(key + " ");
            }
            Console.WriteLine();
            Dictionary<String, String> alcanzables = g.Alcanzables();
            Console.WriteLine("Alcanzables");
            foreach (String key in alcanzables.Keys)
            {
                Console.Write(key+" ");
            }
            Dictionary<String, String> noAlcanzables = g.NoTerminales(alcanzables);
            Console.WriteLine("\nNo Alcanzables");
            foreach (String key in noAlcanzables.Keys)
            {
                Console.Write(key + " ");
            }
            Console.WriteLine("\nNueva gramatica");
            g.removerNoTerminales(noAlcanzables);
            foreach (String key in g.getVariables().Keys)
            {
                Console.Write(key + " ");
            }

        }
    }
}
