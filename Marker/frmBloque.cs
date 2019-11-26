
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
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var b = ObtenerBloqueFormulario();


            if (modo == "AGREGAR")
            {
                Bloque.AgregarBloque(b);
            }
            else if (modo == "EDITAR")
            {

                if (this.lstBloque.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Favor seleccione una fila");
                }

                else
                {
                    int indice = lstBloque.SelectedIndex;
                    Bloque.EditarBloque(b, indice);
                    ActualizarListaBloque();
                }


            }
            LimpiarFormulario();
            ActualizarListaBloque();
            BloquearFormulario();
        }

        private Bloque ObtenerBloqueFormulario()
        {
            Bloque bloque = new Bloque();
            bloque.HoraEntrada =  dtpHoraEntrada.Value;
            bloque.HoraSalida = dtpHoraSalida.Value;
            bloque.FechaEntrada = dtpFechaEntrada.Value.Date;
            bloque.FechaSalida = dtpFechaEntrada.Value.Date;

            bloque.NombreUsuario = (Usuari)cbobNombre.SelectedItem;



            return bloque;
        }

        private void LimpiarFormulario()
        {
            cbobNombre.SelectedItem = null;
            dtpHoraEntrada.Value = DateTime.Now;
            dtpHoraSalida.Value = DateTime.Now;
            dtpFechaEntrada.Value = DateTime.Now;
            dtpFechaSalida.Value = DateTime.Now;

        }
        private void frmBloque_Load(object sender, EventArgs e)
        {

            ActualizarListaBloque();
            cboTipoHora.DataSource = Enum.GetValues(typeof(TipoHora));
            cbobNombre.DataSource = Usuari.ObtenerUsuarios();
            cbobNombre.SelectedItem = null;
            cboTipoHora.SelectedItem = null;
            BloquearFormulario();
        }



        private void BloquearFormulario()
        {
            cbobNombre.Enabled = false;
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
            dtpFechaSalida.Enabled = true;
            dtpFechaSalida.Enabled = true;
            
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
            lstBloque.DataSource = Bloque.ObtenerBloque();
        }

        


        private void btnEditar_Click(object sender, EventArgs e)
        {


            if (this.lstBloque.SelectedItems.Count == 0)
            {
                MessageBox.Show("Favor seleccione una fila");
            }
            else
            {
                modo = "EDITAR";
                DesbloquearFormulario();
                cbobNombre.Focus();
            }

        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            {
                if (lstBloque.SelectedItems.Count > 0)
                {
                    Bloque bloque = (Bloque)lstBloque.SelectedItem;
                    Bloque.listaBloque.Remove(bloque);
                    ActualizarListaBloque();
                    LimpiarFormulario();
                }
                else
                {
                    MessageBox.Show("Favor seleccionar de la lista para eliminar");
                }

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
            modo = "CANCELAR";
            LimpiarFormulario();
            BloquearFormulario();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            {
                if (modo == "AGREGAR")
                {
                    Bloque bloque = ObtenerBloqueFormulario();
                    Bloque.AgregarBloque(bloque);
                }
                else if (modo == "EDITAR")
                {
                    int index = lstBloque.SelectedIndex;

                    Bloque.listaBloque[index] = ObtenerBloqueFormulario();
                }

                ActualizarListaBloque();
                LimpiarFormulario();
                BloquearFormulario();
            }

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            modo = "AGREGAR";
            LimpiarFormulario();
            DesbloquearFormulario();
            cbobNombre.Focus();
        }

        private void lstBloque_SelectedIndexChanged(object sender, EventArgs e)
        {
            Bloque bloque = (Bloque)lstBloque.SelectedItem;

            if (bloque != null)
            {
                cbobNombre.SelectedItem = bloque.NombreUsuario;
                dtpHoraEntrada.Value = bloque.HoraEntrada;
                dtpHoraSalida.Value = bloque.HoraSalida;
                dtpFechaEntrada.Value = bloque.FechaEntrada;
                dtpFechaSalida.Value = bloque.FechaSalida;



            }


        }

        private void txtbCodigoHumano_TextChanged(object sender, EventArgs e)
        {
            

        }

        
     }
 }

