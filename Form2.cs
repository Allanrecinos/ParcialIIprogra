using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculadoradeCuotas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Btncalc_Click(object sender, EventArgs e)
        {

            if (!double.TryParse(txtmont.Text, out double montoPrestamo) ||
                !double.TryParse(txtint.Text, out double tasaInteres) ||
                !int.TryParse(txtcuo.Text, out int numeroCuotas))
            {
                return;
            }


            tasaInteres /= 100;
            double tasaPeriodica = tasaInteres / 12;


            double cuota = (montoPrestamo * tasaPeriodica * Math.Pow(1 + tasaPeriodica, numeroCuotas)) / (Math.Pow(1 + tasaPeriodica, numeroCuotas) - 1);


            MessageBox.Show($"La cuota mensual es: {cuota:C}", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}