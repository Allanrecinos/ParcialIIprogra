using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculadoraCapitalFinal
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

        private void btmcalc_Click(object sender, EventArgs e)
        {

            if (!double.TryParse(txtCapital.Text, out double montoInicial) ||
                !double.TryParse(txtInteres.Text, out double tasaInteres) ||
                !int.TryParse(txtPeriodo.Text, out int periodo))

            {
                return;
            }


            tasaInteres /= 100;


            double capitalFinal = montoInicial * Math.Pow(1 + tasaInteres, periodo);


            MessageBox.Show($"El capital final es: {capitalFinal:C}", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
