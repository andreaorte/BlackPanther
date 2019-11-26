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
    public partial class frmCargo : Form
    {
        string modo;
        public frmCargo()
        {
            InitializeComponent();
        }
        private void frmCargo_Load(object sender, EventArgs e)
        {
            ActualizarListaCargos();

            BloquearFormulario();
        }
        private void ActualizarListaCargos()
        {
            lstCargo.DataSource = null;
            lstCargo.DataSource = Cargo.ObtenerCargo();

        }

        private void BloquearFormulario()
        {
            txtIdCargo.Enabled = false;
            txtNombreCargo.Enabled = false;
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
            btnLimpiar.Enabled = false;

            btnAgregar.Enabled = true;
            btnEliminar.Enabled = true;
            btnEditar.Enabled = true;


        }



        private void btnAgregar_Click(object sender, EventArgs e)
        {
            modo = "AGREGAR";
            LimpiarFormulario();
            DesbloquearFormularios();
            txtNombreCargo.Focus();
        }

        private void DesbloquearFormularios()
        {
            txtIdCargo.Enabled = false;
            txtNombreCargo.Enabled = true;
            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
            btnLimpiar.Enabled = true;

            btnAgregar.Enabled = false;
            btnEliminar.Enabled = false;
            btnEditar.Enabled = false;
        }

        private void LimpiarFormulario()
        {
            txtIdCargo.Text = "";
            txtNombreCargo.Text = "";
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (this.lstCargo.SelectedItems.Count == 0)
            {
                MessageBox.Show("Favor seleccione una fila");
            }
            else
            {
                Cargo c = (Cargo)lstCargo.SelectedItem;
                Cargo.EliminarCargo(c);
                ActualizarListaCargos();
                LimpiarFormulario();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (this.lstCargo.SelectedItems.Count == 0)
            {
                MessageBox.Show("Favor seleccione una fila");
            }
            else
            {
                modo = "EDITAR";
                DesbloquearFormularios();
                txtNombreCargo.Focus();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var c = ObtenerDatosFormulario();


            if (modo == "AGREGAR")
            {
                Cargo.AgregarCargo(c);
            }
            else if (modo == "EDITAR")
            {

                if (this.lstCargo.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Favor seleccione una fila");
                }

                else
                {
                    int indice = lstCargo.SelectedIndex;
                    Cargo.EditarCargo(c, indice);
                    ActualizarListaCargos();
                }


            }

            LimpiarFormulario();
            ActualizarListaCargos();
            BloquearFormulario();


        }

        private Cargo ObtenerDatosFormulario()
        {

            Cargo cargo  = new Cargo();

            if (!string.IsNullOrEmpty(txtIdCargo.Text))
            {
                cargo.idCargo = Convert.ToInt32(txtIdCargo.Text);
            }

            //Cargo cargo = new Cargo();
            //cargo.idCargo = Convert.ToInt16(txtIdCargo.Text); 
            cargo.descripcion = txtNombreCargo.Text;
            return cargo;

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
            BloquearFormulario();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void lstCargo_Click(object sender, EventArgs e)
        {
            Cargo c = (Cargo)lstCargo.SelectedItem;
            if (c != null)
            {
                txtIdCargo.Text = Convert.ToString(c.idCargo);
                txtNombreCargo.Text = c.descripcion;

            }
        }

        private void frmCargo_Load_1(object sender, EventArgs e)
        {
            ActualizarListaCargos();
            lstCargo.DataSource = Cargo.ObtenerCargo();

            //lstCargo.DataSource = Cargo.ObtenerCargo();
            BloquearFormulario();
        }

        private void lstCargo_Click_1(object sender, EventArgs e)
        {
            Cargo c = (Cargo)lstCargo.SelectedItem;
            if (c != null)
            {
                txtIdCargo.Text = Convert.ToString(c.idCargo); 
                txtNombreCargo.Text = c.descripcion;

            }
        }

        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            

            //Cargo carg = new Cargo();;
            //carg.descripcion = txtNombreCargo.Text;


            //Cargo.AgregarCargo(carg);

            modo = "AGREGAR";
            LimpiarFormulario();
            DesbloquearFormularios();
            txtNombreCargo.Focus();
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            var c = ObtenerDatosFormulario();


            if (modo == "AGREGAR")
            {
                Cargo.AgregarCargo(c);
            }
            else if (modo == "EDITAR")
            {

                if (this.lstCargo.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Favor seleccione una fila");
                }

                else
                {
                    int indice = lstCargo.SelectedIndex;
                    Cargo.EditarCargo(c, indice);
                    ActualizarListaCargos();
                }


            }

            LimpiarFormulario();
            BloquearFormulario();
            ActualizarListaCargos();

        }

        private void btnEditar_Click_1(object sender, EventArgs e)
        {
            if (this.lstCargo.SelectedItems.Count == 0)
            {
                MessageBox.Show("Favor seleccione una fila");
            }
            else
            {
                modo = "EDITAR";
                DesbloquearFormularios();
                txtIdCargo.Focus();
            }
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            if (this.lstCargo.SelectedItems.Count == 0)
            {
                MessageBox.Show("Favor seleccione una fila");
            }
            else
            {
                Cargo c = (Cargo)lstCargo.SelectedItem;
                Cargo.EliminarCargo(c);
                ActualizarListaCargos();
                LimpiarFormulario();
            }

        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            LimpiarFormulario();
            BloquearFormulario();
        }

        private void btnLimpiar_Click_1(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void lstCargo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cargo c = (Cargo)lstCargo.SelectedItem;

            if (c != null)
            {
                txtIdCargo.Text = Convert.ToString(c.idCargo);
                txtNombreCargo.Text = c.descripcion;

            }



        }
    }
}

