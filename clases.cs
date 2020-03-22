using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laberinto
{
    class Casilla
    {
        Dictionary<string, int> coordenadas;
        string tipo;

        public Casilla(int fila, int columna, string tipo)
        {
            coordenadas = new Dictionary<string, int>();
            coordenadas.Add("fila", fila);
            coordenadas.Add("columna", columna);
            this.tipo = tipo;
        }
    }
    class Personaje
    {
        private string avatar;
        private Dictionary<Textura, decimal> costos;
    }
    class Tablero
    {
        List<List<Casilla>> tablero;
        string[] coordenadas_inicio;
        string[] coordenadas_fin;
        string[] coordenadas_personaje;
        Dictionary<string, int> dimensiones;
        public Dictionary<string, string> texturas_asignadas;

        public Tablero(List<string[]> codigos)
        {
            int i = 0, j = 0;
            this.dimensiones = new Dictionary<string, int>();
            this.texturas_asignadas = new Dictionary<string, string>();
            this.tablero = new List<List<Casilla>>();

            var tipos_de_codigos = codigos.First();
            codigos.RemoveAt(0);
            foreach (string codigo in tipos_de_codigos)
            {
                texturas_asignadas.Add(codigo, "");
            }
            foreach (string[] fila in codigos)
            {
                j = 0;
                var tam_columnas = fila.Length;
                var fila_nueva = new List<Casilla>();
                foreach (string casilla in fila)
                {
                    fila_nueva.Add(new Casilla(fila: i, columna: j, tipo: casilla));
                    j++;
                }
                i++;
                this.tablero.Add(fila_nueva);
            }
            dimensiones.Add("filas", i);
            dimensiones.Add("columnas", j);
        }
    }
    public class Textura
    {
        public string ruta;
        public string nombre;

        public Textura(string ruta, string nombre)
        {
            this.ruta = ruta;
            this.nombre = nombre;
        }
    }
}
