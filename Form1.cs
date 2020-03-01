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
    public partial class Form_Inicio : Form
    {
        private OpenFileDialog ventana_archivo;
        private string ruta_del_archivo;
        private List<string[]> filas;
        public Form_Inicio()
        {
            InitializeComponent();
            ventana_archivo = new OpenFileDialog()
            {
                Filter = "Text files (*.txt)|*.txt",
                Title = "Selecciona el archivo del Mapa"
            };
            ruta_del_archivo = "";
        }
        public List<string[]> filas_leidas()
        {
            return this.filas;
        }
        private void btn_SeleccionarArchivo_Click(object sender, EventArgs e)
        {
            if (ventana_archivo.ShowDialog() == DialogResult.OK)
            {   
                try
                {
                    ruta_del_archivo = ventana_archivo.FileName;
                    label_NombreArchivo.Text = ventana_archivo.SafeFileName;
                    if (ruta_del_archivo != "")
                    {
                        this.btn_Cargar.Enabled = true;
                    }
                    else
                    {
                        this.btn_Cargar.Enabled = false;
                    }
                }
                catch(Exception exc)
                {
                    utilidades.mensaje_de_error(exc.Message);
                }
            }
        }

        private void btn_Cargar_Click(object sender, EventArgs e)
        {
            filas = utilidades.leer_archivo(ruta_del_archivo);
            Application.Exit();
        }
    }
}
