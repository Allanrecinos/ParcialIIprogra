using System;
using System.Windows.Forms;

namespace CalculadoraPrestamo
{
    public partial class FormCalculadoraPrestamo : Form
    {
        public FormCalculadoraPrestamo()
        {
            InitializeComponent();
        }

        private void btnCalcularCuota_Click(object sender, EventArgs e)
        {
            try
            {
                double montoPrestamo = Convert.ToDouble(txtMontoPrestamo.Text);
                double tasaInteres = Convert.ToDouble(txtTasaInteres.Text) / 100; // Convertir la tasa de interés a decimal
                int plazoPrestamo = Convert.ToInt32(txtPlazoPrestamo.Text);

                double i = tasaInteres / 12; // Tasa de interés mensual
                int n = plazoPrestamo * 12; // Cantidad de meses

                // Cálculo de la cuota mensual
                double cuota = montoPrestamo * (i / (1 - Math.Pow(1 + i, -n)));

                // Mostrar la cuota mensual en el formulario
                lblCuotaMensual.Text = cuota.ToString("C");

                // Cálculo del total de intereses a pagar
                double totalIntereses = cuota * n - montoPrestamo;

                // Mostrar el total de intereses a pagar en el formulario
                lblTotalIntereses.Text = totalIntereses.ToString("C");

                // Cálculo del total a pagar (capital + total de intereses)
                double totalPagar = montoPrestamo + totalIntereses;

                // Mostrar el total a pagar en el formulario
                lblTotalPagar.Text = totalPagar.ToString("C");
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor ingrese valores válidos para el monto del préstamo, la tasa de interés y el plazo del préstamo.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se produjo un error al calcular las cuotas del préstamo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
