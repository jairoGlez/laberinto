using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laberinto
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var filas = new List<string[]>();
            var ventana_1 = new Form_Inicio();

            Application.Run(ventana_1);

            filas = ventana_1.filas_leidas();
            ventana_1.Dispose();

            Console.WriteLine("leido {0}", filas);
/*
            var tablero = new Tablero(filas);*/
        }
    }
}
