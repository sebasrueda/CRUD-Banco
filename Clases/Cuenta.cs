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
    internal class Cuenta
    {
        public void mostrarCuentas(DataGridView tablaCuentas)
        {
            try
            {
                string query = "SELECT * FROM cuentas;";
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

        public void crearCuenta(TextBox cedula, ComboBox tipoCuenta, TextBox saldo)
        {
            try
            {
                string query = "INSERT INTO cuentas (cedula, tipo_cuenta, saldo) VALUES('"
                    + cedula.Text + "', '" + tipoCuenta.Text + "', '" + saldo.Text + "');";
                ConexionSQL objetoConexion = new ConexionSQL();
                MySqlCommand myCommand = new MySqlCommand(query, objetoConexion.establecerConexion());
                MySqlDataReader reader = myCommand.ExecuteReader();
                MessageBox.Show("¡Cuenta creada exitosamente!");
                while (reader.Read()) { }
                objetoConexion.cerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo crear la cuenta. Error: " + ex.ToString());
            }
        }

        public void seleccionarCuenta(DataGridView tablaCuentas, TextBox idCuenta, TextBox cedula, TextBox tipoCuenta, TextBox saldo)
        {
            try
            {
                idCuenta.Text = tablaCuentas.CurrentRow.Cells[0].Value.ToString();
                cedula.Text = tablaCuentas.CurrentRow.Cells[1].Value.ToString();
                tipoCuenta.Text = tablaCuentas.CurrentRow.Cells[2].Value.ToString();
                saldo.Text = tablaCuentas.CurrentRow.Cells[3].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo seleccionar los registros de la base de datos. Error: " + ex.ToString());
            }
        }

        public void modificarCuenta(TextBox idCuenta, ComboBox tipoCuenta)
        {
            try
            {
                string query = "UPDATE cuentas SET tipo_cuenta='"+tipoCuenta.Text+"' WHERE idcuenta='"+idCuenta.Text+"';";
                ConexionSQL objetoConexion = new ConexionSQL();
                MySqlCommand myCommand = new MySqlCommand(query, objetoConexion.establecerConexion());
                MySqlDataReader reader = myCommand.ExecuteReader();
                MessageBox.Show("¡Tipo de cuenta modificado exitosamente!");
                while (reader.Read()) { }
                objetoConexion.cerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo modificar el tipo de cuenta. Error: " + ex.ToString());
            }
        }

        public void depositarDinero(TextBox cedula, TextBox deposito)
        {
            try
            {
                string query = "UPDATE cuentas SET saldo=saldo+'" + deposito.Text + "' WHERE cedula='" + cedula.Text + "';";
                ConexionSQL objetoConexion = new ConexionSQL();
                MySqlCommand myCommand = new MySqlCommand(query, objetoConexion.establecerConexion());
                MySqlDataReader reader = myCommand.ExecuteReader();
                MessageBox.Show("¡Depósito realizado exitosamente!");
                while (reader.Read()) { }
                objetoConexion.cerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo completar el depósito. Error: " + ex.ToString());
            }
        }

        public void retirarDinero(TextBox cedula, TextBox retiro)
        {
            try
            {
                string query = "UPDATE cuentas SET saldo=saldo-'" + retiro.Text + "'WHERE cedula='" + cedula.Text + "';";
                ConexionSQL objetoConexion = new ConexionSQL();
                MySqlCommand myCommand = new MySqlCommand(query, objetoConexion.establecerConexion());
                MySqlDataReader reader = myCommand.ExecuteReader();
                MessageBox.Show("¡Retiro realizado exitosamente!");
                while (reader.Read()) { }
                objetoConexion.cerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo completar el retiro. Error: " + ex.ToString());
            }
        }
    }
}
