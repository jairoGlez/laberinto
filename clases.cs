using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            foreach (string codigo in tipos_de_codigos)
            {
                texturas_asignadas.Add(codigo, "");
            }
        }
    }
}
