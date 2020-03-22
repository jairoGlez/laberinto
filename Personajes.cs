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
    public partial class Configurador_personajes : Form
    {
        Formulario_Personaje form_personaje;
        Personaje[] personajes;
        int personaje_seleccionado;

        public Configurador_personajes(Textura[] texturas)
        {
            InitializeComponent();
            form_personaje = new Formulario_Personaje(texturas);
            form_personaje.TopLevel = false;
            form_personaje.Dock = DockStyle.Fill;
        }

        private void abrir_formulario_personaje()
        {
            if (this.panel_contenedor_personajes.Controls.Count > 0)
            {
                this.panel_contenedor_personajes.Controls.RemoveAt(0);
            }
            this.panel_contenedor_personajes.Controls.Add(form_personaje);
            this.panel_contenedor_personajes.Tag = form_personaje;
            form_personaje.Show();
        }

        private void btn_SiguientePersonaje_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
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

        private void colocar_botones()
        {
            var botones = contenedor_botones.Controls.OfType<Button>();
            var cantidad_botones_viejos = botones.Count();
            var cantidad = int.Parse(CB_Num_Personajes.SelectedItem.ToString());
            var posicion_horizontal = 12;
            var posicion_vertical = 0;
            var limite_de_copiado = cantidad > cantidad_botones_viejos ? cantidad_botones_viejos : cantidad;
            Button boton;
            Personaje[] nueva_lista_personajes = new Personaje[cantidad];
            for (int i = 0; i < cantidad_botones_viejos; i++)
            {
                contenedor_botones.Controls.Remove(botones.First());
            }
            
            for(int i = 0; i < cantidad; i++)
            {
                boton = new Button()
                {
                    Name = (i + 1).ToString(),
                    Text = "Personaje " + (i + 1).ToString(),
                    Size = new Size(103,37),
                    Location = new Point(posicion_horizontal, posicion_vertical)
                };
                boton.Click += new System.EventHandler(boton_personaje_click);
                contenedor_botones.Controls.Add(boton);
                posicion_vertical += 50;
            }

            if (limite_de_copiado != 0)
            {
                for (int i = 0; i < limite_de_copiado; i++)
                {
                    nueva_lista_personajes[i] = personajes[i];
                }
            }
            personajes = nueva_lista_personajes;
        }

        private void boton_personaje_click(object sender, EventArgs e)
        {
            var boton = sender as Button;
            personaje_seleccionado = int.Parse(boton.Name);
            abrir_formulario_personaje();
        }

        private void CB_Num_Personajes_SelectionChangeCommitted_1(object sender, EventArgs e)
        {
            colocar_botones();
        }

        private void boton_guardar_personaje_Click(object sender, EventArgs e)
        {
            //todo
        }
    }
}
