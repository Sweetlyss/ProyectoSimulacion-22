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
    public partial class PI : Form
    {
        public PI()
        {
            InitializeComponent();
        }
        double A, C, M, X0, XR, XN, AUX = 0, MEDIA;

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

        private void button4_Click(object sender, EventArgs e)
        {

            if (Numeros != null)
            {
                //asignacion de varibales 
                Pi = double.Parse(txtPi.Text);
                tol = double.Parse(txtTolerancia.Text);
                limiteInf = Pi * (1 - (tol / 100));
                limiteSup = Pi * (1 + (tol / 100));
                txtlimiteinf.Text = limiteInf.ToString();
                txtLimiteSup.Text = limiteSup.ToString();
                N = double.Parse(txtnum.Text);
                for (int i = 0; i < N; i++)
                {
                    // generar tabla y calculos
                    int n = dataGridView2.Rows.Add();
                    dataGridView2.Rows[n].Cells[0].Value = (i + 1);
                    dataGridView2.Rows[n].Cells[1].Value = Numeros[i];
                    dataGridView2.Rows[n].Cells[2].Value = Numeros[i + 2];
                    distancia = Math.Sqrt(Math.Pow(Numeros[i], 2) + Math.Pow(Numeros[i + 1], 2));
                    dataGridView2.Rows[n].Cells[3].Value = distancia;
                    if (distancia < 1)
                    {
                        dataGridView2.Rows[n].Cells[4].Value = "Si";
                        si = si + 1;
                    }
                    else
                    {
                        dataGridView2.Rows[n].Cells[4].Value = "No";
                    }
                    txtTotalSec.Text = si.ToString();
                    txtTotalCuadrado.Text = N.ToString();
                    PiCal = 4 * (si / N);

                    txtValorPi.Text = PiCal.ToString();
                    tem = PiCal;

                    if (tem > limiteInf && tem <= limiteSup)
                    {
                        lblres.Text = "Valor de PI ACEPTADO";
                    }
                    else
                    {
                        lblres.Text = "Valor de PI RECHAZADO";
                    }

                }


            }
            else
            {
                MessageBox.Show("Genere primero los numeros pseudoaleatorios");
            }
        }
        public static double Pi, tol, limiteInf = 0, limiteSup = 0, N, si = 0, PiCal, tem;
        double distancia;
        private void txtTolerancia_TextChanged(object sender, EventArgs e)
        {
            Pi = double.Parse(txtPi.Text);

            tol = double.Parse(txtTolerancia.Text);
            limiteInf = Pi * (1 - (tol / 100));
            limiteSup = Pi * (1 + (tol / 100));
            txtlimiteinf.Text = limiteInf.ToString();
            txtLimiteSup.Text = limiteSup.ToString();
        }

        int NUM;
        public static double[] Numeros;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            //Salir de la aplicacion
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Menu n = new Menu();
            n.Show();
            this.Hide();

        }

        private void button1_Click(object sender, EventArgs e)
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
    }
}
