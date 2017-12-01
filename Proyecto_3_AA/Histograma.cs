using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_3_AA
{
    class Histograma
    {
        public Dictionary<string, int> CalcularHistograma(List<string> pLista_nGram, List<string> pLista) // pLista es el n-gram de población o el poema meta
        {
            Dictionary<string, int> dic_Histograma = new Dictionary<string, int>();

            foreach (string item_gram in pLista_nGram) // n-grams de todos
            {
                if (!dic_Histograma.ContainsKey(item_gram))
                {
                    dic_Histograma.Add(item_gram, 0);
                }

                int contador = 0;
                foreach (string individuo in pLista)
                {
                    if (item_gram == individuo)
                    {
                        contador += 1;
                    }
                }
                if (contador != 0)
                {
                    dic_Histograma[item_gram] = contador;
                }
            }
            return dic_Histograma;
        }
    }
}
