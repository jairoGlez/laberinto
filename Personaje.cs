using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace laberinto
{
    public partial class Formulario_Personaje : Form
    {
        Dictionary<string, string> archivos_avatares;
        Dictionary<string, Textura> texturas;
        string[] nombres_avatares;
        List<string> avatares_seleccionados;
        TableLayoutPanel tabla;
        Personaje personaje_creado;
        bool nonNumberEntered;
        public Formulario_Personaje(Dictionary<string, Textura> texturas)
        {
            InitializeComponent();
            this.texturas = texturas;
            this.avatares_seleccionados = new List<string>();
            cargar_avatares();
            comboBox_avatar.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_avatar.DrawMode = DrawMode.OwnerDrawFixed;
            comboBox_avatar.ItemHeight = 32;
            comboBox_avatar.SelectionChangeCommitted += new System.EventHandler(selecciona_avatar);
            comboBox_avatar.DrawItem += new DrawItemEventHandler(dibujar_items_combo_avatares);
            tabla = new TableLayoutPanel()
            {
                AutoSize = true,
                ColumnCount = 3,
                RowCount = 1,
                Dock = DockStyle.Top
            };
        }
        public void preparar()
        {
            comboBox_avatar.Items.Clear();
            List<string> avatares_disponibles = new List<string>();
            foreach(var avatar in nombres_avatares)
            {
                if (!avatares_seleccionados.Contains(avatar))
                {
                    avatares_disponibles.Add(avatar as string);
                }
            }
            comboBox_avatar.Items.AddRange(avatares_disponibles.ToArray());
            cargar_texturas();
            personaje_creado = null;
        }
        public Personaje obtener_personaje()
        {
            return personaje_creado;
        }
        public bool personaje_completado()
        {
            var respuesta = true;
            var todos_na = true;
            var avatar = comboBox_avatar.SelectedItem;
            var inputs = tabla.Controls.OfType<TextBox>();
            var costos = new Dictionary<string, decimal>();
            Decimal valor_costo;
            label_error.Text = "";
            if (inputs.Count() == 0)
            {
                Utilidades.mensaje_de_error("Error en la tabla");
                respuesta = false;
            }
            //Verificar que se hallan asignado todos los costos
            foreach(TextBox costo in inputs)
            {
                if(costo.Text == "")
                {
                    label_error.Text = "Debes asignar todos los costos";
                    return false;
                }
                valor_costo = Math.Round(decimal.Parse(costo.Text), 2);
                if (valor_costo != -1) todos_na = false;
                costos.Add(costo.Name, valor_costo);
            }
            //Verifica que se halla seleccionado un avatar
            if(avatar == null)
            {
                label_error.Text = "Debes seleccionar un avatar";
                return false;
            }
            //Verifica que no todos los costos sean NA
            if (todos_na)
            {
                label_error.Text = "No todos los costos pueden ser N/A";
                return false;
            }
            avatares_seleccionados.Add(avatar as string);
            personaje_creado = new Personaje(avatar as string, archivos_avatares[avatar as string], costos);
            return respuesta;
        }
        private void cargar_avatares()
        {
            archivos_avatares = new Dictionary<string, string>();
            var rutas = Directory.GetFiles("Personajes", "*.png");
            foreach(string ruta in rutas)
            {
                this.archivos_avatares.Add(Path.GetFileNameWithoutExtension(ruta), ruta);
            }
            nombres_avatares = this.archivos_avatares.Keys.ToArray();
        }
        private void selecciona_avatar(object sender, EventArgs e)
        {

        }
        private void dibujar_items_combo_avatares(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            e.DrawFocusRectangle();
            if (e.Index >= 0)
            {
                var opcion = (sender as ComboBox).Items[e.Index];
                var nombre_de_avatar = opcion as string;
                if (e.Index < nombres_avatares.Count())
                {
                    Image avatar = Image.FromFile(archivos_avatares[nombre_de_avatar]);
                    var miniatura = new Bitmap(avatar, new Size(32, 32));
                    e.Graphics.DrawImage(miniatura, new PointF(e.Bounds.Left, e.Bounds.Top));
                }
                e.Graphics.DrawString(nombre_de_avatar, e.Font, new SolidBrush(e.ForeColor), e.Bounds.Left + 32, e.Bounds.Top);
            }
        }
        private void cargar_texturas()
        {
            tabla.SuspendLayout();
            tabla.Controls.Clear();
            tabla.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            tabla.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize ));
            tabla.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize ));
            tabla.RowStyles.Add(new RowStyle(SizeType.Absolute, 25));
            tabla.Controls.Add(new Label() { Text = "Terreno", TextAlign = ContentAlignment.MiddleLeft}, 0, 0);
            tabla.Controls.Add(new Label() { Text = "Costo", TextAlign = ContentAlignment.MiddleLeft }, 1, 0);
            tabla.Controls.Add(new Label() { Text = "", TextAlign = ContentAlignment.MiddleLeft }, 2, 0);
            foreach (var textura in texturas)
            {
                var imagen = new PictureBox()
                {
                    Image = Image.FromFile(textura.Value.ruta),
                    Height = 30,
                    Width = 30,
                    SizeMode = PictureBoxSizeMode.Normal
                };
                var input_costo = new TextBox()
                {
                    Name = textura.Key,
                    Height = 20,
                    Width = 40
                };
                var boton_NA = new Button()
                {
                    Text = "N/A",
                    Height = 20,
                    Width = 40,
                    Name = tabla.RowCount.ToString()
                };
                input_costo.KeyDown += new KeyEventHandler(textBox1_KeyDown);
                input_costo.KeyPress += new KeyPressEventHandler(textBox1_KeyPress);
                boton_NA.Click += new EventHandler(boton_na_click);

                tabla.RowCount += 1;
                tabla.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
                tabla.Controls.Add(imagen, 0, tabla.RowCount - 1);
                tabla.Controls.Add(input_costo, 1, tabla.RowCount - 1);
                tabla.Controls.Add(boton_NA, 2, tabla.RowCount - 1);
            }
            tabla.ResumeLayout();
            panel1.Controls.Add(tabla);
        }
        private void boton_na_click(object sender, EventArgs e)
        {
            var fila = int.Parse((sender as Button).Name);
            var campo = (tabla.GetControlFromPosition(1, fila)) as TextBox;
            if (campo.ReadOnly)
            {
                campo.ReadOnly = false;
                campo.Clear();
                return;
            }
            campo.Text = "-1";
            campo.ReadOnly = true;

        }
        private void textBox1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            nonNumberEntered = false;
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    if (e.KeyCode != Keys.Back && e.KeyCode != Keys.Decimal && e.KeyCode != Keys.OemPeriod)
                    {
                        nonNumberEntered = true;
                    }
                }
            }
            if (e.KeyCode == Keys.Decimal || e.KeyCode == Keys.OemPeriod)
            {
                var texto = (sender as TextBox).Text;
                if (texto == "" || texto.Contains("."))
                {
                    nonNumberEntered = true;
                }
            }
            if (Control.ModifierKeys == Keys.Shift)
            {
                nonNumberEntered = true;
            }
        }
        private void textBox1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (nonNumberEntered == true)
            {
                e.Handled = true;
            }
        }
    }
}
