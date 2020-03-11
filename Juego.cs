using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace laberinto
{
    public partial class Formulario_Juego : Form
    {
        Tablero tablero;
        List<Personaje> personajes;
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
            ventana.ShowDialog();
        }

        private void Formulario_Juego_Shown(object sender, EventArgs e)
        {
            var filas = mostrar_ventana_cargar();
            this.tablero = new Tablero(filas);
            mostrar_ventana_configuracion();
        }
    }
}
