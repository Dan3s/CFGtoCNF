using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;


namespace CFGtoCNF
{
    class Grammar
    {

        private Grammar actualGrammar;
        private Dictionary<String,Variable> variables;
        

        public Grammar(){
            variables = new Dictionary<String, Variable>();
            actualGrammar = new Grammar();
            
        }

         /**
         * Entrada de ejemplo
         * S abc
         */
        private void addVariables(String key, String pro){
           String[] cad = pro.Split('/');
            for(int i = 0; i<cad.Length; i++){
                //variables.Add(key, cad[i]);
            }
            
        }

        //T AL AN U

        public Variable[] Terminales() {
            Dictionary<String,String>  terminales1 = new Dictionary<String,String>();
            Dictionary<String,String>  terminales2 = new Dictionary<String,String>();

            //bool equal = terminales1.Keys.Count == terminales2.Keys.Count && terminales1.Keys.All(k => terminales2.ContainsKey(k) && object.Equals(terminales2[k], terminales1[k]));
 
            foreach(KeyValuePair<String, Variable> entry in variables)
            {
                Variable vari = entry.Value;
                if(vari.haveTerminal()){
                    terminales1.Add(entry.Key, entry.Key);
                }
                if(vari.haveLambda()){
                    terminales1.Add(entry.Key, entry.Key);
                }
            }
            for (int i = 0; i< variables.Count; i++) {
                for (int j = 0; j < variables.Count; j++) {
                   // variables[i]
                }
            }

            return null;
        }
       

        

      





    }
}
