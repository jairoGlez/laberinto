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
    public partial class Arbol : Form
    {
        public List<List<string>> datos;

        public Arbol()
        {
            InitializeComponent();
        }

        public void dibujar_arbol()
        {
            foreach(var padre in datos)
            {
                var texto = padre[0];
                padre.RemoveAt(0);
                var nodoPadre = new TreeNode(texto);

                foreach(var hijo in padre)
                {
                    var nodoHijo = new TreeNode(hijo);
                    nodoPadre.Nodes.Add(nodoHijo);
                }

                treeArbolGen.Nodes.Add(nodoPadre);
            }


        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            var fjuego = new Formulario_Juego();
            fjuego.Show();
        }

    }
}
