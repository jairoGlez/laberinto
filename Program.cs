using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laberinto
{
    class Casilla
    {
        string[] coordenadas;
        string tipo;
    }
    class Personaje
    {

    }
    class Tablero
    {
        List<Casilla> tablero;
        string[] coordenadas_inicio;
        string[] coordenadas_fin;
        string[] coordenadas_personaje;
        int[] dimensiones;
        Dictionary<string, string> texturas_asignadas;

        public Tablero(List<string[]> codigos)
        {
            var tipos_de_codigos = codigos.First();
            foreach (string codigo in tipos_de_codigos){
                texturas_asignadas.Add(codigo, "");
            }
        }
    }
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());

            string direccion = "D:/Librerias/Drive/Cursos actuales/IA/Proyecto/laberinto/medios/mapa.txt";
            List<string[]> filas;

            while(true)
            {
                filas = leer_archivo(direccion);
                if (filas.Count() != 0) break;
            }
            var tablero = new Tablero(filas);
        }
        private static void mensaje_de_error(string mensaje)
        {
            MessageBox.Show("Error: {0}", mensaje);
        }
        private static List<string[]> leer_archivo(String direccion)
        {
            string[] lineas;
            var tipos_de_codigo = new List<string>();
            var lineas_parseadas = new List<string[]>();
            try
            {
                lineas = System.IO.File.ReadAllLines(direccion);
            }
            catch (FileNotFoundException)
            {
                mensaje_de_error("no se encontro el archivo");
                return lineas_parseadas;
            }

            if(lineas.Length == 0)
            {
                mensaje_de_error("El archivo esta vacio");
            }
            else
            {
                string[] codigos;
                int i = 1, j = 1;
                int num_columnas = lineas[0].Split(',').Length;
                foreach(string linea in lineas)
                {
                    codigos = linea.Split(',');
                    foreach(string codigo in codigos)
                    {
                        if (es_codigo_valido(codigo))
                        {
                            if (!tipos_de_codigo.Contains(codigo))
                            {
                                tipos_de_codigo.Add(codigo);
                            }
                        }
                        else
                        {
                            mensaje_de_error(string.Format("Error en linea {0} caracter {1}. Caracter no valido", i, j));
                            lineas_parseadas.Clear();
                            return lineas_parseadas;
                        }
                        j++;
                    }
                    if (j-1 != num_columnas)
                    {
                        mensaje_de_error("Las columnas son de distinto tamaño");
                        lineas_parseadas.Clear();
                        return lineas_parseadas;
                    }
                    i++;
                    j = 1;
                    lineas_parseadas.Add(codigos);
                }
                lineas_parseadas.Prepend(tipos_de_codigo.ToArray());
            }
            return lineas_parseadas;
        }
        private static bool es_codigo_valido(string codigo)
        {
            string patron_regex = @"^\d+$";
            var resultado = Regex.IsMatch(codigo, patron_regex);
            return resultado;
        }
    }
}
