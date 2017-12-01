using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_3_AA
{
    class Estructuras
    {
        public static Estructuras instancia = new Estructuras();

        public List<string> lista_nGram_1 = new List<string>();
        public List<string> lista_nGram_2 = new List<string>();
        public List<string> lista_nGram_3 = new List<string>();

        public List<string> lista_nGram_1_Poema = new List<string>();
        public List<string> lista_nGram_2_Poema = new List<string>();
        public List<string> lista_nGram_3_Poema = new List<string>();

        public List<Dictionary<string, int>> listaHistogramas_PoemaMeta; // = new List<Dictionary<string, int>>();
        public Dictionary<string, int> dic_Histo_nGram_1_PoemaMeta; // = new Dictionary<string, int>();
        public Dictionary<string, int> dic_Histo_nGram_2_PoemaMeta; // = new Dictionary<string, int>();
        public Dictionary<string, int> dic_Histo_nGram_3_PoemaMeta; // = new Dictionary<string, int>();


        public void IniciarEstructuras_PoemasMeta()
        {
            listaHistogramas_PoemaMeta = new List<Dictionary<string, int>>();
            dic_Histo_nGram_1_PoemaMeta = new Dictionary<string, int>();
            dic_Histo_nGram_2_PoemaMeta = new Dictionary<string, int>();
            dic_Histo_nGram_3_PoemaMeta = new Dictionary<string, int>();
        }

        public void AsignarEstructuras_PoemasMeta(Dictionary<string, int> dic_1, 
                                             Dictionary<string, int> dic_2, Dictionary<string, int> dic_3)
        {
            dic_Histo_nGram_1_PoemaMeta = dic_1;
            dic_Histo_nGram_2_PoemaMeta = dic_2;
            dic_Histo_nGram_3_PoemaMeta = dic_3;

            listaHistogramas_PoemaMeta.Add(dic_1);
            listaHistogramas_PoemaMeta.Add(dic_2);
            listaHistogramas_PoemaMeta.Add(dic_3);
        }

        public void Agregar_nGrams(List<string> pDic_nGram_1, List<string> pDic_nGram_2, List<string> pDic_nGram_3)
        {
            lista_nGram_1 = pDic_nGram_1;
            lista_nGram_2 = pDic_nGram_2;
            lista_nGram_3 = pDic_nGram_3;
        }

        public void Agregar_nGrams_PoemaMeta(List<string> pDic_nGram_1, List<string> pDic_nGram_2, List<string> pDic_nGram_3)
        {
            lista_nGram_1_Poema = pDic_nGram_1;
            lista_nGram_2_Poema = pDic_nGram_2;
            lista_nGram_3_Poema = pDic_nGram_3;
        }

        // *** MOSTRADOS DE DATOS ***

        public void MostrarLista(HashSet<string> pLista)
        {
            foreach(var item in pLista)
            {
                Console.WriteLine(item);
            }
        }

        public void MostrarDiccionario_int_list(Dictionary<int, List<string>> pDiccionario) // N-grams
        {
            foreach (KeyValuePair<int, List<string>> item in pDiccionario)
            {
                Console.WriteLine("Key = {0}, Value = {1}", item.Key, item.Value);
                foreach (var palabra in item.Value)
                {
                    Console.WriteLine(palabra);
                }
            }
        }

        public void MostrarDiccionario_string_int(Dictionary<string, int> pDiccionario) // N-grams
        {
            foreach (KeyValuePair<string, int> item in pDiccionario)
            {
                Console.WriteLine("Key = {0}, Value = {1}", item.Key, item.Value);
                foreach (var palabra in item.Value.ToString())
                {
                    //Console.WriteLine(palabra);
                }
            }
            Console.WriteLine("\n");
        }
    }
}
