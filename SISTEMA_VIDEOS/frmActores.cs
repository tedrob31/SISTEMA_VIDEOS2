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
            cmbPais.Text = "";
            cmbSex.Text = "";
            dtpFecNac.Text = "";
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            llenandoActor();
            oactDao.InsertarActores(oAct);
            inicio();
            llenarActores();
        }
        private void llenandoActor()
        {
            
            oAct.nombre = txtNombre.Text;
            oAct.pais = cmbPais.Text;
            oAct.sexo = cmbSex.Text;
            oAct.fecnac = dtpFecNac.Value;
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
            txtNombre.Text = dgvMostrarActores.CurrentRow.Cells[1].Value.ToString();
            cmbPais.Text = dgvMostrarActores.CurrentRow.Cells[2].Value.ToString();
            cmbSex.Text = dgvMostrarActores.CurrentRow.Cells[3].Value.ToString();
            dtpFecNac.Text = dgvMostrarActores.CurrentRow.Cells[4].Value.ToString();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            oAct.codAcotr = Convert.ToInt32(dgvMostrarActores.CurrentRow.Cells[0].Value.ToString());
            llenandoActor();
            oactDao.ModificarActores(oAct);
            inicio();
            llenarActores();
        }
    }
}
