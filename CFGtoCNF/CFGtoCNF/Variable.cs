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
        public StringCollection  producciones;
        //Diccionario de minusculas que se van a usar para reemplazar las terminales en la gramática final
        //Va desde n(110) hasta z(122)
        //La llave es la minuscula antigua y el valor la nueva
        private Dictionary<char, char> minusculasReemplazar;

        public Variable()
        {
            producciones = new StringCollection();
            minusculasReemplazar = new Dictionary<char, char>();
        }

        public StringCollection GetProducciones()
        {
            return producciones;
        }
        public void addProduction(String pro)
        {
            producciones.Add(pro);
        }

        public void llenarMinusculas()
        {
            for (int i = 97; i <= 109; i++)
            {
                char key = (char)i;
                char value = (char)(i + 13);
                minusculasReemplazar.Add(key, value);
            }
        }

        public StringCollection buscarMinisculas(StringCollection minusculasActuales)
        {

            for (int i = 0; i < producciones.Count; i++)
            {
                if (producciones[i].Length > 1)
                {
                    for (int j = 0; j < producciones[i].Length; j++)
                    {
                        if (isSmallLetter(producciones[i][j]) && !minusculasActuales.Contains(producciones[i][j] + ""))
                        {
                            minusculasActuales.Add(producciones[i][j] + "");
                        }
                    }
                }
                
            }
            
                
            return minusculasActuales;

        }

        public void removerProduccion(String eliminar)
        {
            for (int i = 0; i < producciones.Count; i++)
            {
                if(producciones[i].Contains(eliminar))
                {
                    producciones.RemoveAt(i);
                }
            }
        }
        public bool canReach(String valor)
        {
            bool result = false;
            bool stop = false;

            for (int i = 0; i < producciones.Count && !stop; i++)
            {
                for (int j = 0; j < producciones[i].Length && !stop; j++)
                {
                    
                    
                    String compa = producciones[i][j]+"";
                    if (isBigLetter(producciones[i][j]) && compa.Equals(valor))
                    {
                        
                        result = true;
                        stop = true;
                    }
                }
            }
            return result;
        }
        public bool haveAnulable(Dictionary<String, String> anulables)
        {
            bool result = false;
            bool stop = false;
            for (int i = 0; i < producciones.Count && !stop; i++)
            {
                if (producciones[i].Length == 1 && isBigLetter(producciones[i][0]))
                {

                    result = true;
                    stop = true;
                }
                else
                {
                    bool stop1 = false;
                    for (int j = 0; j < producciones[i].Length && !stop1; j++)
                    {
                       
                        if (isSmallLetter(producciones[i][j]))
                        {
                            result = false;
                            stop1 = true;
                        }
                        else
                        {

                            String compa = producciones[i][j] + "";
                            if (anulables.ContainsKey(compa))
                            {
                                result = true;
                            }
                            else
                            {
                                result = false;
                                stop1 = true;
                            }
                            
                        }
                    }
                    if (result)
                    {
                        stop = true;
                    }

                }
            }

            return result;
        }
         public bool haveTerminal()
        {
            bool result = false;
            bool stop = false;
            for (int i = 0; i < producciones.Count && !stop; i++)
            {
                if (producciones[i].Length == 1 && isSmallLetter(producciones[i][0]))
                {
                    
                    result = true;
                    stop = true;
                }
                else
                {
                    
                    bool stop1 = false;
                    for (int j = 0; j < producciones[i].Length && !stop1; j++)
                    {
                        
                        if (isBigLetter(producciones[i][j]))
                        {
                            result = false;
                            stop1 = true;
                        }
                        else
                        {
                            result = true; 
                        }
                    }
                }
            }
            return result;
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

        public void replaceByOneAnulable(String anulable) {
            for (int i = 0; i < producciones.Count; i++) {
                for (int j = 0; j < producciones[i].Length; j++) {
                    String compa = producciones[i][j] + "";
                    if (compa.Equals(anulable)||compa.Equals("?")) {
                        
                        StringBuilder nuevaProduccion = new StringBuilder(producciones[i].Remove(j,1));
                        nuevaProduccion.Insert(j, "");


                        
                        if (!producciones.Contains(nuevaProduccion.ToString()) || !(nuevaProduccion.Equals(anulable)))
                        {
                            producciones.Add(nuevaProduccion.ToString());

                        }
                       
                            
                        
                    }
                    if (compa.Equals(" ")) {
                        StringBuilder nuevaProduccion = new StringBuilder(producciones[i].Remove(j, 1));
                        nuevaProduccion.Insert(j, "?");

                    }
                }
            }
        }

        public void replaceAllAnulables(String anulables)
        {
            string produccion = "";
            string pro = producciones.ToString();
            for (int i = 0; i < producciones.Count; i++)
            {
                produccion = producciones[i];
                for (int j = 0; j < produccion.Length; j++)
                {
                    for (int z = 0; z < anulables.Length; z++)
                    {
                        if (anulables[z].ToString().Equals(produccion[j]))
                        {
                            produccion.Insert(j, "");
                        }
                    }



                }

            }

            if (!producciones.Contains(produccion))
            {
                addProduction(produccion);
            }
        }

        //private string changeCharacter(StringCollection cad, string value)
        //{
        //    cad.re
        //    for (int i = 0; i < cad.Count; i++)
        //    {
        //        if (cad[i] == value[0])
        //        {

        //        }
        //    }
        //}

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
        public StringCollection Unitarias(StringCollection unitarias)
        {
            

            for (int i = 0; i < producciones.Count; i++)
            {
                if (producciones[i].Length == 1 && isBigLetter(producciones[i][0]))
                {
                    String compa = producciones[i][0] + "";
                    if (!unitarias.Contains(compa))
                    {
                        unitarias.Add("" + producciones[i][0]);
                    }
                    
                }
            }

            return unitarias;
        }
        public void ReemplazarUnitarias(String unitaria, Variable var)
        {
            for (int i = 0; i < producciones.Count; i++)
            {
                String compa = producciones[i][0] + "";
                if (producciones[i].Length == 1 && isBigLetter(producciones[i][0]) && compa.Equals(unitaria))
                {
                    producciones.RemoveAt(i);
                    
                    for (int j = 0; j < var.GetProducciones().Count; j++)
                    {
                        producciones.Add(var.GetProducciones()[j]);
                    }
                    

                }
            }
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
        //Las letras minusculas van desde a(97) hasta m(109)
        public bool isSmallLetter(char digit)
        {

            if ((digit >= 97 && digit <= 109)|| digit == 63)
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
