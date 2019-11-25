using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClasesMarcacion;

namespace Marker
{
    public partial class frmDepartamento : Form
    {
        string modo;
        public frmDepartamento()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            modo = "AGREGAR";
            LimpiarFormulario();
            DesbloquearFormularios();
            txtIdDepartamento.Focus();
        }

        private void DesbloquearFormularios()
        {
            txtIdDepartamento.Enabled = false;
            txtNombreDepartamento.Enabled = true;
            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
            btnLimpiar.Enabled = true;

            btnAgregar.Enabled = false;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
        }

        private void LimpiarFormulario()
        {
            txtIdDepartamento.Text = "";
            txtNombreDepartamento.Text = "";

        }

        private void frmDepartamento_Load(object sender, EventArgs e)
        {
            ActualizarListaDepartamentos();

            BloquearFormulario();
        }

        private void BloquearFormulario()
        {
            txtIdDepartamento.Enabled = false;
            txtNombreDepartamento.Enabled = false;
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
            btnLimpiar.Enabled = false;

            btnAgregar.Enabled = true;
            btnEditar.Enabled = true;
            btnEliminar.Enabled = true;
        }

        private void ActualizarListaDepartamentos()
        {
            lstDepartamento.DataSource = null;
            lstDepartamento.DataSource = Departamento.ObtenerDepartamento();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var d = ObtenerDatosFormulario();


            if (modo == "AGREGAR")
            {
                Departamento.AgregarDepartamento(d);
            }
            else if (modo == "EDITAR")
            {

                if (this.lstDepartamento.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Favor seleccione una fila");
                }

                else
                {
                    int indice = lstDepartamento.SelectedIndex;
                    Departamento.EditarDepartamento(d, indice);
                    ActualizarListaDepartamentos();
                }


            }

            LimpiarFormulario();
            ActualizarListaDepartamentos();
            BloquearFormulario();


        }

        private Departamento ObtenerDatosFormulario()
        {
            Departamento departamento = new Departamento();

            if (!string.IsNullOrEmpty(txtIdDepartamento.Text))
            {
               departamento.Id = Convert.ToInt32(txtIdDepartamento.Text);
            }

            departamento.descripcion = txtNombreDepartamento.Text;
            return departamento;

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

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (this.lstDepartamento.SelectedItems.Count == 0)
            {
                MessageBox.Show("Favor seleccione una fila");
            }
            else
            {
                modo = "EDITAR";
                DesbloquearFormularios();
                txtIdDepartamento.Focus();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (this.lstDepartamento.SelectedItems.Count == 0)
            {
                MessageBox.Show("Favor seleccione una fila");
            }
            else
            {
                Departamento d = (Departamento)lstDepartamento.SelectedItem;
                Departamento.EliminarDepartamento(d);
                ActualizarListaDepartamentos();
                LimpiarFormulario();
            }
        }

        private void lstDepartamento_Click(object sender, EventArgs e)
        {
            Departamento d = (Departamento)lstDepartamento.SelectedItem;
            if (d != null)
            {
                txtIdDepartamento.Text = Convert.ToString(d.Id);
                txtNombreDepartamento.Text = d.descripcion;

            }
        }

        private void frmDepartamento_Load_1(object sender, EventArgs e)
        {
            ActualizarListaDepartamentos();
            lstDepartamento.DataSource = Departamento.ObtenerDepartamento();

            BloquearFormulario();

        }

        private void lstDepartamento_Click_1(object sender, EventArgs e)
        {
            Departamento d = (Departamento)lstDepartamento.SelectedItem;
            if (d != null)
            {
                txtIdDepartamento.Text = Convert.ToString(d.Id); 
                txtNombreDepartamento.Text = d.descripcion;

            }
        }

        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            modo = "AGREGAR";
            LimpiarFormulario();
            DesbloquearFormularios();
            txtIdDepartamento.Focus();
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            var d = ObtenerDatosFormulario();


            if (modo == "AGREGAR")
            {
                Departamento.AgregarDepartamento(d);
            }
            else if (modo == "EDITAR")
            {

                if (this.lstDepartamento.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Favor seleccione una fila");
                }

                else
                {
                    int indice = lstDepartamento.SelectedIndex;
                    Departamento.EditarDepartamento(d, indice);
                    ActualizarListaDepartamentos();
                }


            }
            LimpiarFormulario();
            BloquearFormulario();           
            ActualizarListaDepartamentos();
            
        }

        private void btnEditar_Click_1(object sender, EventArgs e)
        {
            if (this.lstDepartamento.SelectedItems.Count == 0)
            {
                MessageBox.Show("Favor seleccione una fila");
            }
            else
            {
                modo = "EDITAR";
                DesbloquearFormularios();
                txtIdDepartamento.Focus();
            }
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {

            if (this.lstDepartamento.SelectedItems.Count == 0)
            {
                MessageBox.Show("Favor seleccione una fila");
            }
            else
            {
                Departamento d = (Departamento)lstDepartamento.SelectedItem;
                Departamento.EliminarDepartamento(d);
                ActualizarListaDepartamentos();
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

        private void lstDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            Departamento d = (Departamento)lstDepartamento.SelectedItem;

            if (d != null)
            {
                txtIdDepartamento.Text = Convert.ToString(d.Id);
                txtNombreDepartamento.Text = d.descripcion;

            }

        }
    }
}
