
using System;
using System.Collections.Generic;
using System.Linq;


namespace Proyecto_3_AA
{

    class A_Genetico
    {
        private int k_nGrams;
        private int generaciones;
        private string tipoRecorrido;
        private List<string> poblacionInicial = new List<string>();

        public Adaptabilidad instanciaAdaptabilidad = new Adaptabilidad();

        public List<string> lista_nGram_1 = new List<string>();
        public List<string> lista_nGram_2 = new List<string>();
        public List<string> lista_nGram_3 = new List<string>();

        public Dictionary<string, int> dic_Histo_nGram_1_Generado = new Dictionary<string, int>();
        public Dictionary<string, int> dic_Histo_nGram_2_Generado = new Dictionary<string, int>();
        public Dictionary<string, int> dic_Histo_nGram_3_Generado = new Dictionary<string, int>();

        public Dictionary<string, int> dic_Distancias_nGram_2 = new Dictionary<string, int>();
        public Dictionary<string, int> dic_Ordenado = new Dictionary<string, int>();

        public Random indiceRandom = new Random();
        List<string> hijos = new List<string>();

        Random rnd_grams = new Random();
        Random rnd_cromosomas = new Random();

        public Random cantidadGenes = new Random();
        public Random cantidadIndividuos = new Random();
        public List<Individuo> poblacion = new List<Individuo>();

        public int cantidadElementosPoblacion;
        public Random porcentajeRandom = new Random();
        public int porcentajeMayor = 0;

        List<Individuo> hijosCruce = new List<Individuo>();
        List<int> Porcentaje = new List<int>();


        public A_Genetico(int pK_nGrams, int pNoGeneraciones, string pTipoRecorrido)
        {
            k_nGrams = pK_nGrams;
            generaciones = pNoGeneraciones;
            tipoRecorrido = pTipoRecorrido;
        }

        public List<Individuo> IniciarProcesoGenetico()
        {
            CrearPoblacionInicial();

            //While. A partir de aqui "población" se irá modificando, por lo que no hay que llamar alguna función de crearPoblación
            while (0 < generaciones)
            {
                // Console.WriteLine("Generación: " + generaciones);

                // Console.WriteLine("\n ******************* POBLACION ACTUAL: " + poblacion.Count);
                // Console.WriteLine("\n ******************* GENERACION: " + generaciones);

                for (int i = 0; i < poblacion.Count; i++)
                {
                    N_Gram ngram = new N_Gram(poblacion[i].getTexto(), 2);

                    List<string> lista = ngram.Hacer_NGram(new List<string>());
                    Histograma histograma = new Histograma();
                    Dictionary<string, int> dic_Histograma = new Dictionary<string, int>();
                    // Console.WriteLine("Empezó");
                    dic_Histograma = histograma.CalcularHistograma(Estructuras.instancia.lista_nGram_2, lista);
                    // Console.WriteLine("Terminó");

                    int distancia = Adaptabilidad(dic_Histograma);
                    poblacion[i].setDistancia(distancia);
                }

                // Console.WriteLine("Primer for. Listo!");

                AsignarProbabilidades();
                int contador = poblacion.Count;
                for (int i = 0; i < contador; i += 2)
                {
                    // Console.WriteLine("\nCantidad Individuos: " + poblacion.Count);
                    // Console.WriteLine("\nPareja 1 Elección: ");     
                    Individuo pareja_1 = null;
                    while (pareja_1 == null)
                    {
                        if (poblacion.Count == 0)
                        {
                            // Console.WriteLine("No quedo nadie");
                            break;
                        }
                        else
                        {
                            pareja_1 = SeleccionarIndividuo();
                        }
                    }

                    // Console.WriteLine("\nPareja 2 Elección: ");
                    Individuo pareja_2 = null;
                    while (pareja_2 == null)
                    {
                        if (poblacion.Count == 0)
                        {
                            // Console.WriteLine("No quedo nadie");
                            break;
                        }
                        else
                        {
                            pareja_2 = SeleccionarIndividuo();
                        }
                    }

                    if ((pareja_1 != null) & (pareja_2 != null))
                    {
                        /*Console.WriteLine("\n******************Inicio del Cruce******************");
                        Console.WriteLine("***Pareja 1***");
                        Console.WriteLine("\nPareja 1 Texto: " + pareja_1.getTexto());
                        Console.WriteLine("\nPareja 1 Distancia: " + pareja_1.getDistancia());
                        Console.WriteLine("\nPareja 1 Proba: " + pareja_1.getProbabilidad());

                        Console.WriteLine("***Pareja 2***");
                        Console.WriteLine("\nPareja 2 Texto: " + pareja_2.getTexto());
                        Console.WriteLine("\nPareja 2 Distancia: " + pareja_2.getDistancia());
                        Console.WriteLine("\nPareja 2 Proba: " + pareja_2.getProbabilidad());*/

                        CruzarPareja(pareja_1, pareja_2);
                    }
                }

                // Console.WriteLine("Segundo for. Listo!");

                poblacion = hijosCruce;
                hijosCruce = new List<Individuo>();
                int indice = (int)indiceRandom.Next(0, poblacion.Count);
                Mutaciones(poblacion[indice]);  //Mutar a un random
                generaciones--;
            }

            // DEVOLVER LOS INDIVIDUOS MAS APTOS
            List<int> distanciasFinales = new List<int>();
            List<Individuo> individuosPrometedores = new List<Individuo>();

            for (int i = 0; i < poblacion.Count; i++)
            {
                N_Gram ngram = new N_Gram(poblacion[i].getTexto(), 2);

                List<string> lista = ngram.Hacer_NGram(new List<string>());
                Histograma histograma = new Histograma();
                Dictionary<string, int> dic_Histograma = new Dictionary<string, int>();
                dic_Histograma = histograma.CalcularHistograma(Estructuras.instancia.lista_nGram_2, lista);

                int distancia = Adaptabilidad(dic_Histograma);
                poblacion[i].setDistancia(distancia);

                distanciasFinales.Add(distancia);
            }

            distanciasFinales.Sort();

            for (int i = 0; i < 3; i++)
            {
                individuosPrometedores.Add(poblacion.Find(x => x.getDistancia() == distanciasFinales[i]));
                poblacion.Remove(individuosPrometedores[i]);
            }
            return individuosPrometedores;
        }

        public void AsignarProbabilidades()
        {
            int distancia_total = 0;
            int porcentaje_Temp = 0;
            for (int i = 0; i < poblacion.Count; i++)
            {
                distancia_total += poblacion[i].getDistancia();
            }

            List<int> Distancia = new List<int>();
            
            for (int i = 0; i < poblacion.Count; i++)
            {
                porcentaje_Temp = (int)(poblacion[i].getDistancia() * 100) / distancia_total;
                Distancia.Add(poblacion[i].getDistancia());
                Porcentaje.Add(porcentaje_Temp);
            }

            Distancia.Sort();
            Porcentaje.Sort();
            Porcentaje.Reverse();
            for(int i = 0; i < Distancia.Count; i++)
            {
                Individuo ind = poblacion.Find(x => x.getDistancia() == Distancia[i]);
                Individuo temp = ind;

                poblacion.Remove(temp);

                ind.setProbabilidad(Porcentaje[i]);

                poblacion.Add(ind);

                // Console.WriteLine("\nElemento: " + ind.getDistancia() + " Probabilidad: " + ind.getProbabilidad());
                porcentajeMayor += ind.getProbabilidad();
            }
        }
    
        public Individuo SeleccionarIndividuo()
        {
            int NumRandom = porcentajeRandom.Next(1, porcentajeMayor);
            int suma = 0;
            for (int i = 0; i < poblacion.Count; i++)
            {
                suma = suma + poblacion[i].getProbabilidad();
                if (NumRandom <= suma)
                {
                    Individuo temp = poblacion[i];
                    poblacion.Remove(poblacion[i]);
                    return temp;
                }
            }
            return null;         
        }

        private void CrearPoblacionInicial()
        {
            cantidadElementosPoblacion = cantidadIndividuos.Next(5, 20);  //Cantidad de individuos
            int numeroGenes = 0; //Cantidad de ngrams del texto
            int indiceGram = 0;
            string texto = "";

            for (int i = 0; i < cantidadElementosPoblacion; i++) //Recorrer cant individuos
            {
                texto = "";
                numeroGenes = cantidadGenes.Next(5, 20); 

                while (0 < numeroGenes)
                {
                    int numeroGram = rnd_grams.Next(1, 4);

                    if (numeroGram == 1)
                    {
                        indiceGram = indiceRandom.Next(0, Estructuras.instancia.lista_nGram_1.Count);  //Indice de algun elem del dic
                        texto += Estructuras.instancia.lista_nGram_1.ToList()[indiceGram] + " "; //Agregar ese elem
                        numeroGenes--;
                    }
                    else
                    {
                        if (numeroGram == 2)
                        {
                            indiceGram = indiceRandom.Next(0, Estructuras.instancia.lista_nGram_2.Count);  //Indice de algun elem del dic
                            texto += Estructuras.instancia.lista_nGram_2.ToList()[indiceGram] + " "; //Agregar ese elem
                            numeroGenes--;
                        }
                        else
                        {
                            indiceGram = indiceRandom.Next(0, Estructuras.instancia.lista_nGram_3.Count);  //Indice de algun elem del dic
                            texto += Estructuras.instancia.lista_nGram_3.ToList()[indiceGram] + " "; //Agregar ese elem
                            numeroGenes--;
                        }
                    }
                }
                Individuo ind = new Individuo(texto,0);
                poblacion.Add(ind);
            }
        }

        private int Adaptabilidad(Dictionary<string, int> dic_Histograma)
        {
            int distancia = 1;

            if (tipoRecorrido.Equals("Manhattan"))
            {
                distancia = instanciaAdaptabilidad.CalculateDistanceManhattan(dic_Histograma);
            }
            else
            {
                if (tipoRecorrido.Equals("Chebyshev"))
                {
                    distancia = instanciaAdaptabilidad.CalculateDistanceChebyshev(dic_Histograma);
                }
                else
                {
                    distancia = instanciaAdaptabilidad.DistanciaPropia(dic_Histograma);
                }
            }
            return distancia;
        }

        private void CruzarPareja(Individuo padre, Individuo madre) //Aparear la pareja y que saquen 2 hijos. De ultimas llama a mutaciones
        {
            string[] genesPadre = padre.getTexto().Split();
            string[] genesMadre = madre.getTexto().Split();

            string texto_mitad_1_padre = "";
            string texto_mitad_2_padre = "";

            string texto_mitad_1_madre = "";
            string texto_mitad_2_madre = "";

            for (int i = 0; i < genesPadre.Count(); i++)
            {
                if (i > (int)genesPadre.Count() / 2)
                {
                    texto_mitad_2_padre += genesPadre[i] + " ";
                }
                else
                {
                    texto_mitad_1_padre += genesPadre[i] + " ";
                }
            }

            for (int i = 0; i < genesMadre.Count(); i++)
            {
                if (i > (int)genesMadre.Count() / 2)
                {
                    texto_mitad_2_madre += genesMadre[i] + " ";
                }
                else
                {
                    texto_mitad_1_madre += genesMadre[i] + " ";
                }
            }

            // Console.WriteLine("\nHijo 1: \n"+texto_mitad_1_padre + texto_mitad_2_madre);
            // Console.WriteLine("\nHijo 2: \n"+texto_mitad_1_madre + texto_mitad_2_padre);

            hijosCruce.Add(new Individuo(texto_mitad_1_padre + texto_mitad_2_madre, 0)); // hijo 1
            hijosCruce.Add(new Individuo(texto_mitad_1_madre + texto_mitad_2_padre, 0)); // hijo 2
        }

        public void Mutaciones(Individuo individuo)
        {
            Individuo temp = individuo;
            string[] palabras = individuo.getTexto().Split(default(string[]), StringSplitOptions.RemoveEmptyEntries);

            // Si se quieren hacer varias mutaciones, meter un while/for aqui

            int puntoPartida = rnd_grams.Next(0, palabras.Count() - 1);
            int puntoLlegada = rnd_grams.Next(puntoPartida, palabras.Count());

            while (puntoPartida >= puntoLlegada)
            {
                puntoLlegada = rnd_grams.Next(puntoPartida, palabras.Count());
            }

            int mitad = puntoPartida + ((puntoLlegada + 1) - puntoPartida) / 2;
            int contadorLlegada = puntoLlegada;
            for (int i = puntoPartida; i < mitad; i++)
            {
                string tmp = palabras[i];
                palabras[i] = palabras[contadorLlegada];
                palabras[contadorLlegada] = tmp;
                contadorLlegada--;
            }

            int distancia = temp.getDistancia();
            poblacion.Remove(temp);

            int inyectarMeta = rnd_grams.Next(0, 2);
            if (inyectarMeta == 0)
            {
                var myList = palabras.ToList();
                int pos_1 = rnd_grams.Next(0, Estructuras.instancia.lista_nGram_2_Poema.Count());

                myList.Add(Estructuras.instancia.lista_nGram_2_Poema[pos_1]);
                palabras = myList.ToArray();
            }

            poblacion.Add(new Individuo(string.Join(" ", palabras), distancia));
        }
    }
}