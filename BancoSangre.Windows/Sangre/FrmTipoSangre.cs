using BancoSangre.BL.Entidades;
using BancoSangre.Servicios.Servicios;
using BancoSangre.Servicios.Servicios.Facades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BancoSangre.Windows.Sangre
{
    public partial class FrmTipoSangre : Form
    {
        public FrmTipoSangre()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private IServicioTipoSangre _Servicio;
        private List<TipoSangre> _lista;
        private void FrmTipoSangre_Load(object sender, EventArgs e)
        {
            _Servicio = new ServicioTipoSangre();
            try
            {
                _lista = _Servicio.GetTipoSangres();
                MostrarDatosEnGrilla();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        private void MostrarDatosEnGrilla()
        {
            dgbDatos.Rows.Clear();
            foreach (var TipoSangre in _lista)
            {
                DataGridViewRow r = construirFila();
                setearfila(r, TipoSangre);
                agregarfila(r);
            }
        }

        private void agregarfila(DataGridViewRow r)
        {
            dgbDatos.Rows.Add(r);
        }

        private void setearfila(DataGridViewRow r, TipoSangre tipoSangre)
        {
            r.Cells[cmnGrupo.Index].Value = tipoSangre.Grupo;
            r.Cells[cmnFactor.Index].Value = tipoSangre.Factor;
        }

        private DataGridViewRow construirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgbDatos);
            return r;
        }
    }
}
