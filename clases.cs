﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace laberinto
{
    class Casilla
    {
        Dictionary<string, int> coordenadas;
        public string tipo;
        public bool visible;

        public Casilla(int fila, int columna, string tipo)
        {
            coordenadas = new Dictionary<string, int>();
            coordenadas.Add("fila", fila);
            coordenadas.Add("columna", columna);
            this.visible = false;
            this.tipo = tipo;
        }
    }
    public class Personaje
    {
        public string nombre;
        public string archivo;
        public Dictionary<string, decimal> costos;
        private Dictionary<string, decimal> costos_default;
        public Bitmap imagen;
        public Personaje(string nombre_del_archivo)
        {
            this.nombre = Path.GetFileNameWithoutExtension(nombre_del_archivo);
            this.archivo = nombre_del_archivo;
            leer_costos();
        }
        void leer_costos()
        {
            var lineas= File.ReadAllLines("Personajes//costos//" + this.nombre + ".txt");
            var costos = new Dictionary<string, decimal>();
            foreach(string costo in lineas)
            {
                var campos = costo.Split(',');
                costos.Add(campos[0], decimal.Parse(campos[1]));
            }
            costos_default = costos;
        }
        public void cargar_costos(Dictionary<string, Textura> codigos_asignados)
        {
            this.costos = new Dictionary<string, decimal>();
            if (codigos_asignados == null) return;
            foreach(KeyValuePair<string, Textura>asignacion in codigos_asignados)
            {
                costos.Add(asignacion.Key, costos_default[asignacion.Value.nombre]);
            }
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
        public string es_visible(int fila, int columna)
        {
            if (fila < dimensiones["filas"] && columna < dimensiones["columnas"])
            {
                if (tablero.ElementAt(fila).ElementAt(columna).visible == false)
                {
                    return "0";
                }
                else
                {
                    return "1";
                }
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
        public void cambiar_visivilidad(int fila, int columna, bool v)
        {
            tablero.ElementAt(fila).ElementAt(columna).visible = v;
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
        Dictionary<string, Image> texturas;
        public Tabla_laberinto(Dictionary<string, Textura> rutas_texturas)
        {
            DoubleBuffered = true;
            texturas = new Dictionary<string, Image>();
            foreach(KeyValuePair<string,Textura> datos_textura in rutas_texturas)
            {
                texturas.Add(datos_textura.Value.nombre, Image.FromFile(datos_textura.Value.ruta));
            }
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
                    var datos = c.Tag as Dictionary<string, string>;
                    string visible = datos["visible"];
                    string t = datos["textura"];
                    if(visible == "1")
                    {
                        g.DrawImage(this.texturas[t], e.CellBounds.Location.X, e.CellBounds.Location.Y, new Rectangle(new Point(0, 0), e.CellBounds.Size), GraphicsUnit.Pixel);
                    }
                    else
                    {
                        g.FillRectangle(Brushes.Black, e.CellBounds.X, e.CellBounds.Y, e.CellBounds.Width, e.CellBounds.Height);
                    }
                    if (datos.ContainsKey("ruta"))
                    {
                        g.DrawRectangle(Pens.YellowGreen, e.CellBounds.X, e.CellBounds.Y, e.CellBounds.Width - 1, e.CellBounds.Height - 1);
                    }
                }
            }
        }
    }
}
