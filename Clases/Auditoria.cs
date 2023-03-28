using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Banco.Clases
{
    internal class Auditoria
    {
        public void mostrarAuditorias(DataGridView tablaCuentas)
        {
            try
            {
                string query = "SELECT * FROM auditoria;";
                ConexionSQL objetoConexion = new ConexionSQL();
                tablaCuentas.DataSource = null;
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, objetoConexion.establecerConexion());
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                tablaCuentas.DataSource = dt;
                objetoConexion.cerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo mostrar la tabla de cuentas. Error: " + ex.ToString());
            }
        }

        public void registrarAuditoriaDeposito(TextBox idCuenta, TextBox deposito, TextBox saldoActual)
        {
            try
            {
                int saldoAnterior = int.Parse(saldoActual.Text);
                int saldoDeposito = int.Parse(deposito.Text);
                int nuevoSaldo = saldoAnterior + saldoDeposito;
                string query = "INSERT INTO auditoria (id_cuenta, saldo_transaccion, saldo_anterior, nuevo_saldo, tipo_transaccion, fecha) VALUES ('"
                    + idCuenta.Text + "', '" + saldoDeposito + "', '" + saldoAnterior + "', '" + nuevoSaldo + "', 'Depósito', current_timestamp())";
                ConexionSQL objetoConexion = new ConexionSQL();
                MySqlCommand myCommand = new MySqlCommand(query, objetoConexion.establecerConexion());
                MySqlDataReader reader = myCommand.ExecuteReader();
                MessageBox.Show("¡Auditoría registrada exitosamente!");
                while (reader.Read()) { }
                objetoConexion.cerrarConexion();
            }
            catch (Exception ex) 
            {
                MessageBox.Show("No se pudo registrar la auditoría. Error: " + ex.ToString());
            }
        }

        public void registrarAuditoriaRetiro(TextBox idCuenta, TextBox retiro, TextBox saldoActual)
        {
            try
            {
                int saldoAnterior = int.Parse(saldoActual.Text);
                int saldoRetiro = int.Parse(retiro.Text);
                int nuevoSaldo = saldoAnterior - saldoRetiro;
                string query = "INSERT INTO auditoria (id_cuenta, saldo_transaccion, saldo_anterior, nuevo_saldo, tipo_transaccion, fecha) VALUES ('"
                    + idCuenta.Text + "', '" + saldoRetiro + "', '" + saldoAnterior + "', '" + nuevoSaldo + "', 'Retiro', current_timestamp())";
                ConexionSQL objetoConexion = new ConexionSQL();
                MySqlCommand myCommand = new MySqlCommand(query, objetoConexion.establecerConexion());
                MySqlDataReader reader = myCommand.ExecuteReader();
                MessageBox.Show("¡Auditoría registrada exitosamente!");
                while (reader.Read()) { }
                objetoConexion.cerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo registrar la auditoría. Error: " + ex.ToString());
            }
        }
    }
}
