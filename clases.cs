using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laberinto
{
    class Casilla
    {
        Dictionary<string, int> coordenadas;
        public string tipo;

        public Casilla(int fila, int columna, string tipo)
        {
            coordenadas = new Dictionary<string, int>();
            coordenadas.Add("fila", fila);
            coordenadas.Add("columna", columna);
            this.tipo = tipo;
        }
    }
    public class Personaje
    {
        public string nombre;
        public string archivo;
        public Dictionary<string, decimal> costos;
        public Personaje()
        {

        }
        public Personaje(string nombre, string ruta, Dictionary<string, decimal> costos)
        {
            this.nombre = nombre;
            this.archivo = ruta;
            this.costos = costos;
        }
    }
    class Tablero
    {
        List<List<Casilla>> tablero;
        public Dictionary<string, int> coordenadas_inicio;
        public Dictionary<string, int> coordenadas_fin;
        public Dictionary<string, int> coordenadas_personaje;
        public Dictionary<string, int> dimensiones;
        public Dictionary<string, Textura> texturas_asignadas;
        public Tablero(List<string[]> codigos)
        {
            int i = 0, j = 0;
            this.dimensiones = new Dictionary<string, int>();
            this.texturas_asignadas = new Dictionary<string, Textura>();
            this.tablero = new List<List<Casilla>>();
            this.coordenadas_inicio = new Dictionary<string, int>();
            this.coordenadas_personaje = new Dictionary<string, int>();
            this.coordenadas_fin = new Dictionary<string, int>();
            coordenadas_inicio.Add("fila", -1);
            coordenadas_inicio.Add("columna", -1);
            coordenadas_personaje.Add("fila", -1);
            coordenadas_personaje.Add("columna", -1);
            coordenadas_fin.Add("fila", -1);
            coordenadas_fin.Add("columna", -1);
            var tipos_de_codigos = codigos.First();
            codigos.RemoveAt(0);
            foreach (string codigo in tipos_de_codigos)
            {
                texturas_asignadas.Add(codigo, null);
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
        public Casilla casillaPorCoordenadas(int fila, int columna)
        {
            if(fila < dimensiones["filas"] && columna < dimensiones["columnas"])
            {
                return tablero.ElementAt(fila).ElementAt(columna);
            }
            return null;
        }
        public Textura texturaPorCoordenadas(int fila, int columna)
        {
            var casilla = casillaPorCoordenadas(fila, columna);
            if(casilla != null)
            {
                return texturas_asignadas[casilla.tipo];
            }
            return null;
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
    public class Tabla_laberinto : TableLayoutPanel
    {
        public Tabla_laberinto()
        {
            DoubleBuffered = true;
        }
        protected override void OnCellPaint(TableLayoutCellPaintEventArgs e)
        {
            base.OnCellPaint(e);
            Control c = this.GetControlFromPosition(e.Column, e.Row);

            if (c != null)
            {
                Graphics g = e.Graphics;
                if (e.Row == 0)
                {
                    g.DrawLine(Pens.LightGray, e.CellBounds.Location.X, e.CellBounds.Location.Y, e.CellBounds.Location.X, e.CellBounds.Location.Y + e.CellBounds.Height);
                    g.DrawLine(Pens.LightGray, e.CellBounds.Location.X + e.CellBounds.Width, e.CellBounds.Location.Y, e.CellBounds.Location.X + e.CellBounds.Width, e.CellBounds.Location.Y + e.CellBounds.Height);
                }
                else if(e.Column == 0)
                {
                    g.DrawLine(Pens.LightGray, e.CellBounds.Location.X, e.CellBounds.Location.Y, e.CellBounds.Location.X + e.CellBounds.Width, e.CellBounds.Location.Y);
                    g.DrawLine(Pens.LightGray, e.CellBounds.Location.X, e.CellBounds.Location.Y + e.CellBounds.Height, e.CellBounds.Location.X + e.CellBounds.Width, e.CellBounds.Location.Y + e.CellBounds.Height);
                }
                else
                {
                    Textura t = c.Tag as Textura;
                    g.DrawImage(Image.FromFile(t.ruta), e.CellBounds.Location.X, e.CellBounds.Location.Y, new Rectangle(new Point(0,0), e.CellBounds.Size), GraphicsUnit.Pixel);
                }
            }
        }
    }
}
