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
        Textura[] texturas;
        string[] nombres_avatares;
        string[] avatares_seleccionados;
        bool nonNumberEntered;
        public Formulario_Personaje(Textura[] texturas)
        {
            InitializeComponent();
            this.texturas = texturas;
            cargar_avatares();
            cargar_texturas();
            comboBox7.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox7.DrawMode = DrawMode.OwnerDrawFixed;
            comboBox7.ItemHeight = 32;
            comboBox7.Items.AddRange(nombres_avatares);
            comboBox7.SelectionChangeCommitted += new System.EventHandler(selecciona_avatar);
            comboBox7.DrawItem += new DrawItemEventHandler(dibujar_items_combo_avatares);
        }
        private void cargar_avatares()
        {
            archivos_avatares = new Dictionary<string, string>();
            var rutas = Directory.GetFiles("Personajes", "*.*");
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
            var tabla = new TableLayoutPanel();
            tabla.AutoSize = true;
            tabla.ColumnCount = 2;
            tabla.RowCount = 1;
            tabla.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tabla.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tabla.RowStyles.Add(new RowStyle(SizeType.Absolute, 20));
            tabla.Controls.Add(new Label() { Text = "Terreno", Dock = DockStyle.Fill}, 0, 0);
            tabla.Controls.Add(new Label() { Text = "Costo", Dock = DockStyle.Fill}, 1, 0);
            foreach (var textura in texturas)
            {
                var imagen = new PictureBox()
                {
                    Image = Image.FromFile(textura.ruta),
                    Height = 20,
                    Width = 130,
                    SizeMode = PictureBoxSizeMode.Normal
                };
                var input_costo = new TextBox()
                {
                    Height = 20,
                    Width = 50,
                    Dock = DockStyle.Fill,
                };
                input_costo.KeyDown += new KeyEventHandler(textBox1_KeyDown);
                input_costo.KeyPress += new KeyPressEventHandler(textBox1_KeyPress);
                tabla.RowCount += 1;
                tabla.RowStyles.Add(new RowStyle(SizeType.Absolute, 20));
                tabla.Controls.Add(imagen, 0, tabla.RowCount - 1);
                tabla.Controls.Add(input_costo, 1, tabla.RowCount - 1);
            }
            panel1.Controls.Add(tabla);
        }
        private void textBox1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            nonNumberEntered = false;
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    if (e.KeyCode != Keys.Back && e.KeyCode != Keys.Decimal)
                    {
                        nonNumberEntered = true;
                    }
                }
            }
            if (e.KeyCode == Keys.Decimal)
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
