using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_3_AA
{
    class N_Gram
    {
        private string texto;
        private int tamanioNGram;

        public N_Gram(string pTexto, int pTamanioNGram)
        {
            texto = pTexto;
            tamanioNGram = pTamanioNGram;
        }

        public List<string> Hacer_NGram(List<string> pLista_nGram)
        {
            // Dictionary<string, int> nGrams = new Dictionary<string, int>(); // Crear la tupla vacia (resultado)
            string gram = ""; // Las palabras concatenadas

            string[] palabras = texto.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < palabras.Count(); i++)
            {
                if (i + tamanioNGram > palabras.Count())
                {
                    break; // La cantidad de palabras restantes no son equivalentes al tamaño del n-gram solicitado
                }

                gram += palabras[i];

                if (tamanioNGram > 1)
                {
                    for (int ii = 1; ii < tamanioNGram; ii++)
                    {
                        gram += " " + palabras[i + ii];
                    }
                }

                pLista_nGram.Add(gram); // pDic_nGram.Count + 1; // El tamaño n-gram es 1: 1-gram
                gram = "";
            }

            return pLista_nGram;
        }
    }
}
