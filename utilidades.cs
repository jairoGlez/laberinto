using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laberinto
{
    class utilidades
    {
        public static void mensaje_de_error(string mensaje)
        {
            MessageBox.Show(string.Format("Error: {0}", mensaje));
        }
        public static bool es_codigo_valido(string codigo)
        {
            string patron_regex = @"^\d+$";
            var resultado = Regex.IsMatch(codigo, patron_regex);
            return resultado;
        }
        public static List<string[]> leer_archivo(String direccion)
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

            if (lineas.Length == 0)
            {
                mensaje_de_error("El archivo esta vacio");
            }
            else
            {
                string[] codigos;
                int i = 1, j = 1;
                int num_columnas = lineas[0].Split(',').Length;
                foreach (string linea in lineas)
                {
                    codigos = linea.Split(',');
                    foreach (string codigo in codigos)
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
                    if (j - 1 != num_columnas)
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
    }
}
