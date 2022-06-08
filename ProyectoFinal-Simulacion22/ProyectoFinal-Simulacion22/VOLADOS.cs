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
    public partial class VOLADOS : Form
    {
        public VOLADOS()
        {
            InitializeComponent();
        }
        //Variables globales
        double A, C, M, X0, XR, XN, AUX = 0, MEDIA;

        private void button3_Click(object sender, EventArgs e)
        {
            txtApuesta.Text = "";
            txtGanadas.Text = "";
            txtJuegos.Text = "";
            txtMontoInicial.Text = "";
            txtPerdidas.Text = "";
            dataGridView2.Rows.Clear();
            lblganar.Text = "";
            lbldinero.Text = "";
            lblPerder.Text = "";
            txtMontoInicial.Focus();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Menu n = new Menu();
            n.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void VOLADOS_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            valorA.Text = "";
            valorC.Text = "";
            valorM.Text = "";
            valorX0.Text = "";
            NumerosG.Text = "";
            dataGridView1.Rows.Clear();
            valorA.Focus();
        }

        int NUM;
        public static double[] Numeros;
        public static double Monto, Apuesta, pierde = 0, gana = 0;
        int juegos;
        private void button4_Click(object sender, EventArgs e)
        {
            if (Numeros != null)
            {
                try
                {
                    Monto = double.Parse(txtMontoInicial.Text);
                    Apuesta = double.Parse(txtApuesta.Text);
                    juegos = int.Parse(txtJuegos.Text);

                    dataGridView2.Refresh();
                    for (int i = 0; i < juegos; i++)
                    {

                        int n = dataGridView2.Rows.Add();
                        dataGridView2.Rows[n].Cells[0].Value = (i + 1);
                        dataGridView2.Rows[n].Cells[1].Value = Numeros[i];
                        if (Numeros[i] < 0.5)
                        {

                            dataGridView2.Rows[n].Cells[2].Value = "PERDISTE :(";
                            Monto = Monto - Apuesta;
                            pierde = pierde + 1;
                            dataGridView2.Rows[n].Cells[3].Value = Monto;

                            if (Monto < 0)
                            {
                                lbldinero.Text = "YA NO TIENES DINERO :(";
                                lblganar.Hide();
                                lblPerder.Hide();
                                break;

                            }
                        }
                        else if (Numeros[i] > 0.5 && Numeros[i] < 1)
                        {
                            dataGridView2.Rows[n].Cells[2].Value = "♥¡GANASTE!♥";
                            Monto = Monto + Apuesta;
                            gana = gana + 1;
                            dataGridView2.Rows[n].Cells[3].Value = Monto;
                        }

                        txtGanadas.Text = gana.ToString();
                        txtPerdidas.Text = pierde.ToString();
                        if (gana > pierde)
                        {
                            lblganar.Show();
                            lblPerder.Hide();
                            lblganar.Text = ("¡FELICIDADES!");
                        }
                        else if (gana < pierde)
                        {
                            lblPerder.Text = "CASI...";
                            lblPerder.Show();
                            lblganar.Hide();
                        }
                        else if (gana == pierde)
                        {
                            lblganar.Hide();
                            lblPerder.Show();
                            lblPerder.Text = "INTENTALO DESPUES";
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Ingresa la informacion.");
                }


            }
            else
            {
                MessageBox.Show("Generelos números pseudoaleatorios");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //asignacion de variables 
                A = Double.Parse(valorA.Text);
                C = Double.Parse(valorC.Text);
                M = Double.Parse(valorM.Text);
                X0 = Double.Parse(valorX0.Text);
                NUM = int.Parse(NumerosG.Text);
                Numeros = new double[NUM];

                //CICLO PARA REPETIR LAS OPERACIONES 
                for (int i = 0; i < NUM; i++)
                {
                    //Almacena los numeros 
                    int n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells[0].Value = i + 1;
                    //formula para generar numeros 
                    XN = (((A * X0) + C) % M);
                    XR = (XN / M);
                    //Redondeo de decimales 
                    XR = Math.Round(XR, 5);
                    double d = XR;
                    X0 = Convert.ToInt32(XR * M);
                    Numeros[i] = XR;
                    //variable para acumular los numeros 
                    AUX = AUX + XR;
                    //mostar los datos en la tabla 
                    dataGridView1.Rows[n].Cells[1].Value = XR.ToString();

                }
                MEDIA = AUX / NUM;
            }
            catch (Exception)
            {
                MessageBox.Show("Debe de ingresar un valor numerico");
            }
        }
    }
}
