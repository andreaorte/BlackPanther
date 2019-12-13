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
    public partial class frmMarcacion : Form
        
    {
        string modo;
        
        DateTime HoraEntrada;
        DateTime HoraSalida;
       
        public frmMarcacion()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
                      
                if (this.cboEmpleado.SelectedItem == null)
            {
                MessageBox.Show("Favor seleccione un Empleado");
            }
            
                else if (txtMarcacionEntrada.Text == "")
                {
                    modo = "entrada";
               
                    //var m = ObtenerFormularioMarcacion();
                Marcacion marcacion = ObtenerFormularioMarcacion();
                Marcacion.AgregarMarcacion(marcacion);
                MessageBox.Show("Entrada Marcada Exitosamente");
                    DesbloquearSalida();
                    ActualizarListaMarcacion();
                    BloquearEntrada();
                    DesbloquearSalida();
                }

          

        }

        private void DesbloquearSalida()
        {
            btnMarcarSalida.Enabled = true;
        }

        private Marcacion ObtenerFormularioMarcacion()
        {

            

            //Cargo cargo = new Cargo();
            //cargo.idCargo = Convert.ToInt16(txtIdCargo.Text); 
           

            if (modo == "entrada")
            {
                DateTime hora;
                hora = DateTime.Now;
                HoraEntrada = hora;
                txtMarcacionEntrada.Text = hora.ToShortTimeString();
            }
            else if (modo=="salida")
            {
                DateTime hora;
                hora = DateTime.Now;
                HoraSalida = hora;
                txtMarcacionSalida.Text = hora.ToShortTimeString();
                ObtenerHorasTrabajadas();

                

            }
            Marcacion m = new Marcacion();

            if (!string.IsNullOrEmpty(txtId.Text))
            {
                m.Id = Convert.ToInt32(txtId.Text);
            }
            m.empleado = (Usuari)cboEmpleado.SelectedItem;
            m.MarcacionEntrada = txtMarcacionEntrada.Text;
            m.MarcacionSalida = txtMarcacionSalida.Text;
            m.HorasTrabajadas = txtHorasTrabajadas.Text;
            m.FechaMarcacion = dtpFechaMarcacion.Value.Date;
           

            return m;
        }

        private void BloquearEntrada()
        { 
            btnMarcarEntrada.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
                    }

        private void btnHoraActual_Click(object sender, EventArgs e)
        {
          
           
           lblHoraActual.Text = DateTime.Now.ToShortTimeString();
        }

        private void frmMarcacion_Load(object sender, EventArgs e)
        {
            lblHoraActual.Text = DateTime.Now.ToLongTimeString();
            cboEmpleado.DataSource = Usuari.ObtenerUsuarios();
            //cboEmpleado.DataSource = Usuari.ObtenerUsuario();
            cboEmpleado.SelectedItem = null;           
            txtMarcacionEntrada.Enabled = false;
            txtMarcacionSalida.Enabled = false;
            txtHorasTrabajadas.Enabled = false;
            txtId.Enabled = false;
            dtpFechaMarcacion.Enabled = false;
            ActualizarListaMarcacion();


            //cboDepartamento.DataSource = Departamento.ObtenerDepartamento();
            //cboDepartamento.SelectedItem = null;
            //cboCargo.DataSource = Cargo.ObtenerCargo();
            //cboDepartamento.SelectedItem = null;
            //LimpiarFormulario();
            //BloquearFormulario();
            //ActualizarListaUsuario();

        }

        private void ActualizarListaMarcacion()
        {

            lstMarcacion.DataSource = null;
            lstMarcacion.DataSource = Marcacion.ObtenerMarcaciones();
        }

        private void lblMarcacionEntrada_Click(object sender, EventArgs e)
        {

        }

        private void lstMarcacion_Click(object sender, EventArgs e)
        {
            Marcacion m = (Marcacion)lstMarcacion.SelectedItem;
            
            if (m != null)
            {
                cboEmpleado.SelectedItem = m.empleado;
                txtMarcacionEntrada.Text = m.MarcacionEntrada;
                txtMarcacionSalida.Text = m.MarcacionSalida;
                txtHorasTrabajadas.Text = m.HorasTrabajadas;
                txtId.Text = Convert.ToString(m.Id);
                if ( txtMarcacionEntrada.Text != "" && txtMarcacionSalida.Text != "" )
                {
                    BloquearEntrada();
                    BloquearSalida();
             

                }
                else if ( txtMarcacionSalida.Text =="" && txtMarcacionEntrada.Text != "")
                {
                    DesbloquearSalida();
                    BloquearEntrada();                 
                }
                
             
            }


        }

        private void btnMarcarSalida_Click(object sender, EventArgs e)
        {


            //modo = "salida";

            Marcacion m = ObtenerFormularioMarcacion();
            modo = "salida";
            if (m != null)
            {
                if (this.lstMarcacion.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Favor seleccione una fila");
                }
                else
                {
                    if (txtMarcacionSalida.Text != "")
                    {
                        btnMarcarSalida.Enabled = false;

                    }
                    else if (txtMarcacionSalida.Text == "")

                    {


                        Marcacion marcacion = ObtenerFormularioMarcacion();
                        int index = lstMarcacion.SelectedIndex;
                        Marcacion.ActualizarMarcacion(index, marcacion);
                        MessageBox.Show("Salida Marcada Exitosamente");
                      
                        ActualizarListaMarcacion();
                        BloquearSalida();
                        //int index = lstMarcacion.SelectedIndex;
                        //Marcacion.ActualizarMarcacion(index, m);
                        //ActualizarListaMarcacion();
                        //MessageBox.Show("Salida Marcada Exitosamente");
                        //BloquearSalida();
                        //LimpiarFormulario();
                        //txtHorasTrabajadas.Text = "";

                    }
                }

            }
     



        }


        private void BloquearSalida()
        {
            btnMarcarSalida.Enabled = false;
        }

        private void lstMarcacion_SelectedIndexChanged(object sender, EventArgs e)
        {
          
                
            }

        private void cboEmpleado_SelectedIndexChanged(object sender, EventArgs e)
        {

            txtHorasTrabajadas.Text = "";
            txtMarcacionEntrada.Text = "";
            txtMarcacionSalida.Text = "";
            dtpFechaMarcacion.Value = DateTime.Now;
            btnMarcarEntrada.Enabled = true;
            btnMarcarSalida.Enabled = false;
            txtId.Text = "";

        }

        private void ObtenerHorasTrabajadas()
        {
            double aux;
            double hora;
            double minu;
            hora = Convert.ToDouble(HoraSalida.Subtract(HoraEntrada).Hours);
            minu = Convert.ToDouble(HoraSalida.Subtract(HoraEntrada).Minutes);
            aux = (hora + (minu / 60));


            txtHorasTrabajadas.Text = aux.ToString();

            //txtHorasTrabajadas.Text = HoraSalida.Subtract(HoraEntrada).Hours.ToString();

        }
        private void LimpiarFormulario()
        {
            txtMarcacionEntrada.Text = "";
            txtMarcacionSalida.Text = "";
            txtHorasTrabajadas.Text = "";
            cboEmpleado.SelectedItem = null;
            btnMarcarEntrada.Enabled = true;
        }

        private void txtMarcacionSalida_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtHorasTrabajadas_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void lblHoraActual_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            lblHoraActual.Text = DateTime.Now.ToLongTimeString();
        }
    }
}
