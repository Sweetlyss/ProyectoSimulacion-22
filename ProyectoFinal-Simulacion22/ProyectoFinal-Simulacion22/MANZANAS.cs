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
    public partial class MANZANAS : Form
    {
        public MANZANAS()
        {
            InitializeComponent();
        }

        double A, C, M, X0, XR, XN, AUX = 0, MEDIA, Cajas, Precio;

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

        private void button3_Click(object sender, EventArgs e)
        {
            txtCaja.Text = "";
            txtPrecio.Text = "";
            dataGridView2.Rows.Clear();
            lblres.Text = "---";
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

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                Cajas = Double.Parse(txtCaja.Text);
                Precio = Double.Parse(txtPrecio.Text);
                int ContadorGan = 0;
                int ContadorPer = 0;

                double Resultado = (Cajas * Precio) * .7;

                double Res = (Cajas * Precio) * -.1;

                for (int i = 0; i < NUM; i++)
                {
                    int n = dataGridView2.Rows.Add();
                    dataGridView2.Rows[n].Cells[0].Value = i + 1;

                    dataGridView2.Rows[n].Cells[1].Value = Numeros[i];

                    if (Numeros[i] < 0.15)
                    {
                        dataGridView2.Rows[n].Cells[2].Value = Numeros[i].ToString("Dia 3 ganancia:" + Resultado);
                        ContadorGan++;
                    }
                    else if (Numeros[i] > 0.16 && Numeros[i] < 0.23)
                    {
                        dataGridView2.Rows[n].Cells[2].Value = Numeros[i].ToString("Dia 5 ganancia: " + Resultado);
                        ContadorGan++;
                    }
                    else if (Numeros[i] > 0.24 && Numeros[i] < 0.35)
                    {
                        dataGridView2.Rows[n].Cells[2].Value = Numeros[i].ToString("Dia 8 ganancia: " + Resultado);
                        ContadorGan++;
                    }
                    else if (Numeros[i] > 0.36 && Numeros[i] < 0.55)
                    {
                        dataGridView2.Rows[n].Cells[2].Value = Numeros[i].ToString("Dia 10 ganancia: " + Resultado);
                        ContadorGan++;
                    }
                    else if (Numeros[i] > 0.56 && Numeros[i] < 0.80)
                    {
                        dataGridView2.Rows[n].Cells[2].Value = Numeros[i].ToString("Dia 14 ganancia: " + Resultado);
                        ContadorGan++;
                    }
                    else
                    {
                        dataGridView2.Rows[n].Cells[3].Value = Numeros[i].ToString("Dia 16 perdida: " + Res);
                        ContadorPer++;
                    }
                }

                if (ContadorGan > ContadorPer)
                {

                    lblres.Text = ContadorGan.ToString("VENDE Y GANA EL SETENTA PORCIENTO");

                }
                else
                {

                    lblres.Text = ContadorGan.ToString("VENDE O PERDERAS EL DIEZ PORCIENTO");

                }

            }
            catch (Exception)
            {
                MessageBox.Show("Debe de ingresar un valor numerico");
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        int NUM;
        public static double[] Numeros;
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
