using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;

namespace laberinto
{
    public partial class Formulario_Juego : Form
    {
        Tablero tablero;
        Personaje[] personajes;
        Tabla_laberinto tabla;
        bool juego_iniciado;
        int personaje_seleccionado;
        int visita;
        public Formulario_Juego()
        {
            InitializeComponent();
        }
        private List<string[]> mostrar_ventana_cargar()
        {
            var ventana = new Form_Inicio();
            ventana.ShowDialog();
            return ventana.filas_leidas();
        }
        private void mostrar_ventana_configuracion()
        {
            var ventana = new Form_Configuracion(tablero.texturas_asignadas);
            ventana.FormClosing += new FormClosingEventHandler(config_terminada);
            ventana.ShowDialog();
        }
        private void config_terminada(object sender, EventArgs e)
        {
            var ventana = sender as Form_Configuracion;
            var temp_terrenos = ventana.terrenos_valuados;
            var temp_ventana_conf = ventana.conf_p;
            if(temp_ventana_conf == null)
            {
                Utilidades.mensaje_de_error("Configuracion incompleta");
                return;
            }
            var temp_personajes = ventana.conf_p.personajes_creados;
            if (temp_terrenos.Count == 0)
            {
                Utilidades.mensaje_de_error("Error en la configuración de las texturas");
                return;
            }
            if (temp_personajes.Length == 0)
            {
                Utilidades.mensaje_de_error("Error en la configuración de los personajes");
                return;
            }
            tablero.texturas_asignadas = temp_terrenos;
            personajes = temp_personajes;
            dibujar_laberinto();
            agregar_personajes_al_combo();
            agregar_opciones_a_combos_coordenadas();
        }
        void iniciar_configuracion()
        {
            var filas = mostrar_ventana_cargar();
            if (filas == null)
            {
                Utilidades.mensaje_de_error("Error en la configuracion del laberinto");
                return;
            }
            this.tablero = new Tablero(filas);
            mostrar_ventana_configuracion();
        }
        private void Formulario_Juego_Shown(object sender, EventArgs e)
        {
            iniciar_configuracion();
        }
        private void personajeToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // confi conf = new Configurador_personajes(); 
           // conf_pers.Show();
        }
        private void configuraciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
          //  Form_Configuracion conf = new Form_Configuracion();
          //  conf.Show();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            bloquear_controles();
            this.Focus();
            juego_iniciado = true;
            visita = 1;
            verificar_victoria();
        }
        private void bloquear_controles()
        {
            var controles = panel1.Controls;
            foreach (var c in controles)
            {
                (c as Control).Enabled = false;
            }
        }
        private void dibujar_laberinto()
        {
            Textura t;
            var cant_filas = tablero.dimensiones["filas"];
            var cant_columnas = tablero.dimensiones["columnas"];
            tabla = new Tabla_laberinto()
            {
                Location = new Point(3, 3),
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowOnly
            };
            contenedor_laberinto.Visible = false;
            tabla.SuspendLayout();
            tabla.ColumnStyles.Clear();
            tabla.RowStyles.Clear();
            tabla.Controls.Clear();
            tabla.RowCount = cant_filas + 1;
            tabla.ColumnCount = cant_columnas + 1;
            tabla.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 25));
            tabla.RowStyles.Add(new RowStyle(SizeType.Absolute, 25));
            tabla.Controls.Add(new Label() { Text = "/", Dock = DockStyle.Fill}, 0, 0);
            for (int i = 1; i <= cant_columnas; i++)
            {
                tabla.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70));
                tabla.Controls.Add(new Label() { Text = i.ToString(), Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter, BackColor = Color.Transparent }, i, 0);
            }
            for (int i = 1; i <= cant_filas; i++)
            {
                tabla.RowStyles.Add(new RowStyle(SizeType.Absolute, 70));
                tabla.Controls.Add(new Label() { Text = char.ConvertFromUtf32(64 + i), Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter, BackColor = Color.Transparent }, 0, i);
                for (int j = 1; j <= cant_columnas; j++)
                {
                    t = tablero.texturaPorCoordenadas(i - 1, j - 1);
                    var l = new Label() { Text = "", BackColor = Color.Transparent, Tag = t, TextAlign = ContentAlignment.TopLeft, Dock = DockStyle.Fill };
                    var info = new ToolTip();
                    info.AutoPopDelay = 5000;
                    info.InitialDelay = 1000;
                    info.ReshowDelay = 500;
                    info.ShowAlways = true;
                    info.SetToolTip(l, string.Format("Codigo: {0} Textura: {1}", tablero.casillaPorCoordenadas(i - 1, j - 1).tipo, t.nombre));
                    tabla.Controls.Add(l, j, i);
                }
            }
            tabla.ResumeLayout();
            contenedor_laberinto.Controls.Add(tabla);
            contenedor_laberinto.Visible = true;
        }
        private void agregar_personajes_al_combo()
        {
            var combo = comboBox1;
            combo.DropDownStyle = ComboBoxStyle.DropDownList;
            combo.DrawMode = DrawMode.OwnerDrawFixed;
            combo.ItemHeight = 32;
            combo.SelectionChangeCommitted += new System.EventHandler(combo_personajes_seleccionado);
            combo.DrawItem += new DrawItemEventHandler(dibujar_items_combo_personajes);
            List<string> nombres = new List<string>();
            foreach(var p in personajes)
            {
                nombres.Add(p.nombre);
            }
            combo.Items.AddRange(nombres.ToArray());
        }
        private void combo_personajes_seleccionado(object sender, EventArgs e)
        {
            personaje_seleccionado = (sender as ComboBox).SelectedIndex;
            habilitar_combos();
        }
        private void habilitar_combos()
        {
            var combos = panel1.Controls.OfType<ComboBox>();
            foreach(var combo in combos)
            {
                combo.Enabled = true;
            }
        }
        private void dibujar_items_combo_personajes(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            e.DrawFocusRectangle();
            if (e.Index >= 0)
            {
                var opcion = (sender as ComboBox).Items[e.Index];
                var nombre_de_avatar = opcion as string;
                if (e.Index < personajes.Length)
                {
                    Image avatar = Image.FromFile(personajes[e.Index].archivo);
                    var miniatura = new Bitmap(avatar, new Size(32, 32));
                    e.Graphics.DrawImage(miniatura, new PointF(e.Bounds.Left, e.Bounds.Top));
                }
                e.Graphics.DrawString(nombre_de_avatar, e.Font, new SolidBrush(e.ForeColor), e.Bounds.Left + 32, e.Bounds.Top);
            }
        }
        void agregar_opciones_a_combos_coordenadas()
        {
            List<string> opciones = new List<string>();
            for(int i = 0; i < tablero.dimensiones["filas"]; i++)
            {
                opciones.Add(char.ConvertFromUtf32(65 + i));
            }
            comboFilaO.Items.AddRange(opciones.ToArray());
            comboFilaD.Items.AddRange(opciones.ToArray());
            opciones.Clear();
            for (int i = 0; i < tablero.dimensiones["columnas"]; i++)
            {
                opciones.Add((i+1).ToString());
            }
            comboColumnaO.Items.AddRange(opciones.ToArray());
            comboColumnaD.Items.AddRange(opciones.ToArray());
        }
        void dibujar_personaje(int fila, int columna)
        {
            var personaje = personajes[comboBox1.SelectedIndex];
            var casilla = tabla.GetControlFromPosition(columna + 1, fila + 1) as Label;
            var dibujo_personaje = Image.FromFile(personaje.archivo);
            casilla.Image = new Bitmap(dibujo_personaje, new Size(50, 50));
            casilla.Text += " "+visita.ToString();
            visita++;
        }
        void dibujar_inicio(int fila, int columna)
        {
            var d = new Dictionary<string, int>();
            d.Add("fila", fila);
            d.Add("columna", columna);
            if (!es_habitable(d))return;
            var personaje = personajes[comboBox1.SelectedIndex];
            var casilla = tabla.GetControlFromPosition(columna + 1, fila + 1) as Label;
            var dibujo_personaje = Image.FromFile(personaje.archivo);
            casilla.Image = new Bitmap(dibujo_personaje, new Size(50, 50));
            casilla.Text = "Inicio";
        }
        private void comboFilaO_SelectedIndexChanged(object sender, EventArgs e)
        {
            var fila = comboFilaO;
            var columna = comboColumnaO;
            if(columna.Text != "")
            {
                if (hay_personaje_dibujado()) borrar_inicio();
                dibujar_inicio(fila.SelectedIndex, columna.SelectedIndex);
                tablero.coordenadas_inicio["fila"] = fila.SelectedIndex;
                tablero.coordenadas_inicio["columna"] = columna.SelectedIndex;
                tablero.coordenadas_personaje["fila"] = fila.SelectedIndex;
                tablero.coordenadas_personaje["columna"] = columna.SelectedIndex;
                if (hay_meta_dibujada() && hay_personaje_dibujado())
                {
                    button1.Enabled = true;
                }
            }
        }
        private void comboColumnaO_SelectedIndexChanged(object sender, EventArgs e)
        {
            var fila = comboFilaO;
            var columna = comboColumnaO;
            if (fila.Text != "")
            {
                if (hay_personaje_dibujado()) borrar_inicio();
                dibujar_inicio(fila.SelectedIndex, columna.SelectedIndex);
                tablero.coordenadas_inicio["fila"] = fila.SelectedIndex;
                tablero.coordenadas_inicio["columna"] = columna.SelectedIndex;
                tablero.coordenadas_personaje["fila"] = fila.SelectedIndex;
                tablero.coordenadas_personaje["columna"] = columna.SelectedIndex;
                if (hay_meta_dibujada() && hay_personaje_dibujado())
                {
                    button1.Enabled = true;
                }
            }
        }
        private void borrar_personaje(int fila, int columna)
        {
            var casilla = tabla.GetControlFromPosition(columna + 1, fila + 1) as Label;
            casilla.Image = null;
        }
        private void borrar_inicio()
        {
            var fila = tablero.coordenadas_personaje["fila"];
            var columna = tablero.coordenadas_personaje["columna"];
            var casilla = tabla.GetControlFromPosition(columna + 1, fila + 1) as Label;
            casilla.Image = null;
            casilla.Update();
            casilla.Text = "";
        }
        private bool hay_personaje_dibujado()
        {
            return tablero.coordenadas_personaje["fila"] != -1;
        }
        private void comboFilaD_SelectedIndexChanged(object sender, EventArgs e)
        {
            var fila = comboFilaD;
            var columna = comboColumnaD;
            if (columna.Text != "")
            {
                if (hay_meta_dibujada()) borrar_meta();
                dibujar_meta(fila.SelectedIndex, columna.SelectedIndex);
                tablero.coordenadas_fin["fila"] = fila.SelectedIndex;
                tablero.coordenadas_fin["columna"] = columna.SelectedIndex;
                tablero.coordenadas_personaje = tablero.coordenadas_inicio;
                if (hay_meta_dibujada() && hay_personaje_dibujado())
                {
                    button1.Enabled = true;
                }
            }
        }
        private void comboColumnaD_SelectedIndexChanged(object sender, EventArgs e)
        {
            var fila = comboFilaD;
            var columna = comboColumnaD;
            if (fila.Text != "")
            {
                if (hay_meta_dibujada()) borrar_meta();
                dibujar_meta(fila.SelectedIndex, columna.SelectedIndex);
                tablero.coordenadas_fin["fila"] = fila.SelectedIndex;
                tablero.coordenadas_fin["columna"] = columna.SelectedIndex;
                tablero.coordenadas_personaje = tablero.coordenadas_inicio;
                if (hay_meta_dibujada() && hay_personaje_dibujado())
                {
                    button1.Enabled = true;
                }
            }
        }
        private void dibujar_meta(int fila, int columna)
        {
            var casilla = tabla.GetControlFromPosition(columna + 1, fila + 1) as Label;
            var dibujo = Image.FromFile(@"Recursos\meta.png");
            casilla.Image = new Bitmap(dibujo, new Size(50, 50));
        }
        private void borrar_meta()
        {
            var fila = tablero.coordenadas_fin["fila"];
            var columna = tablero.coordenadas_fin["columna"];
            var casilla = tabla.GetControlFromPosition(columna + 1, fila + 1) as Label;
            casilla.Image = null;
        }
        private bool hay_meta_dibujada()
        {
            return tablero.coordenadas_fin["fila"] != -1;
        }
        private void mover_personaje(Dictionary<string, int> coordenada_nueva)
        {
            tablero.coordenadas_personaje["fila"] = coordenada_nueva["fila"];
            tablero.coordenadas_personaje["columna"] = coordenada_nueva["columna"];
            dibujar_personaje(tablero.coordenadas_personaje["fila"], tablero.coordenadas_personaje["columna"]);
        }
        private void Formulario_Juego_KeyDown(object sender, KeyEventArgs e)
        {
            if (juego_iniciado)
            {
                var coordenada_nueva = calcular_coordenada(e.KeyCode);
                if (coordenada_nueva != null)
                {
                    if (!es_coordenada_valida(coordenada_nueva))
                    {
                        e.Handled = true;
                        return;
                    }
                    if (!es_habitable(coordenada_nueva))
                    {
                        e.Handled = true;
                        return;
                    }
                    borrar_personaje(tablero.coordenadas_personaje["fila"], tablero.coordenadas_personaje["columna"]);
                    mover_personaje(coordenada_nueva);
                    verificar_victoria();
                }
            }
            e.Handled = true;
        }

        private void verificar_victoria()
        {
            if(tablero.coordenadas_personaje["fila"] == tablero.coordenadas_fin["fila"] && tablero.coordenadas_personaje["columna"] == tablero.coordenadas_fin["columna"])
            {
                MessageBox.Show("Victoria!");
                borrar_inicio();
                desbloquear_controles();
            }
        }
        private void desbloquear_controles()
        {
            var controles = panel1.Controls;
            foreach (var c in controles)
            {
                (c as Control).Enabled = true;
            }
        }

        private bool es_habitable(Dictionary<string, int> coordenada_nueva)
        {
            var casilla = tablero.casillaPorCoordenadas(coordenada_nueva["fila"],coordenada_nueva["columna"]);
            if (personajes[personaje_seleccionado].costos[casilla.tipo] == -1) return false;
            return true;
        }

        private bool es_coordenada_valida(Dictionary<string, int> coordenada_nueva)
        {
            if (coordenada_nueva["fila"] >= tablero.dimensiones["filas"]) return false;
            if (coordenada_nueva["fila"] < 0) return false;
            if (coordenada_nueva["columna"] >= tablero.dimensiones["columnas"]) return false;
            if (coordenada_nueva["columna"] < 0) return false;
            return true;
        }

        private Dictionary<string, int> calcular_coordenada(Keys tecla)
        {
            var coordenadas = new Dictionary<string, int>();
            coordenadas.Add("fila", tablero.coordenadas_personaje["fila"]);
            coordenadas.Add("columna", tablero.coordenadas_personaje["columna"]);
            if (tecla == Keys.Up)
            {
                coordenadas["fila"] -= 1;
            }
            else if (tecla == Keys.Right)
            {
                coordenadas["columna"] += 1;
            }
            else if (tecla == Keys.Down)
            {
                coordenadas["fila"] += 1;
            }
            else if (tecla == Keys.Left)
            {
                coordenadas["columna"] -= 1;
            }
            else coordenadas = null;
            
            return coordenadas;
        }

        private void mapaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            iniciar_configuracion();
        }
    }
}
