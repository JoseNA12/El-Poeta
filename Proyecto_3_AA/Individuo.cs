using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_3_AA
{
    class Individuo
    {
        private string texto;
        private int distancia;
        private int probabilidad;
        public Individuo(string pTexto, int pDistancia)
        {
            texto = pTexto;
            distancia = pDistancia;
        }

        public string getTexto()
        {
            return texto;
        }
        public int getDistancia()
        {
            return distancia;
        }
        public int getProbabilidad()
        {
            return probabilidad;
        }
        public void setDistancia(int pDistancia) { distancia = pDistancia; }
        public void setProbabilidad(int proba) { probabilidad = proba; }

    }
}
