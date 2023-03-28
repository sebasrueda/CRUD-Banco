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
    internal class Cliente
    {
        public void mostrarClientes(DataGridView tablaClientes)
        {
            try
            {
                string query = "SELECT * FROM tblclientes;";
                ConexionSQL objetoConexion = new ConexionSQL();
                tablaClientes.DataSource = null;
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, objetoConexion.establecerConexion());
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                tablaClientes.DataSource = dt;
                objetoConexion.cerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se mostraron los datos de la base de datos. Error: " + ex.ToString());
            }
        }

        public void guardarCliente(TextBox cedula, TextBox nombre, TextBox apellido, TextBox telefono)
        {
            try
            {
                string query = "INSERT INTO tblclientes (cedula, nombre, apellido, telefono) VALUES('"
                    + cedula.Text + "', '" + nombre.Text + "', '" + apellido.Text + "', '" + telefono.Text + "');";
                ConexionSQL objetoConexion = new ConexionSQL();
                MySqlCommand myCommand = new MySqlCommand(query, objetoConexion.establecerConexion());
                MySqlDataReader reader = myCommand.ExecuteReader();
                MessageBox.Show("¡Cliente registrado exitosamente!");
                while (reader.Read()) { }
                objetoConexion.cerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo guardar el cliente. Error: " + ex.ToString());
            }
        }

        public void seleccionarCliente(DataGridView tablaClientes, TextBox cedula, TextBox nombre, TextBox apellido, TextBox telefono)
        {
            try
            {
                cedula.Text = tablaClientes.CurrentRow.Cells[0].Value.ToString();
                nombre.Text = tablaClientes.CurrentRow.Cells[1].Value.ToString();
                apellido.Text = tablaClientes.CurrentRow.Cells[2].Value.ToString();
                telefono.Text = tablaClientes.CurrentRow.Cells[3].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo seleccionar los registros de la base de datos. Error: " + ex.ToString());
            }
        }

        public void modificarCliente(TextBox cedula, TextBox nombre, TextBox apellido, TextBox telefono)
        {
            try
            {
                string query = "UPDATE tblclientes SET nombre='" + nombre.Text + "', apellido='" + apellido.Text +
                    "', telefono='"+telefono.Text+"' WHERE cedula='" + cedula.Text + "';";
                ConexionSQL objetoConexion = new ConexionSQL();
                MySqlCommand myCommand = new MySqlCommand(query, objetoConexion.establecerConexion());
                MySqlDataReader reader = myCommand.ExecuteReader();
                MessageBox.Show("¡Registros modificados exitosamente!");
                while (reader.Read()) { }
                objetoConexion.cerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo modificar los registros. Error: " + ex.ToString());
            }
        }
        public void eliminarCliente(TextBox cedula)
        {
            try
            {
                string query = "DELETE FROM tblclientes WHERE cedula='" + cedula.Text + "';";
                ConexionSQL objetoConexion = new ConexionSQL();
                MySqlCommand myCommand = new MySqlCommand(query, objetoConexion.establecerConexion());
                MySqlDataReader reader = myCommand.ExecuteReader();
                MessageBox.Show("¡Usuario eliminado exitosamente!");
                while (reader.Read()) { }
                objetoConexion.cerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo eliminar el usuario. Error: " + ex.ToString());
            }
        }

    }
}
