using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laberinto
{
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
                else
                {
                    Console.WriteLine("Selecciona otro archivo...");
                    break;
                }
            }
        }
        private static List<string[]> leer_archivo(String direccion)
        {
            string[] lineas;
            var lineas_parseadas = new List<string[]>();
            try
            {
                lineas = System.IO.File.ReadAllLines(direccion);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("no se encontro el archivo");
                lineas_parseadas.Clear();
                return lineas_parseadas;
            }

            if(lineas.Length == 0)
            {
                Console.WriteLine("El archivo esta vacio");
            }
            else
            {
                string[] codigos;
                int i = 1, j = 1;
                foreach(string linea in lineas)
                {
                    codigos = linea.Split(',');
                    foreach(string codigo in codigos)
                    {
                        if (!es_codigo_valido(codigo))
                        {
                            Console.WriteLine("Error en linea {0} caracter {1}. Caracter no valido",i,j);
                            lineas_parseadas.Clear();
                            return lineas_parseadas;
                        }
                        j++;
                    }
                    i++;
                    j = 1;
                    lineas_parseadas.Add(codigos);
                }
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
