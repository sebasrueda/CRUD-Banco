using Banco.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Banco
{
    public partial class Interfaz : Form
    {
        public Interfaz()
        {
            InitializeComponent();
            
            //Mostrar todos los datos de la tabla de clientes
            Clases.Cliente objetoCliente = new Clases.Cliente();
            objetoCliente.mostrarClientes(dgvClientes);

            //Mostrar todos los datos de la tabla de cuentas
            Clases.Cuenta objetoCuenta = new Clases.Cuenta();
            objetoCuenta.mostrarCuentas(dgvCuentas);

            //Mostrar todos los datos de la tabla de auditorías
            Clases.Auditoria objetoAuditoria = new Clases.Auditoria();
            objetoAuditoria.mostrarAuditorias(dgvAuditorias);
        }

        //--------------------------------------------------------------------------------------------------------------------------------
        //Código de la sección para guardar y modificar información de los clientes
        private void btnGuardarCliente_Click(object sender, EventArgs e)
        {
            Clases.Cliente objetoCliente = new Clases.Cliente();
            objetoCliente.guardarCliente(txtCedulaCliente, txtNombre, txtApellido, txtTelefono);
            objetoCliente.mostrarClientes(dgvClientes);
        }

        private void dgvClientes_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Clases.Cliente objetoCliente = new Clases.Cliente();
            objetoCliente.seleccionarCliente(dgvClientes, txtCedulaCliente, txtNombre, txtApellido, txtTelefono);
        }

        private void btnModificarCliente_Click(object sender, EventArgs e)
        {
            Clases.Cliente objetoCliente = new Clases.Cliente();
            objetoCliente.modificarCliente(txtCedulaCliente, txtNombre, txtApellido, txtTelefono);
            objetoCliente.mostrarClientes(dgvClientes);
        }

        private void btnEliminarCliente_Click(object sender, EventArgs e)
        {
            Clases.Cliente objetoCliente = new Clases.Cliente();
            objetoCliente.eliminarCliente(txtCedulaCliente);
            objetoCliente.mostrarClientes(dgvClientes);
        }

        private void btnLimpiar1_Click(object sender, EventArgs e)
        {
            txtCedulaCliente.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtTelefono.Clear();
        }

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Clases.Cliente objetoCliente = new Clases.Cliente();
            objetoCliente.seleccionarCliente(dgvClientes, txtCedulaCliente, txtNombre, txtApellido, txtTelefono);
        }
        //Fin del código de la sección para guardar y modificar información de los clientes


        //--------------------------------------------------------------------------------------------------------------------------------
        //Código de la sección para crear y modificar cuentas
        private void btnCrearCuenta_Click(object sender, EventArgs e)
        {
            Clases.Cuenta objetoCuenta = new Clases.Cuenta();
            objetoCuenta.crearCuenta(txtCedulaCliente, cbTipoCuenta, txtSaldoInicial);
            objetoCuenta.mostrarCuentas(dgvCuentas);
        }

        private void btnModificarCuenta_Click(object sender, EventArgs e)
        {
            Clases.Cuenta objetoCuenta = new Clases.Cuenta();
            objetoCuenta.modificarCuenta(txtIdCuenta, cbTipoCuenta);
            objetoCuenta.mostrarCuentas(dgvCuentas);
        }

        private void btnLimpiar2_Click(object sender, EventArgs e)
        {
            txtSaldoInicial.Clear();
        }
        //Fin del código de la sección para crear y modificar cuentas
        
        
        //--------------------------------------------------------------------------------------------------------------------------------
        //Código para la sección de depositar y retirar dinero
        private void dgvCuentas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Clases.Cuenta objetoCuenta = new Clases.Cuenta();
            objetoCuenta.seleccionarCuenta(dgvCuentas, txtIdCuenta, txtCedulaCuenta, txtTipoCuenta, txtSaldoActual);
        }

        private void dgvCuentas_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Clases.Cuenta objetoCuenta = new Clases.Cuenta();
            objetoCuenta.seleccionarCuenta(dgvCuentas, txtIdCuenta, txtCedulaCuenta, txtTipoCuenta, txtSaldoActual);
        }

        private void btnDepositar_Click(object sender, EventArgs e)
        {
            Clases.Cuenta objetoCuenta = new Clases.Cuenta();
            objetoCuenta.depositarDinero(txtCedulaCuenta, txtMontoDeposito);
            objetoCuenta.mostrarCuentas(dgvCuentas);

            //Registrar auditoría del depósito de dinero a cuenta bancaria
            Clases.Auditoria objetoAuditoria = new Clases.Auditoria();
            objetoAuditoria.registrarAuditoriaDeposito(txtIdCuenta, txtMontoDeposito, txtSaldoActual);
            objetoAuditoria.mostrarAuditorias(dgvAuditorias);
        }

        private void btnRetirar_Click(object sender, EventArgs e)
        {
            Clases.Cuenta objetoCuenta = new Clases.Cuenta();
            objetoCuenta.retirarDinero(txtCedulaCuenta, txtMontoRetiro);
            objetoCuenta.mostrarCuentas(dgvCuentas);

            //Registrar auditoría del retiro de dinero desde cuenta bancaria
            Clases.Auditoria objetoAuditoria = new Clases.Auditoria();
            objetoAuditoria.registrarAuditoriaRetiro(txtIdCuenta, txtMontoRetiro, txtSaldoActual);
            objetoAuditoria.mostrarAuditorias(dgvAuditorias);
        }

        private void btnLimpiar3_Click(object sender, EventArgs e)
        {
            txtMontoDeposito.Clear();
        }

        private void btnLimpiar4_Click(object sender, EventArgs e)
        {
            txtMontoRetiro.Clear();
        }

        private void btnLimpiar5_Click(object sender, EventArgs e)
        {
            txtIdCuenta.Clear();
            txtCedulaCuenta.Clear();
            txtTipoCuenta.Clear();
            txtSaldoActual.Clear();
        }
        //Fin del código para la sección de depositar y retirar dinero


        //--------------------------------------------------------------------------------------------------------------------------------
        //Código de la sección para calcular créditos
        private void btnCalcular_Click(object sender, EventArgs e)
        {
            Clases.Credito objetoCredito = new Clases.Credito();
            objetoCredito.calcularCredito(txtMontoCredito, txtTipoCuenta, txtMensajeCredito);
        }

        private void btnLimpiar6_Click(object sender, EventArgs e)
        {
            txtMontoCredito.Clear();
            txtMensajeCredito.Clear();
        }
        //Fin del código de la sección para calcular créditos
    }
}
