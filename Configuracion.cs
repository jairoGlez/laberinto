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
        private Dictionary<string, Bitmap> imagenes;
        public Configurador_personajes conf_p;
        private TableLayoutPanel tabla;
        public Form_Configuracion(Dictionary<string, Textura> terrenos)
        {
            InitializeComponent();
            personajes = new List<Personaje>();
            terrenos_valuados = new Dictionary<string, Textura>();
            texturas = new List<Textura>();
            texturas_seleccionadas = new List<string>();
            imagenes = new Dictionary<string, Bitmap>();
            cargar_texturas();
            crear_controles(terrenos);
        }
        private void cargar_texturas()
        {
            var archivos = Directory.GetFiles("Texturas", "*.jpg");
            foreach (string ruta in archivos)
            {
                var t = new Textura(ruta, Path.GetFileNameWithoutExtension(ruta));
                texturas.Add(t);
                Image imagen = Image.FromFile(ruta);
                var miniatura = new Bitmap(imagen, new Size(25, 25));
                imagenes.Add(t.nombre, miniatura);
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
            var combos = tabla.Controls.OfType<ComboBox>();
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
                var combos = tabla.Controls.OfType<ComboBox>();
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
            Label txt_codigo_terreno;
            ComboBox combo_texturas;

            tabla = new TableLayoutPanel()
            {
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Dock = DockStyle.Top
            };
            tabla.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30f));
            tabla.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70f));
            tabla.RowStyles.Add(new RowStyle(SizeType.Absolute, 20));
            tabla.ColumnCount = 2;
            tabla.RowCount = 1;
            tabla.Controls.Add(new Label() { Text = "Codigo", Dock = DockStyle.Bottom });
            tabla.Controls.Add(new Label() { Text = "Textura", Dock = DockStyle.Bottom });

            foreach (KeyValuePair<string,Textura> terreno in terrenos)
            {
                var lista_de_texturas = obtener_lista_de_texturas();
                txt_codigo_terreno = new Label()
                {
                    Text = terreno.Key,
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter
                };
                combo_texturas = new ComboBox()
                {
                    Name = terreno.Key,
                    DropDownStyle = ComboBoxStyle.DropDownList,
                    DrawMode = DrawMode.OwnerDrawFixed,
                    Dock = DockStyle.Fill,
                    ItemHeight = 25
                };
                combo_texturas.Items.AddRange(lista_de_texturas);
                combo_texturas.SelectionChangeCommitted += new System.EventHandler(cambio_de_seleccion);
                combo_texturas.DrawItem += new DrawItemEventHandler(dibujar_items_combo_texturas);

                tabla.Controls.Add(txt_codigo_terreno);
                tabla.Controls.Add(combo_texturas);
                tabla.RowStyles.Add(new RowStyle(SizeType.Absolute, 35));
                tabla.RowCount += 1;
            }
            contenedor.Controls.Add(tabla);
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
                    var miniatura = imagenes[nombre_de_textura];
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
