using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinal_Simulacion22
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //Salir de la aplicacion
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            VOLADOS n = new VOLADOS();
            n.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MANZANAS n = new MANZANAS();
            n.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PI n = new PI();
            n.Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
