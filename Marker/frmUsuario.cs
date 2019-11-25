using ClasesMarcacion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            modo = "AGREGAR";
            LimpiarFormulario();
            DesbloquearFormulario();
            txtNroDocumento.Focus();
        }
        private void LimpiarFormulario()
        {

            txtId.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtNroDocumento.Text = "";
            cboDepartamento.SelectedItem = null;
            cboCargo.SelectedItem = null;
            cboTipoUsuario.SelectedItem = null;
            dtpFechaIngreso.Value = DateTime.Now;

        }
        private void frmUsuario_Load(object sender, EventArgs e)
        {

            ActualizarListaUser();
            cboTipoUsuario.DataSource = Enum.GetValues(typeof(TipoUsuario));
            cboDepartamento.DataSource = Departamento.ObtenerDepartamento();
            cboCargo.DataSource = Cargo.ObtenerCargos();
            cboCargo.SelectedItem = 1;
            cboDepartamento.SelectedItem = null;
            cboTipoUsuario.SelectedItem = null;
            BloquearFormulario();
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

            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
            btnLimpiar.Enabled = true;

            btnAgregar.Enabled = false;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
        }


        private void ActualizarListaUser()
        {
            lstUsuario.DataSource = null;
            lstUsuario.DataSource = Usuari.ObtenerUsuarios();
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
          // var u = ObtenerUserFormulario();

            {
                if (modo == "AGREGAR")
                {
                    Usuari user = ObtenerUserFormulario();
                    Usuari.AgregarUsuario(user);
                }
                else if (modo == "EDITAR")
                {
                    if (this.lstUsuario.SelectedItems.Count == 0)
                    {
                        MessageBox.Show("Favor seleccione una fila");
                    }

                    else
                    {
                        
                        int index = lstUsuario.SelectedIndex;
                        Usuari.listarUsuario[index] = ObtenerUserFormulario();
                        
                    }

                }

                LimpiarFormulario();
                ActualizarListaUser();
                BloquearFormulario();


            }
        }

        private Usuari ObtenerUserFormulario()
        {
            Usuari u = new Usuari();
  
            u.Nombre = txtNombre.Text;
            u.Apellido= txtApellido.Text;
            u.NroDocumento = txtNroDocumento.Text;
            u.FechaIngreso = dtpFechaIngreso.Value.Date;
           u.departamento = (Departamento)cboDepartamento.SelectedItem;
            u.cargo = (Cargo)cboCargo.SelectedItem;
            u.tipoUsuario = (TipoUsuario)cboTipoUsuario.SelectedItem;


            return u;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
                modo = "EDITAR";
                DesbloquearFormulario();
                txtNroDocumento.Focus();
            

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            {
                if (lstUsuario.SelectedItems.Count > 0)
                {
                    Usuari user = (Usuari)lstUsuario.SelectedItem;
                    Usuari.listarUsuario.Remove(user);
                    ActualizarListaUser();
                    LimpiarFormulario();
                }
                else
                {
                    MessageBox.Show("Favor seleccionar de la lista para eliminar");
                }

            }
        }



        private void lstUsuario_Click(object sender, EventArgs e)
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
            

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            modo = "CANCELAR";
            LimpiarFormulario();
            DesbloquearFormulario();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void lstUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            Usuari u = (Usuari)lstUsuario.SelectedItem;

            if (u != null)
            {
                txtNombre.Text = u.Nombre;
                txtApellido.Text = u.Apellido;
            
                txtNroDocumento.Text = u.NroDocumento;
                cboDepartamento.SelectedItem = u.departamento;
                cboCargo.SelectedItem = u.cargo;
                cboTipoUsuario.SelectedItem = u.tipoUsuario;
                dtpFechaIngreso.Value = u.FechaIngreso;

            }


        }

        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            modo = "I";
            LimpiarFormulario();
            DesbloquearFormulario();
            txtNroDocumento.Focus();
        }

        private void lstUsuario_Click_1(object sender, EventArgs e)
        {

        }

        private void btnEditar_Click_1(object sender, EventArgs e)
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

        private void btnEliminar_Click_1(object sender, EventArgs e)
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

        private void btnGuardar_Click_1(object sender, EventArgs e)
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

        private void btnLimpiar_Click_1(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
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

            usuario.Nombre = txtNombre.Text;
            usuario.Apellido = txtApellido.Text;
            usuario.NroDocumento = txtNroDocumento.Text;
            usuario.departamento = (Departamento)cboDepartamento.SelectedItem;
            usuario.cargo = (Cargo)cboCargo.SelectedItem;
            usuario.FechaIngreso = dtpFechaIngreso.Value.Date;
            usuario.tipoUsuario = (TipoUsuario)cboTipoUsuario.SelectedItem;

            return usuario;



        }

        private void lblTipoUsuario_Click(object sender, EventArgs e)
        {

        }
    }
}
