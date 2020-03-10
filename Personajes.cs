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
    public partial class Form_Personaje : Form
    {
        public Form_Personaje()
        {
            InitializeComponent();
        }

        private void abrirformulariohijo(object formhijo)
        {
            if (this.panel_contenedor_personajes.Controls.Count > 0)
            {
                this.panel_contenedor_personajes.Controls.RemoveAt(0);
            }

            Form fh = formhijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panel_contenedor_personajes.Controls.Add(fh);
            this.panel_contenedor_personajes.Tag = fh;
            fh.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            abrirformulariohijo(new Formulario_Personaje1());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            abrirformulariohijo(new Formulario_Personaje2());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            abrirformulariohijo(new Formulario_Personaje3());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            abrirformulariohijo(new Formulario_Personaje4());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            abrirformulariohijo(new Formulario_Personaje5());
        }

        private void btn_SiguientePersonaje_Click(object sender, EventArgs e)
        {
            Form form = new Formulario_Juego();
            form.Show();
        }

        private void cargar_num_personajes()
        {
            int x = 5;

            for (int y = 1; y <= x; )
            {
                this.CB_Num_Personajes.Items.Add(y);
                y++;

            }

        }

        private void Form_Personaje_Load(object sender, EventArgs e)
        {
            cargar_num_personajes();
        }
    }
}
