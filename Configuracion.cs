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
        public Form_Configuracion()
        {
            InitializeComponent();
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
