using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace CFGtoCNF
{
    class Variable
    {
        //En cada posicion una produccion de la forma aa ó AA ó aA ó A ó a ó lambda
        private  StringCollection  producciones;

         public bool haveTerminal()
        {

            for (int i = 0; i < producciones.Count; i++)
            {
                if (producciones[i].Length == 1 && isSmallLetter(producciones[i][0]))
                {
                    return true;
                }
            }
            return false;
        }

        //Anulables
        public bool haveLambda()
        {

            for (int i = 0; i < producciones.Count; i++)
            {
                if (producciones[i].Length == 1 && producciones[i].Equals("?")) {
                    return true;
                }
            }
            return false;
        }

        //Unitarias
        public StringCollection Unitarias()
        {
			StringCollection unitarias = new StringCollection();

            for (int i = 0; i < producciones.Count; i++)
            {
                if (producciones[i].Length == 1 && isBigLetter(producciones[i][0]))
                {
                    unitarias.Add(""+producciones[i][0]);
                }
            }
            return unitarias;
        }

        //Alcanzables
        //Retorna las alcanzables de la produccion
        public StringCollection Reachables()
        {
            StringCollection alcanzables = new StringCollection();
            for (int i = 0; i < producciones.Count; i++)
            {
                for (int j = 0; j < producciones[i].Length; j++)
                {

                    if (isBigLetter(producciones[i][j]) && !alcanzables.Contains(""+producciones[i][j]))
                    {
                        alcanzables.Add(""+producciones[i][j]);
                    }
                }
            }
            return alcanzables;
        }






        //Mayusculas/variables
        public bool isBigLetter(char digit)
        {

            if (digit >= 65 && digit <= 90)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        //Minusculas/terminables
        // Lambda es '?'
        public bool isSmallLetter(char digit)
        {

            if ((digit >= 97 && digit <= 122)|| digit == 63)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
		
	//public static void Main()
	//{
	//	Console.WriteLine(isBigLetter('P'));
	//	producciones = new StringCollection();
	//	producciones.Add("ABC");
	//	producciones.Add("BaC");
	//	producciones.Add("aB");
	//	producciones.Add("F");
	//	producciones.Add("a");
	//	producciones.Add("P");
	//	producciones.Add("q");
	//	Console.WriteLine(producciones.Count);
	//	StringCollection bal = Reachables();
	//	StringCollection lab = Unitarias();
		
	//	//for(int i = 0; i < bal.Count; i++){
	//	//	Console.WriteLine(bal[i]);
	//	//}
	//	for(int i = 0; i < lab.Count; i++){
	//		Console.WriteLine(lab[i]);
	//	}
		
	//}

    }
}
