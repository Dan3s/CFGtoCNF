using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
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

            //Grammar g = new Grammar();
            //g.addVariables("S", "aAb/cEB/CG");
            //g.addVariables("A", "dBG/ebC");
            //g.addVariables("B", "f/E");
            //g.addVariables("C", "gEB/ah");
            //g.addVariables("E", "dcGGGG/cE");
            //g.addVariables("G", "Gam");
            //Dictionary<String, String> terminales = g.Terminales();
            //Console.WriteLine("Terminales");
            //foreach (String key in terminales.Keys)
            //{
            //    Console.Write(key+" ");
            //}
            //Dictionary<String, String> noTerminales = g.NoTALA(terminales);
            //Console.WriteLine("\nNo Terminales");
            //foreach (String key in noTerminales.Keys)
            //{
            //    Console.Write(key + " ");
            //}
            //Console.WriteLine("\nNueva gramatica");
            //g.removerNoTALA(noTerminales);
            //foreach (String key in g.getVariables().Keys)
            //{
            //    Console.Write(key + " ");
            //}
            //Console.WriteLine();
            //Dictionary<String, String> alcanzables = g.Alcanzables();
            //Console.WriteLine("Alcanzables");
            //foreach (String key in alcanzables.Keys)
            //{
            //    Console.Write(key+" ");
            //}
            //Dictionary<String, String> noAlcanzables = g.NoTALA(alcanzables);
            //Console.WriteLine("\nNo Alcanzables");
            //foreach (String key in noAlcanzables.Keys)
            //{
            //    Console.Write(key + " ");
            //}
            //Console.WriteLine("\nNueva gramatica");
            //g.removerNoTALA(noAlcanzables);
            //foreach (String key in g.getVariables().Keys)
            //{
            //    Console.Write(key + " ");
            //}
            //Console.WriteLine();
            //Dictionary<String, String> anulables = g.Anulables();
            //Console.WriteLine("Anulables");
            //foreach (String key in anulables.Keys)
            //{
            //    Console.Write(key + " ");
            //}


            //g = new Grammar();
            //g.addVariables("S", "EA/SaBd/aEb");
            //g.addVariables("A", "DaD/bD/BEB");
            //g.addVariables("B", "bB/Ab/?");
            //g.addVariables("D", "aEb/ab");
            //g.addVariables("E", "aA/bB/?");
            //Console.WriteLine();
            //Dictionary<String, String> anulables2 = g.Anulables();
            //Console.WriteLine("Anulables");
            //foreach (String key in anulables2.Keys)
            //{
            //    Console.Write(key + " ");
            //}

            //g = new Grammar();
            //g.addVariables("S", "Ba/A/?");
            //g.addVariables("A", "Aa/a");
            //g.addVariables("B", "bB/S");
            //Dictionary<String, StringCollection> unitarias = g.Unitarias();
            //Console.WriteLine();
            //Console.WriteLine("Unitarias");
            //foreach (KeyValuePair<String, StringCollection> unit in unitarias)
            //{
            //    Console.WriteLine("Unitarias de: "+unit.Key);
            //    for (int i = 0; i < unit.Value.Count; i++)
            //    {
            //        Console.Write(unit.Value[i] + " ");
            //    }
            //    Console.WriteLine();
            //}
            //Console.WriteLine();
            //g.ReemplazarUnitarias(unitarias);
            //foreach (KeyValuePair<String, Variable> entry in g.getVariables())
            //{
            //    Console.Write(entry.Key + "->");
            //    for (int i = 0; i < entry.Value.GetProducciones().Count; i++)
            //    {
            //        Console.Write(entry.Value.GetProducciones()[i] + "/");
            //    }
            //    Console.WriteLine();
            //}
            // Console.WriteLine("hola");
            // Grammar g = new Grammar();
            // g.addVariables("S", "BCB");
            // g.addVariables("A", "aA/ab");
            // g.addVariables("B", "bBa/A/DC");
            // g.addVariables("C", "aCb/D/b");
            // g.addVariables("D", "aB/?");
            //// string anulables = g.anulablesKeys(g.Anulables());
            // //Console.WriteLine(anulables);
            // StringCollection anulabless = new StringCollection();
            // anulabless.Add("D");
            // anulabless.Add("B");
            // anulabless.Add("C");
            // anulabless.Add("S");
            // g.replaceAnulables(anulabless);
            // foreach (KeyValuePair<String, Variable> entry in g.getVariables())
            // {
            //     Console.Write(entry.Key + "->");
            //     for (int i = 0; i < entry.Value.GetProducciones().Count; i++)
            //     {
            //         Console.Write(entry.Value.GetProducciones()[i] + "/");
            //     }
            //     Console.WriteLine();
            // }
            // Console.ReadKey();

            Variable va = new Variable();
            va.producciones = new StringCollection();
           // va.producciones.Add("BCB");
            va.producciones.Add("BCB");
            va.producciones.Add("aA/ab");
            va.producciones.Add("bBa/A/DC");
            va.producciones.Add("aCb/D/b");
            va.producciones.Add("aB/?");

            va.replaceByOneAnulable("D");
            va.replaceByOneAnulable("B");
            va.replaceByOneAnulable("C");
            va.replaceByOneAnulable("S");
          
            //va.replaceByOneAnulable("C");
            //va.replaceByOneAnulable("B");
            for (int i = 0; i < va.producciones.Count; i++)
            {
                Console.WriteLine(va.producciones[i]);
            }
            //StringBuilder hola = new StringBuilder("hola");

            //hola.Remove(0,1);
            //hola.Insert(0,"p");
            //hola.Insert(1, "p");
            //string a = "abcde";
            //a.Remove(1);
            //char [] arra = a.ToCharArray();
            ////arra[2] = '';

            //Console.WriteLine(a.Remove(1,1));
            Console.ReadKey();



        }
    }
}
