using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace laberinto
{
    public partial class Formulario_Juego : Form
    {
        Tablero tablero;
        List<Personaje> personajes;
        List<Textura> texturas;
        Dictionary<string, Textura> terreno_textura;
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
            var temp = ventana.terrenos_valuados;
            if (temp.Count == 0)
            {
                Utilidades.mensaje_de_error("Error en la configuración de las texturas");
                return;
            }
            terreno_textura = temp;
        }

        private void Formulario_Juego_Shown(object sender, EventArgs e)
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

        
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
