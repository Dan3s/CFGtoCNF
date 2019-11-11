using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;


namespace CFGtoCNF
{
    class Grammar
    {

        public Grammar actualGrammar;
        public Dictionary<string, Variable> variables;
        public Dictionary<string, string> letras;


        public Grammar(){
            variables = new Dictionary<string, Variable>();
            letras = new Dictionary<string, string>();
            //actualGrammar = new Grammar();

        }

        public Dictionary<string, Variable> getVariables()
        {
            return variables;
        }
        /**
        * Entrada de ejemplo
        * S abc
        */
        public void addVariables(String key, String pro)
        {
            if (!letras.ContainsKey(key))
            {
                letras.Add(key, key);
            }
            String[] cad = pro.Split('/');
            Variable variable = new Variable();
            for (int i = 0; i < cad.Length; i++)
            {
                variable.addProduction(cad[i]);
            }
            variables.Add(key, variable);

        }

        public void convertToCNF()
        {

        }

        //T AL AN U


        /**
         * Método para calcular las variables terminales
         */
        public Dictionary<String, String> Terminales()
        {
            Dictionary<String, String> terminales1 = new Dictionary<String, String>();
            Dictionary<String, String> terminales2 = new Dictionary<String, String>();
            bool equal = false;
            foreach (KeyValuePair<String, Variable> entry in variables)
            {
                
                if (entry.Value.haveTerminal())
                {
                    
                    terminales1.Add(entry.Key, entry.Key);
                }
                if (entry.Value.haveLambda())
                {
                    
                    terminales1.Add(entry.Key, entry.Key);
                }
            }

            while (!equal)
            {
                
                foreach (KeyValuePair<String, String> entry in terminales1)
                {
                    String valor = entry.Value;
                    if (!terminales2.ContainsKey(entry.Key))
                    {
                        terminales2.Add(entry.Key, entry.Key);
                    }
                        
                    foreach (KeyValuePair<String, Variable> variable in variables)
                    {
                        
                        if (variable.Value.canReach(valor))
                        {
                            
                            if (!terminales2.ContainsKey(variable.Key))
                            {
                                
                                terminales2.Add(variable.Key, variable.Key);
                                
                            }
                            
                        }
                        
                    }

                    
                }
                equal = sameDictionary(terminales1, terminales2);
                
                terminales1 = new Dictionary<string, string>(terminales2);
            }
            return terminales2;
        }
        /**
         * Método para saber cuáles variables son no Terminales, no Alcanzables o anulables de la gramática
         */
        public Dictionary<String, String> NoTALA(Dictionary<String, String> terminales)
        {
            Dictionary<String, String> noTerminales = new Dictionary<string, string>(letras);
            foreach (KeyValuePair<String, String> term in terminales)
            {
                noTerminales.Remove(term.Value);
                //if (term.Value.Equals(noTerminales[term.Key])){
                //    noTerminales.Remove(term.Value);
                //}
            }
            return noTerminales;     
        }
        /**
         * Método para eliminar variables no Terminales, no Alcanzables o anulables de la gramática
         */
        public void removerNoTALA(Dictionary<String, String> noTerminales)
        {
            foreach (KeyValuePair<String, String> nTerm in noTerminales)
            {
                variables.Remove(nTerm.Key);
            }
            foreach (KeyValuePair<String, Variable> entry in variables)
            {
                foreach (KeyValuePair<String, String> nTerm in noTerminales)
                {
                    entry.Value.removerProduccion(nTerm.Value);
                }
                

            }
        }
        /**
        * Método para calcular las variables Alcanzables
        */
        public Dictionary<String, String> Alcanzables()
        {
            Dictionary<String, String> alcanzables = new Dictionary<string, string>();
            Dictionary<String, String> alcanzables2 = new Dictionary<String, String>();
            //S siempre va a ser alcanzable
            alcanzables.Add("S", "S");
            
            bool equal = false;

            while (!equal)
            {

                foreach (KeyValuePair<String, String> entry in alcanzables)
                {
                    String valor = entry.Value;
                    if (!alcanzables2.ContainsKey(entry.Key))
                    {
                        alcanzables2.Add(entry.Key, entry.Key);
                    }
                    StringCollection alcan = variables[entry.Value].Reachables();
                    for (int i = 0; i < alcan.Count; i++)
                    {
                        if (!alcanzables2.ContainsKey(alcan[i]))
                        {
                            alcanzables2.Add(alcan[i], alcan[i]);
                        }
                    }


                }
                equal = sameDictionary(alcanzables, alcanzables2);

                alcanzables = new Dictionary<string, string>(alcanzables2);
            }

            return alcanzables2;
        }
        /**
        * Método para calcular las variables Alcanzables
        */
        public Dictionary<String, String> Anulables()
        {
            Dictionary<String, String> anulables = new Dictionary<string, string>();
            Dictionary<String, String> anulables2 = new Dictionary<string, string>();
            bool equal = false;
            foreach (KeyValuePair<String, Variable> entry in variables)
            {
                if (entry.Value.haveLambda())
                {
                    anulables.Add(entry.Key, entry.Key);
                }
            }
            
            while (!equal)
            {


                //if (!anulables2.ContainsKey(entry.Key))
                //{
                //    anulables2.Add(entry.Key, entry.Key);
                //}
                anulables2 = new Dictionary<string, string>(anulables);
                    foreach (KeyValuePair<String, Variable> variable in variables)
                    {
                        
                        if (variable.Value.haveAnulable(anulables))
                        {
                            if (!anulables2.ContainsKey(variable.Key))
                            {
                                
                                anulables2.Add(variable.Key, variable.Key);
                            }
                            
                        }
                        //if (variable.Value.canReach(valor))
                        //{

                        //    if (!anulables2.ContainsKey(variable.Key))
                        //    {

                        //        anulables2.Add(variable.Key, variable.Key);

                        //    }

                        //}

                    }


                
                equal = sameDictionary(anulables, anulables2);

                anulables = new Dictionary<string, string>(anulables2);
            }
            return anulables;
        }

        public Dictionary<string, StringCollection> Unitarias()
        {
            Dictionary<string, StringCollection> unitarias = new Dictionary<string, StringCollection>();
            bool equal = false;
            foreach (KeyValuePair<String, Variable> variable in variables)
            {
                StringCollection unit = new StringCollection();
                
                unit = variable.Value.Unitarias();
                
                StringCollection unit2 = unit;
                while (!equal)
                {                    
                    for (int i = 0; i < unit.Count; i++)
                    {
                        unit2 = variables[unit[i]].Unitarias(unit);
                    }

                    if (unit.Equals(unit2))
                    {
                        equal = true;
                        unit = unit2;
                    }
                    else
                    {
                        unit = unit2;
                    }
                }
                unit.Add(variable.Key);
                unitarias.Add(variable.Key, unit);
                
            }



            return unitarias;
        }

        public void ReemplazarUnitarias(Dictionary<string, StringCollection> unitarias)
        {
            foreach (KeyValuePair<String, Variable> variable in variables)
            {
                StringCollection unit = unitarias[variable.Key];
                for (int i = 0; i < unit.Count; i++)
                {
                    variable.Value.ReemplazarUnitarias(unit[i], variables[unit[i]]);
                }
                    
            }
        }

        public void imprimirDict(Dictionary<string, string> di)
        {
            Console.Write("Anulables: ");
            foreach (KeyValuePair<String, string> variable in di)
            {
                Console.Write(variable.Key);
            }
            Console.WriteLine();

        }

        public bool sameDictionary(Dictionary<String, String> terminales1, Dictionary<String, String> terminales2)
        {
            bool result = true;

            if (terminales1.Count == terminales2.Count)
            {
                foreach (var key in terminales2.Keys)
                {
                    if (!(terminales1[key].Equals(terminales2[key])))
                    {
                        result = false;
                    }

                }
            }
            else
            {
                result = false;
            }
            return result;
        }



       






    }
}
