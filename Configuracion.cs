using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laberinto
{
    public partial class Form_Configuracion : Form
    {
        private List<Personaje> personajes;
        public Dictionary<string, Textura> terrenos_valuados;
        private List<Textura> texturas;
        private List<string> texturas_seleccionadas;
        public Configurador_personajes conf_p;
        public Form_Configuracion(Dictionary<string, Textura> terrenos)
        {
            InitializeComponent();
            personajes = new List<Personaje>();
            terrenos_valuados = new Dictionary<string, Textura>();
            texturas = new List<Textura>();
            texturas_seleccionadas = new List<string>();
            cargar_nombres_de_texturas();
            crear_controles(terrenos);
        }
        private void cargar_nombres_de_texturas()
        {
            var nombres = new List<string>();
            var archivos = Directory.GetFiles("Texturas", "*.jpg");
            foreach (string ruta in archivos)
            {
                var t = new Textura(ruta, Path.GetFileNameWithoutExtension(ruta));
                texturas.Add(t);
            }
        }
        private string obtener_direccion_textura(string nombre)
        {
            foreach(Textura t in texturas)
            {
                if (t.nombre == nombre) return t.ruta;
            }
            return "";
        }
        private System.Object[] obtener_lista_de_texturas()
        {
            var lista = new List<System.Object>();
            foreach (Textura t in texturas)
            {
                lista.Add(t.nombre);
            }
            
            return lista.ToArray();
        }
        private void remover_textura_de_lista(ComboBox seleccionado)
        {
            var combos = panel3.Controls.OfType<ComboBox>();
            var seleccion_previa = seleccionado.Text;
            var opcion_a_remover = seleccionado.SelectedItem;

            if (seleccion_previa == "")
            {
                foreach (ComboBox combo in combos)
                {
                    if (combo != seleccionado)
                    {
                        combo.Items.Remove(opcion_a_remover);
                    }
                }
            }
            else
            {
                foreach (ComboBox combo in combos)
                {
                    if (combo != seleccionado)
                    {
                       combo.Items.Remove(opcion_a_remover);
                       combo.Items.Insert(0, seleccion_previa);
                    }
                }
            }
        }
        private bool revisar_si_todos_asignados()
        {
            var combos = panel3.Controls.OfType<ComboBox>();

            foreach (var combo in combos)
            {
                if (combo.SelectedItem == null) return false;
            }

            return true;
        }
        private Textura buscar_textura(string nombre)
        {
            foreach(Textura t in texturas)
            {
                if (t.nombre == nombre) return t;
            }
            return texturas[0];
        }
        private void cambio_de_seleccion(object sender, EventArgs e)
        {
            remover_textura_de_lista(sender as ComboBox);
            var todos_asignados = revisar_si_todos_asignados();
            if (todos_asignados)
            {
                btn_SiguienteTerreno.Enabled = true;
                var combos = panel3.Controls.OfType<ComboBox>();
                terrenos_valuados.Clear();
                foreach(var asignacion in combos)
                {
                    terrenos_valuados.Add(asignacion.Name, buscar_textura(asignacion.Text));
                }
            }
        }
        private void crear_controles(Dictionary<string, Textura> terrenos)
        {
            var contenedor = this.panel3;
            var posicion_horizontal_codigos = 242;
            var posicion_horizontal_combos = 332;
            var posicion_vertical = 38;
            TextBox txt_codigo_terreno;
            ComboBox combo_texturas;

            foreach (KeyValuePair<string,Textura> terreno in terrenos)
            {
                var lista_de_texturas = obtener_lista_de_texturas();
                txt_codigo_terreno = new TextBox()
                {
                    ReadOnly = true,
                    Size = new Size(50, 32),
                    Location = new Point(posicion_horizontal_codigos, posicion_vertical),
                    Text = terreno.Key
                };
                combo_texturas = new ComboBox()
                {
                    Name = terreno.Key,
                    Size = new Size(195, 32),
                    Location = new Point(posicion_horizontal_combos, posicion_vertical),
                    DropDownStyle = ComboBoxStyle.DropDownList,
                    DrawMode = DrawMode.OwnerDrawFixed,
                    ItemHeight = 32
                };
                combo_texturas.Items.AddRange(lista_de_texturas);
                combo_texturas.SelectionChangeCommitted += new System.EventHandler(cambio_de_seleccion);
                combo_texturas.DrawItem += new DrawItemEventHandler(dibujar_items_combo_texturas); 
                contenedor.Controls.Add(txt_codigo_terreno);
                contenedor.Controls.Add(combo_texturas);
                posicion_vertical += 38;
            }
        }
        private void dibujar_items_combo_texturas(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            e.DrawFocusRectangle();
            if (e.Index >= 0)
            {
                var opcion = (sender as ComboBox).Items[e.Index];
                var nombre_de_textura = opcion as string;
                if (e.Index < texturas.Count)
                {
                    Image textura = Image.FromFile(obtener_direccion_textura(nombre_de_textura));
                    var miniatura = new Bitmap(textura, new Size(32, 32));
                    e.Graphics.DrawImage(miniatura, new PointF(e.Bounds.Left, e.Bounds.Top));
                }
                e.Graphics.DrawString(nombre_de_textura, e.Font, new SolidBrush(e.ForeColor), e.Bounds.Left + 32, e.Bounds.Top);
            }
        }
        private void btn_SiguienteTerreno_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
