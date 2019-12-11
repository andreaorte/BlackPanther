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
    public partial class CrearUsuario : Form
    {
        public CrearUsuario()
        {
            InitializeComponent();
        }

        private void CrearUsuario_Load(object sender, EventArgs e)
        {

        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            Usuario.CrearUsuario(txtUsuario.Text, txtPassword.Text);
            MessageBox.Show("Usuario creado exitosamente");
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            txtUsuario.Text = "";
            txtPassword.Text = "";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
