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

        private void btnGuardarPrioridad_Click(object sender, EventArgs e)
        {
           String[] matriz = new String[listBoxPrioridad.Items.Count];
             for (int i = 0; i < listBoxPrioridad.Items.Count; i++)
             {
                 matriz[i] = listBoxPrioridad.Items[i].ToString();
             }
           // listBox_prueba.Items.AddRange(listBoxPrioridad.Items);  //para prueba
        }
    }
}
