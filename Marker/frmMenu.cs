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
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void bloqueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBloque frmblo = new frmBloque();
            frmblo.Show();
        }

        private void cargoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCargo frmcar = new frmCargo();
            frmcar.Show();
        }

        private void departamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDepartamento frmdep = new frmDepartamento();
            frmdep.Show();
        }

        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsuario frmusu = new frmUsuario();
            frmusu.Show();
        }

        private void administradorToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void marcaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMarcacion frmMarca = new frmMarcacion();
            frmMarca.Show();
        }

        private void salirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void marcarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMarcacion frmMar = new frmMarcacion();
            frmMar.Show();
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {

        }

        private void crearUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CrearUsuario crearUsu = new CrearUsuario();
            crearUsu.Show();
        }
    }
}
