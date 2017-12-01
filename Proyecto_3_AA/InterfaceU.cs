using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Proyecto_3_AA
{
    public partial class InterfaceU : Form
    {
        private string dataSetUrl = @"Poemas\dataSet.txt"; // prueba.csv , dataSet.csv

        public InterfaceU()
        {
            InitializeComponent();
        }

        private void Interfaz_Load(object sender, EventArgs e)
        {
            String dataSet = File.ReadAllText(dataSetUrl);
            Calcular_nGrams(dataSet.ToLower(), false);

            //Estructuras.instancia.MostrarLista(Estructuras.instancia.dic_nGram_2);
        }

        private void textBox_NumGeneraciones_KeyPress(object sender, KeyPressEventArgs e)
        {
            const char Delete = (char)8;
            e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
        }

        private void abrirArchivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = " Archivos txt(.txt)| *.txt";
            open.Title = "Archivos .txt";
            if (open.ShowDialog() == DialogResult.OK)
            {
                String ruta = open.FileName;

                String line;
                int counter = 0;
                string texto = "";

                // Read the file and display it line by line.
                StreamReader file = new StreamReader(@ruta);
                while ((line = file.ReadLine()) != null)
                {
                    //Console.WriteLine(line);
                    texto += line;
                    counter++;
                }

                file.Close();

                textBox_PoemaMeta.Text = texto;

                //Console.WriteLine("There were {0} lines.", counter);
                // Suspend the screen.
                Console.ReadLine();

            }
            open.Dispose();
        }

        private void generarPoemasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string texto = textBox_PoemaMeta.Text;
            string numGeneraciones = textBox_NumGeneraciones.Text;
            textBox_PoemasGenerados.Text = "";

            if (!String.IsNullOrEmpty(texto) && !String.IsNullOrWhiteSpace(texto) && !String.IsNullOrEmpty(numGeneraciones))
            {
                Cursor.Current = Cursors.WaitCursor;

                Calcular_nGrams(texto.ToLower(), true);
                A_Genetico genetico = new A_Genetico(20, Int32.Parse(numGeneraciones), comboBox_tipoRecorrido.Text); // (k_nGrams, NoGeneraciones) 

                List<Individuo> individuosPrometedores = genetico.IniciarProcesoGenetico();

                foreach (var individuo in individuosPrometedores)
                {
                    string[] text = individuo.getTexto().Split(default(string[]), StringSplitOptions.RemoveEmptyEntries);
                    textBox_PoemasGenerados.Text += string.Join(" ", text) + "\r\n" + "\r\n";
                }

            }
            else
            {
                var result = MessageBox.Show("Para generar un poema es necesario ingresar frases y/o información, además del número de generaciones.",
                                "Atención",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Question);
            }
        }

        private void Calcular_nGrams(string texto, Boolean esPoemaMeta)
        {
            
            N_Gram nGram1 = new N_Gram(texto, 1);
            N_Gram nGram2 = new N_Gram(texto, 2);
            N_Gram nGram3 = new N_Gram(texto, 3);

            List<string> _nGram_1 = nGram1.Hacer_NGram(Estructuras.instancia.lista_nGram_1);
            List<string> _nGram_2 = nGram2.Hacer_NGram(Estructuras.instancia.lista_nGram_2);
            List<string> _nGram_3 = nGram3.Hacer_NGram(Estructuras.instancia.lista_nGram_3);

            Estructuras.instancia.Agregar_nGrams(_nGram_1, _nGram_2, _nGram_3);

            if (esPoemaMeta)
            {
                List<string> _nGram_1_PM = nGram1.Hacer_NGram(new List<string>());
                List<string> _nGram_2_PM = nGram2.Hacer_NGram(new List<string>());
                List<string> _nGram_3_PM = nGram3.Hacer_NGram(new List<string>());

                Estructuras.instancia.Agregar_nGrams_PoemaMeta(_nGram_1_PM, _nGram_2_PM, _nGram_3_PM);

                Estructuras.instancia.dic_Histo_nGram_2_PoemaMeta = new Dictionary<string, int>();
                Estructuras.instancia.dic_Histo_nGram_2_PoemaMeta = Calcular_Histogramas(_nGram_2, _nGram_2_PM);

                //Console.WriteLine("\nPOEMA META\n:");
                //Estructuras.instancia.MostrarDiccionario_string_int(Estructuras.instancia.dic_Histo_nGram_2_PoemaMeta);

                /*Console.WriteLine("Meta: \n");
                Estructuras.instancia.MostrarLista(_nGram_2_PM);

                Console.WriteLine("\nGram: \n");
                Estructuras.instancia.MostrarLista(_nGram_2);

                Console.WriteLine("\nHistograma: \n");
                Estructuras.instancia.MostrarDiccionario_string_int(Estructuras.instancia.dic_Histo_nGram_2_PoemaMeta);*/
            }
        }

        private Dictionary<string, int> Calcular_Histogramas(List<string> pNGram, List<string> lista_poemaMeta)
        {
            Histograma histograma = new Histograma();

            Dictionary<string, int> histogramaObtenido = histograma.CalcularHistograma(pNGram, lista_poemaMeta);

            return histogramaObtenido;
        }

    }
}
