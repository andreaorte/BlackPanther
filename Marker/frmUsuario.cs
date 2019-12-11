using ClasesMarcacion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Marker
{
    public partial class frmUsuario : Form
    {

        string modo;
        public frmUsuario()
        {
            InitializeComponent();
        }

        private void lblINombre_Click(object sender, EventArgs e)
        {

        }

        private void cboDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            
        }
        private void LimpiarFormulario()
        {

            txtId.Text = "";
            txtNroDocumento.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";            
            cboDepartamento.SelectedItem = null;
            cboCargo.SelectedItem = null;
            cboTipoUsuario.SelectedItem = null;
            dtpFechaIngreso.Value = DateTime.Now;
            txtUsuario.Text = "";
            txtPassword.Text = "";
            txtNroDocumento.Text = "";
            txtCorreo.Text = "";

        }
        private void frmUsuario_Load(object sender, EventArgs e)
        {

            cboTipoUsuario.DataSource = Enum.GetValues(typeof(TipoUsuario));
            cboDepartamento.DataSource = Departamento.ObtenerDepartamento();
            cboDepartamento.SelectedItem = null;
            cboCargo.DataSource = Cargo.ObtenerCargo();
            cboDepartamento.SelectedItem = null;
            LimpiarFormulario();
            BloquearFormulario();
            ActualizarListaUsuario();

        }

        

        private void BloquearFormulario()
        {
            txtNombre.Enabled = false;
            txtApellido.Enabled = false;
            txtNroDocumento.Enabled = false;
            cboCargo.Enabled = false;
            cboDepartamento.Enabled = false;
            cboTipoUsuario.Enabled = false;
            dtpFechaIngreso.Enabled = false;
            txtUsuario.Enabled = false;
            txtPassword.Enabled = false;
            txtCorreo.Enabled = false;

            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
            btnLimpiar.Enabled = false;

            btnAgregar.Enabled = true;
            btnEditar.Enabled = true;
            btnEliminar.Enabled = true;
        }



        private void DesbloquearFormulario()
        {
            txtNombre.Enabled = true;
            txtApellido.Enabled = true;
     
            txtNroDocumento.Enabled = true;
            cboCargo.Enabled = true;
            cboDepartamento.Enabled = true;
            cboTipoUsuario.Enabled = true;
            dtpFechaIngreso.Enabled = true;
            txtUsuario.Enabled = true;
            txtPassword.Enabled = true;
            txtCorreo.Enabled = true;
            

            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
            btnLimpiar.Enabled = true;

            btnAgregar.Enabled = false;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
        }


      



        


        

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void lstUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
         


        }

        

      



     

        

        private void lblTipoUsuario_Click(object sender, EventArgs e)
        {

        }

        private void lstUsuario_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void lstUsuario_Click(object sender, EventArgs e)
        {
            if (lstUsuario.SelectedItem != null)
            {
               
                Usuari usuario = (Usuari)lstUsuario.SelectedItem;
                txtId.Text = Convert.ToString(usuario.Id);
                txtNroDocumento.Text = usuario.NroDocumento;
                txtNombre.Text = usuario.Nombre;
                txtApellido.Text = usuario.Apellido;
                cboDepartamento.SelectedItem = usuario.departamento;
                cboCargo.SelectedItem = usuario.cargo;
                cboTipoUsuario.SelectedItem = usuario.tipoUsuario;
                dtpFechaIngreso.Value = usuario.FechaIngreso;
                txtUsuario.Text = usuario.Usuario;
                txtPassword.Text = usuario.Password;
                txtCorreo.Text = usuario.Correo;
                


            }
        }

        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            modo = "I";
            LimpiarFormulario();
            DesbloquearFormulario();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (modo == "I")
            {
                Usuari usuario = ObtenerUsuarioFormulario();
                Usuari.AgregarUsuario(usuario);
            }
            else if (modo == "E")
            {
                int index = lstUsuario.SelectedIndex;
                Usuari usuario = ObtenerUsuarioFormulario();
                Usuari.EditarUsuario(index, usuario);
            }

            ActualizarListaUsuario();
            LimpiarFormulario();
            BloquearFormulario();
        }

        private void ActualizarListaUsuario()
        {
            lstUsuario.DataSource = null;
            lstUsuario.DataSource = Usuari.ObtenerUsuarios();
        }

        private Usuari ObtenerUsuarioFormulario()
        {
            Usuari usuario = new Usuari();
            if (!string.IsNullOrEmpty(txtId.Text))
            {
                usuario.Id = Convert.ToInt32(txtId.Text);
            }
            usuario.NroDocumento = txtNroDocumento.Text;
            usuario.Nombre = txtNombre.Text;
            usuario.Apellido = txtApellido.Text;
            usuario.departamento = (Departamento)cboDepartamento.SelectedItem;
            usuario.cargo = (Cargo)cboCargo.SelectedItem;
            usuario.tipoUsuario = (TipoUsuario)cboTipoUsuario.SelectedItem;
            usuario.FechaIngreso = dtpFechaIngreso.Value.Date;
            usuario.Usuario = txtUsuario.Text;
            usuario.Password = txtPassword.Text;
            usuario.Correo = txtCorreo.Text;


            return usuario;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
            BloquearFormulario();
        }

        private void btnLimpiar_Click_1(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Usuari usuario = (Usuari)lstUsuario.SelectedItem;
            if (usuario != null)
            {
                modo = "E";
                DesbloquearFormulario();
            }
            else
            {
                MessageBox.Show("Ojo, Selecciona un Item");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Usuari usuario = (Usuari)lstUsuario.SelectedItem;
            if (usuario != null)
            {
                Usuari.EliminarUsuario(usuario);
                ActualizarListaUsuario();
               
                LimpiarFormulario();
            }
            else
            {
                MessageBox.Show("Favor seleccionar una fila de la lista");
            }
        }
    }
}
