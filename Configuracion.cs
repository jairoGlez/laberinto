using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laberinto
{
    public partial class Form_Configuracion : Form
    {
        public Form_Configuracion(Dictionary<string, string> terrenos)
        {
            InitializeComponent();
            crear_ventana(terrenos);
        }
        private void crear_ventana(Dictionary<string, string> terrenos)
        {
            var contenedor = this.panel3;
            var posicion_horizontal_codigos = 242;
            var posicion_horizontal_combos = 332;
            var posicion_vertical = 38;
            TextBox txt_codigo_terreno;
            ComboBox combo_texturas;

            foreach (KeyValuePair<string,string> terreno in terrenos)
            {
                txt_codigo_terreno = new TextBox()
                {
                    ReadOnly = true,
                    Size = new Size(50, 20),
                    Location = new Point(posicion_horizontal_codigos, posicion_vertical),
                    Text = terreno.Key
                };
                combo_texturas = new ComboBox()
                {
                    Size = new Size(195, 20),
                    Location = new Point(posicion_horizontal_combos, posicion_vertical)
                };
                contenedor.Controls.Add(txt_codigo_terreno);
                contenedor.Controls.Add(combo_texturas);
                posicion_vertical += 24;
            }
        }
        private void abrirformulariohijo(object formhijo)
        {
            if (this.panel_contenedor.Controls.Count > 0)
            {
                this.panel_contenedor.Controls.RemoveAt(0);
            }

            Form fh = formhijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panel_contenedor.Controls.Add(fh);
            this.panel_contenedor.Tag = fh;
            fh.Show();
        }

        private void btn_SiguienteTerreno_Click(object sender, EventArgs e)
        {
            panel_contenedor.Controls.Clear();
            abrirformulariohijo(new Form_Personaje());
        }
    }
}
