using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;


namespace CFGtoCNF
{
    class Grammar
    {

        public Grammar actualGrammar;
        public Dictionary<string, Variable> variables;
        

        public Grammar(){
            variables = new Dictionary<string, Variable>();
            //actualGrammar = new Grammar();
            
        }

        /**
        * Entrada de ejemplo
        * S abc
        */
        public void addVariables(String key, String pro)
        {
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

        public Dictionary<String, String> NoTerminales(Dictionary<String, String> terminales)
        {
            Dictionary<String, String> noTerminales = new Dictionary<string, string>();

            return noTerminales;
                
                
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
