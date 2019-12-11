
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
    public partial class frmBloque : Form
    {

        string modo;

    
        public frmBloque()
        {
            InitializeComponent();
        }
       

        private Bloque ObtenerBloqueFormulario()
        {
            Bloque bloque = new Bloque();
            if (!string.IsNullOrEmpty(txtId.Text))
            {
                bloque.Id = Convert.ToInt32(txtId.Text);
            }
            bloque.NombreUsuario = (Usuari)cbobNombre.SelectedItem;
            bloque.Tipo_Hora = (TipoHora)cboTipoHora.SelectedItem;
            bloque.HoraEntrada = dtpHoraEntrada.Value;
            bloque.HoraSalida = dtpHoraSalida.Value;
            bloque.FechaEntrada = dtpFechaEntrada.Value;
            bloque.FechaSalida = dtpFechaSalida.Value;
            return bloque;
        }

        private void LimpiarFormulario()
        {
            txtId.Text = "";
            cbobNombre.SelectedItem = null;
            cboTipoHora.SelectedItem = null;
            dtpHoraEntrada.Value = DateTime.Now;
            dtpHoraSalida.Value = DateTime.Now;
            dtpFechaEntrada.Value = DateTime.Now;
            dtpFechaSalida.Value = DateTime.Now;

        }
        private void frmBloque_Load(object sender, EventArgs e)
        {
            
            cboTipoHora.DataSource = Enum.GetValues(typeof(TipoHora));
            cbobNombre.DataSource = Usuari.ObtenerUsuarios();
            cbobNombre.SelectedItem = null;
            LimpiarFormulario();
            BloquearFormulario();
            ActualizarListaBloque();

        }



        private void BloquearFormulario()
        {
            txtId.Enabled = false;
            cbobNombre.Enabled = false;
            cboTipoHora.Enabled = false;
            dtpHoraEntrada.Enabled = false;
            dtpHoraSalida.Enabled = false;
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
            btnLimpiar.Enabled = false;
            dtpFechaEntrada.Enabled = false;
            dtpFechaSalida.Enabled = false;
            cboTipoHora.Enabled = false;
             

            btnAgregar.Enabled = true;
            btnEditar.Enabled = true;
            btnEliminar.Enabled = true;
        }
        private void DesbloquearFormulario()
        {
            cbobNombre.Enabled = true;
            dtpHoraEntrada.Enabled = true;
            dtpHoraSalida.Enabled = true;
            dtpFechaEntrada.Enabled = true;
            dtpFechaSalida.Enabled = true;
            cboTipoHora.Enabled = true;
            
            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
            btnLimpiar.Enabled = true;

            btnAgregar.Enabled = false;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
        }

        private void ActualizarListaBloque()
        {
            lstBloque.DataSource = null;
            lstBloque.DataSource = Bloque.ObtenerBloques();
        }

        


        private void btnEditar_Click(object sender, EventArgs e)
        {


            Bloque bloque = (Bloque)lstBloque.SelectedItem;
            if (bloque != null)
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
            Bloque bloque = (Bloque)lstBloque.SelectedItem;
            if (bloque != null)
            {
                Bloque.EliminarBloque(bloque);
                ActualizarListaBloque();

                LimpiarFormulario();
            }
            else
            {
                MessageBox.Show("Favor seleccionar una fila de la lista");
            }
        }

        private void lstBloque_Click(object sender, EventArgs e)
        {
            Bloque bloque = (Bloque)lstBloque.SelectedItem;

            if (bloque != null)
            {
                cbobNombre.SelectedItem = bloque.NombreUsuario;
                




            }


        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

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

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            if (modo == "I")
            {
                Bloque bloque = ObtenerBloqueFormulario();
                Bloque.AgregarBloque(bloque);
            }
            else if (modo == "E")
            {
                int index = lstBloque.SelectedIndex;
                Bloque bloque= ObtenerBloqueFormulario();
                Bloque.EditarBloque(index, bloque);
            }

            ActualizarListaBloque();
            LimpiarFormulario();
            BloquearFormulario();

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            modo = "I";
            LimpiarFormulario();
            DesbloquearFormulario();
        }

        private void lstBloque_SelectedIndexChanged(object sender, EventArgs e)
        {
            

            //Bloque bloque = (Bloque)lstBloque.SelectedItem;

            //if (bloque != null)
            //{
            //    cbobNombre.SelectedItem = bloque.NombreUsuario;
            //    dtpHoraEntrada.Value = bloque.HoraEntrada;
            //    dtpHoraSalida.Value = bloque.HoraSalida;
            //    dtpFechaEntrada.Value = bloque.FechaEntrada;
            //    dtpFechaSalida.Value = bloque.FechaSalida;



            //}


        }

        private void txtbCodigoHumano_TextChanged(object sender, EventArgs e)
        {
            

        }

        private void lstBloque_Click_1(object sender, EventArgs e)
        {
           
            if (lstBloque.SelectedItem != null)
            {
                
                Bloque bloque = (Bloque)lstBloque.SelectedItem;
                txtId.Text = Convert.ToString(bloque.Id);
                cbobNombre.SelectedItem = bloque.NombreUsuario;
                cboTipoHora.SelectedItem = bloque.Tipo_Hora;
                dtpHoraEntrada.Value = bloque.HoraEntrada;
                dtpHoraSalida.Value = bloque.HoraSalida;
                dtpFechaEntrada.Value = bloque.FechaSalida;
                dtpFechaSalida.Value = bloque.FechaSalida;



            }
            
        }
    }
 }

