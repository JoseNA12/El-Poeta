using System;
using System.Collections.Generic;
using System.Linq;


namespace Proyecto_3_AA
{
    class Adaptabilidad
    {
        public int CalculateDistanceManhattan(Dictionary<string, int> histogramasGenerados)
        {
            Dictionary<string, int>  histogramasMeta = Estructuras.instancia.dic_Histo_nGram_2_PoemaMeta;
            int resultado = 0;
            List<int> HMeta= new List<int>();
            List<int> HGenerado = new List<int>();

            foreach (KeyValuePair<string, int> item in histogramasMeta)
            {
                HMeta.Add(item.Value);
            }

            int contador = 0;
            foreach (KeyValuePair<string, int> itemGenerado in histogramasGenerados)
            {
                resultado += Math.Abs(HMeta[contador] - itemGenerado.Value);
                contador++;
            }
            return resultado;
        }
        
        public int CalculateDistanceChebyshev(Dictionary<string, int> histogramasGenerados)
        {
            Dictionary<string, int> histogramasMeta = Estructuras.instancia.dic_Histo_nGram_2_PoemaMeta;
            List<int> HMeta = new List<int>();
            List<int> HGenerado = new List<int>();
            List<int> resultadosLista = new List<int>();

            foreach (KeyValuePair<string, int> item in histogramasMeta)
            {
                HMeta.Add(item.Value);
            }

            int contador = 0;
            foreach (KeyValuePair<string, int> itemGenerado in histogramasGenerados)
            {
                resultadosLista.Add(Math.Abs(HMeta[contador] - itemGenerado.Value));
                contador++;
            }
            return resultadosLista.Max();
        }

        public int DistanciaPropia(Dictionary<string, int> histogramasGenerados)
        {
            Dictionary<string, int> histogramasMeta = Estructuras.instancia.dic_Histo_nGram_2_PoemaMeta;
            List<int> HMeta = new List<int>();
            List<int> HGenerado = new List<int>();

            int resultado = 0;

            foreach (KeyValuePair<string, int> item in histogramasMeta)
            {
                HMeta.Add(item.Value);
            }

            int contador = 0;
            foreach (KeyValuePair<string, int> itemGenerado in histogramasGenerados)
            {
                resultado += Math.Abs(Math.Max(Math.Abs(HMeta[contador]), Math.Abs(itemGenerado.Value)) / 2) - 1;
                contador++;
            }

            return resultado;
        }
    }
}
