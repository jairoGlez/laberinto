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
    public partial class Form_Prioridad : Form
    {
        public Form_Prioridad()
        {
            InitializeComponent();
        }

        public string[] lista_de_prioridades()
        {
            var lineas = listBoxPrioridad.Items;
            string[] prioridades = new string[4];
            int i = 0;
            foreach(string linea in lineas)
            {
                prioridades[i] = linea;
                i++;
            }
            return prioridades;
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            if(listBoxPrioridad.SelectedIndex == -1)
            {
                MessageBox.Show("Selecciona un elemento a mover","Error");
            }
            else
            {
                int Indice_nuevo = listBoxPrioridad.SelectedIndex - 1;

                if (Indice_nuevo < 0)
                    return;

                object item_select = listBoxPrioridad.SelectedItem;

                listBoxPrioridad.Items.Remove(item_select);

                listBoxPrioridad.Items.Insert(Indice_nuevo, item_select);

                listBoxPrioridad.SetSelected(Indice_nuevo, true);
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            if (listBoxPrioridad.SelectedIndex == -1)
            {
                MessageBox.Show("Selecciona un elemento a mover", "Error");
            }
            else
            {
                int Indice_nuevo = listBoxPrioridad.SelectedIndex + 1;

                if (Indice_nuevo >= listBoxPrioridad.Items.Count)
                    return;

                object item_select = listBoxPrioridad.SelectedItem;

                listBoxPrioridad.Items.Remove(item_select);

                listBoxPrioridad.Items.Insert(Indice_nuevo, item_select);

                listBoxPrioridad.SetSelected(Indice_nuevo, true);
            }
        }

        public void btnGuardarPrioridad_Click(object sender, EventArgs e)
        {
            //this.Close();

                                   
            pictureBox1.ImageLocation = "D:/Desktop/Inteligencia Artificial/Proyectoo/bin/Debug/Prioridad/" + listBoxPrioridad.Items[0] + ".png";
            pictureBox2.ImageLocation = "D:/Desktop/Inteligencia Artificial/Proyectoo/bin/Debug/Prioridad/" + listBoxPrioridad.Items[1] + ".png";
            pictureBox3.ImageLocation = "D:/Desktop/Inteligencia Artificial/Proyectoo/bin/Debug/Prioridad/" + listBoxPrioridad.Items[2] + ".png";
            pictureBox4.ImageLocation = "D:/Desktop/Inteligencia Artificial/Proyectoo/bin/Debug/Prioridad/" + listBoxPrioridad.Items[3] + ".png";
        }
    }
}
