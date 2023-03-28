using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Banco.Clases
{
    internal class Credito
    {
        public void calcularCredito(TextBox credito, TextBox tipoCuenta, TextBox mensajeCredito)
        {
            double cantidadCredito = int.Parse(credito.Text);
            string cuenta = tipoCuenta.Text;
            double interes;
            double totalPagar;

            if (cantidadCredito >= 1000000)
            {
                if (cuenta == "Regular")
                {
                    interes = cantidadCredito * 0.01;
                    totalPagar = cantidadCredito + interes;
                    mensajeCredito.Text = "El interés de tu crédito es del 1% y su total es de "
                        + interes + " pesos.\n El total de la deuda sería: " + totalPagar + " pesos.";
                }
                else if (cuenta == "Dorada")
                {
                    interes = cantidadCredito * 0.1;
                    totalPagar = cantidadCredito + interes;
                    mensajeCredito.Text = "El interés de tu crédito es del 10% y su total es de " 
                        + interes + " pesos.\n El total de la deuda sería: " + totalPagar + " pesos.";
                }
            }
            else
            {
                MessageBox.Show("La cantidad para el crédito debe ser igual o mayor a un millon de pesos.");
            }
        }
    }
}
