using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaCodigo;
using CapaEntidades;
using CapaDao;
namespace SISTEMA_VIDEOS
{
    public partial class frmActores : Form
    {
        public frmActores()
        {
            InitializeComponent();
        }
        clsActores oAct = new clsActores();
        clsActoresDao oactDao = new clsActoresDao();
        private void inicio()
        {
            txtNombre.Clear();
            cmbPais.SelectedIndex = -1;
            cmbSex.SelectedIndex = -1;
            dtpFecNac.Text = "";
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            oAct.nombre = txtNombre.Text;
            oAct.pais = cmbPais.Text;
            oAct.sexo = cmbSex.Text;
            oAct.fecnac = dtpFecNac.Value;
            oactDao.InsertarActores(oAct);
            inicio();
        }

        private void frmActores_Load(object sender, EventArgs e)
        {
            llenarActores();
        }
        private void llenarActores()
        {
            dgvMostrarActores.DataSource = oactDao.llenarActores();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            oAct.codAcotr =Convert.ToInt32( dgvMostrarActores.CurrentRow.Cells[0].Value.ToString());
            oactDao.EliminarActores(oAct);
            inicio();
            llenarActores();
        }

        private void dgvMostrarActores_DoubleClick(object sender, EventArgs e)
        {

        }
    }
}
