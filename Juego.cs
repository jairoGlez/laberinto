using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;
using System.IO;

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
        private bool nonNumberEntered;
        private bool juego_previo;

        public Formulario_Juego()
        {
            InitializeComponent();
            juego_previo = false;
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

            if (temp_terrenos.Count == 0)
            {
                Utilidades.mensaje_de_error("Error en la configuración de las texturas");
                return;
            }
            tablero.texturas_asignadas = temp_terrenos;

            dibujar_laberinto();
            agregar_opciones_a_combos_coordenadas();
        }
        private void Formulario_Juego_Shown(object sender, EventArgs e)
        {
            iniciar_configuracion();
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
            cargar_personajes();
            agregar_personajes_al_combo();
        }
        private void cargar_personajes()
        {
            var nombres_de_archivos = Directory.GetFiles("Personajes", "*.png");
            List<Personaje> personajes_cargados = new List<Personaje>();
            foreach(string archivo in nombres_de_archivos)
            {
                Personaje p = new Personaje(archivo);
                p.cargar_costos(tablero.texturas_asignadas);
                personajes_cargados.Add(p);
            }
            this.personajes = personajes_cargados.ToArray();
        }
        private void configuraciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
          //  Form_Configuracion conf = new Form_Configuracion();
          //  conf.Show();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(!actualizar_costos()) return;
            bloquear_controles();
            this.Focus();
            juego_iniciado = true;
            visita = 2;
            verificar_victoria();
        }
        private bool actualizar_costos()
        {
            for(int i = 1; i <= tablero.texturas_asignadas.Count(); i++)
            {
                var label_textura = tabla_costos.GetControlFromPosition(0, i) as Label;
                var costo = tabla_costos.GetControlFromPosition(1, i) as TextBox;
                if (costo.Text == "")
                {
                    Utilidades.mensaje_de_error("Falta un costo");
                    return false;
                }
                personajes[personaje_seleccionado].costos[label_textura.Tag as string] = decimal.Parse(costo.Text);
            }
            return true;
        }
        private void bloquear_controles()
        {
            var controles = panel1.Controls;
            foreach (var c in controles)
            {
                (c as Control).Enabled = false;
            }
            var combos = panel1.Controls.OfType<ComboBox>();
            foreach (ComboBox c in combos)
            {
                c.SelectedIndex = -1;
            }
        }
        private void desbloquear_controles()
        {
            comboBox1.Enabled = true;
            groupBox1.Enabled = true;
            tabla_costos.Enabled = true;
            button3.Enabled = true;
            var radios = groupBox1.Controls;
            foreach(Control c in radios)
            {
                c.Enabled = true;
            }
            var costos = tabla_costos.Controls;
            foreach(Control c in costos)
            {
                c.Enabled = true;
            }
        }
        private void dibujar_laberinto()
        {
            Textura t;
            var cant_filas = tablero.dimensiones["filas"];
            var cant_columnas = tablero.dimensiones["columnas"];
            ToolTip info;
            var tam_casillas = 45;

            if(tabla != null)
            {
                tabla.Dispose();
            }

            tabla = new Tabla_laberinto(tablero.texturas_asignadas)
            {
                Visible = false,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink
            };
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
                tabla.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, tam_casillas));
                tabla.Controls.Add(new Label() { Text = char.ConvertFromUtf32(64 + i) , Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter, BackColor = Color.Transparent }, i, 0);
            }
            for (int i = 1; i <= cant_filas; i++)
            {
                tabla.RowStyles.Add(new RowStyle(SizeType.Absolute, tam_casillas));
                tabla.Controls.Add(new Label() { Text = i.ToString(), Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter, BackColor = Color.Transparent }, 0, i);
                for (int j = 1; j <= cant_columnas; j++)
                {
                    t = tablero.texturaPorCoordenadas(i - 1, j - 1);
                    var tipo = tablero.casillaPorCoordenadas(i - 1, j - 1).tipo;
                    var casilla = new Label() { Text = "", BackColor = Color.Transparent, Tag = t, TextAlign = ContentAlignment.TopLeft, Dock = DockStyle.Fill };
                    info = new ToolTip();
                    info.SetToolTip(casilla, string.Format("Codigo: {0}, Textura: {1}", tipo, t.nombre));
                    tabla.Controls.Add(casilla, j, i);
                }
            }
            contenedor_laberinto.Controls.Add(tabla);
            tabla.Visible = true;
        }
        private void agregar_personajes_al_combo()
        {
            var combo = comboBox1;
            combo.Items.Clear();
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
            poner_costos_en_tabla();
            habilitar_combos();
        }
        private void poner_costos_en_tabla()
        {
            quitar_costos_anteriores();
            var costos = personajes[personaje_seleccionado].costos;
            var header = tabla_costos.RowStyles[0];
            foreach(KeyValuePair<string, decimal> costo in costos)
            {
                tabla_costos.RowStyles.Add(new RowStyle(SizeType.Absolute, 20));
                tabla_costos.RowCount++;
                var nombre_textura = new Label()
                {
                    Text = tablero.texturas_asignadas[costo.Key].nombre,
                    Tag = costo.Key,
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter
                };
                var costo_textura = new TextBox()
                { 
                    Text = costo.Value.ToString(),
                    Dock = DockStyle.Fill,
                    Margin = new Padding(0)
                };
                costo_textura.KeyDown += new KeyEventHandler(costos_KeyDown);
                costo_textura.KeyPress += new KeyPressEventHandler(costos_KeyPress);
                costo_textura.TextChanged += new EventHandler(cambio_texto);
                tabla_costos.Controls.Add(nombre_textura, 0, tabla_costos.RowCount - 1);
                tabla_costos.Controls.Add(costo_textura, 1, tabla_costos.RowCount - 1);
            }
        }
        private void cambio_texto(object sender, EventArgs e)
        {

        }
        private void quitar_costos_anteriores()
        {
            var cantidad = tabla_costos.RowCount;
            for(int i = cantidad - 1; i > 0; i--)
            {
                tabla_costos.GetControlFromPosition(0, i).Dispose();
                tabla_costos.GetControlFromPosition(1, i).Dispose();
                tabla_costos.RowStyles.RemoveAt(i);
            }
            tabla_costos.RowCount = 1;
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
                opciones.Add((i + 1).ToString()); 
            }
            comboFilaO.Items.AddRange(opciones.ToArray());
            comboFilaD.Items.AddRange(opciones.ToArray());
            opciones.Clear();
            for (int i = 0; i < tablero.dimensiones["columnas"]; i++)
            {
                opciones.Add(char.ConvertFromUtf32(65 + i));
            }
            comboColumnaO.Items.AddRange(opciones.ToArray());
            comboColumnaD.Items.AddRange(opciones.ToArray());
        }
        void dibujar_personaje(int fila, int columna)
        {
            var personaje = personajes[personaje_seleccionado];
            var casilla = tabla.GetControlFromPosition(columna + 1, fila + 1) as Label;
            var dibujo_personaje = Image.FromFile(personaje.archivo);
            casilla.Image = new Bitmap(dibujo_personaje, new Size(45, 45));
            casilla.Text += " "+visita.ToString();
            visita++;
        }
        void dibujar_inicio(int fila, int columna)
        {
            var d = new Dictionary<string, int>();
            d.Add("fila", fila);
            d.Add("columna", columna);
            if (!es_habitable(d))
            {
                Utilidades.mensaje_de_error("El personaje no puede estar en esta casilla");
                comboFilaO.SelectedIndex = -1;
                comboColumnaO.SelectedIndex = -1;
                return;
            }
            var personaje = personajes[comboBox1.SelectedIndex];
            var casilla = tabla.GetControlFromPosition(columna + 1, fila + 1) as Label;
            var dibujo_personaje = Image.FromFile(personaje.archivo);
            casilla.Image = new Bitmap(dibujo_personaje, new Size(50, 50));
            casilla.Text = "Inicio, 1";
        }
        private void comboFilaO_SelectedIndexChanged(object sender, EventArgs e)
        {
            var fila = comboFilaO;
            var columna = comboColumnaO;
            if(columna.Text != "" && columna.SelectedIndex != -1 && fila.SelectedIndex != -1)
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
            if (fila.Text != "" && columna.SelectedIndex != -1 && fila.SelectedIndex != -1)
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
            if (columna.Text != "" && columna.SelectedIndex != -1 && fila.SelectedIndex != -1)
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
            if (fila.Text != "" && columna.SelectedIndex != -1 && fila.SelectedIndex != -1)
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
            var d = new Dictionary<string, int>();
            d.Add("fila", fila);
            d.Add("columna", columna);
            if (!es_habitable(d))
            {
                Utilidades.mensaje_de_error("El personaje no puede estar en esta casilla");
                comboFilaD.SelectedIndex = -1;
                comboColumnaD.SelectedIndex = -1;
                return;
            }
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
        private void verificar_victoria()
        {
            if(tablero.coordenadas_personaje["fila"] == tablero.coordenadas_fin["fila"] && tablero.coordenadas_personaje["columna"] == tablero.coordenadas_fin["columna"])
            {
                MessageBox.Show("Victoria!");
                button2.Enabled = true;
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
        private void mapaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            iniciar_configuracion();
        }
        private void reiniciar_laberinto()
        {
            tabla.SuspendLayout();
            Label casilla;
            borrar_meta();
            for(int i = 1; i <= tablero.dimensiones["filas"]; i++)
            {
                for(int j = 1; j <= tablero.dimensiones["columnas"]; j++)
                {
                    casilla = tabla.GetControlFromPosition(j, i) as Label;
                    if (casilla == null || casilla.Text == "") continue;
                    casilla.Text = "";
                }
            }
            tabla.ResumeLayout();
        }
        private void Formulario_Juego_KeyDown(object sender, KeyEventArgs e)
        {
            if (juego_iniciado)
            {
                var coordenada = Calcular_coordenada(e.KeyCode);

                if(coordenada != null)
                {
                    if (!es_coordenada_valida(coordenada) || !es_habitable(coordenada))
                    {
                        System.Media.SystemSounds.Asterisk.Play();
                        e.Handled = true;
                        return;
                    }

                    borrar_personaje(tablero.coordenadas_personaje["fila"], tablero.coordenadas_personaje["columna"]);
                    mover_personaje(coordenada);
                    verificar_victoria();

                }
            }
            e.Handled = true;
        }
        private Dictionary<string,int> Calcular_coordenada(Keys tecla)
        {
            var coordenada = new Dictionary<string,int>();
            coordenada.Add("fila", tablero.coordenadas_personaje["fila"]);
            coordenada.Add("columna", tablero.coordenadas_personaje["columna"]);

            if(tecla == Keys.Up)
            {
                coordenada["fila"] --;
            }
            else if(tecla == Keys.Right)
            {
                coordenada["columna"] ++;
            }
            else if(tecla == Keys.Down)
            {
                coordenada["fila"] ++;
            }
            else if(tecla == Keys.Left)
            {
                coordenada["columna"] --;
            }
            else 
            {
                coordenada = null;
            }

            return coordenada;
        }
        private void costos_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            string texto = (sender as TextBox).Text;
            nonNumberEntered = false;
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    if (e.KeyCode != Keys.Back && e.KeyCode != Keys.Decimal && e.KeyCode != Keys.OemPeriod && e.KeyCode != Keys.Subtract && e.KeyCode != Keys.OemMinus)
                    {
                        nonNumberEntered = true;
                    }
                }
            }
            if (e.KeyCode == Keys.Decimal || e.KeyCode == Keys.OemPeriod)
            {
                if (texto == "" || texto.Contains("."))
                {
                    nonNumberEntered = true;
                }
            }
            else if (e.KeyCode == Keys.Subtract || e.KeyCode == Keys.OemMinus)
            {
                if (texto != "")
                {
                    nonNumberEntered = true;
                }
            }
            else if (Control.ModifierKeys == Keys.Shift)
            {
                nonNumberEntered = true;
            }
            if (texto.Contains("-") && e.KeyCode != Keys.Back)
            {
                if(e.KeyCode != Keys.D1 && e.KeyCode != Keys.Oem1)
                {
                    nonNumberEntered = true;
                }
            }
            if (texto.Contains('.') && texto.IndexOf('.') == texto.Length - 3 && e.KeyCode != Keys.Back)
            {
                nonNumberEntered = true;
            }
        }
        private void costos_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (nonNumberEntered == true)
            {
                e.Handled = true;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            reiniciar_laberinto();
            desbloquear_controles();
            tablero.coordenadas_fin["fila"] = -1;
            tablero.coordenadas_fin["columna"] = -1;
            tablero.coordenadas_inicio["fila"] = -1;
            tablero.coordenadas_inicio["columna"] = -1;
            tablero.coordenadas_personaje["fila"] = -1;
            tablero.coordenadas_personaje["columna"] = -1;
        }
        private void button3_Click(object sender, EventArgs e)
        {
        }
    }
}
