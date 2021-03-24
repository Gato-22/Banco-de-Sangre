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

namespace BancoSangre.Windows.Donaciones
{
    public partial class FrmTipoDonaciones : Form
    {
        public FrmTipoDonaciones()
        {
            InitializeComponent();
        }
        private IServicioTipoDonacion _servicio;
        private List<TipoDonacion> _asd;

        private void FrmTipoDonaciones_Load(object sender, EventArgs e)
        {
            _servicio = new ServicioTipoDonacion();
            {
                try
                {
                    _asd = _servicio.GetTipoDonacions();
                    MostrarDatosEnGrilla();
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                    throw;
                }
            }
        }

        private void MostrarDatosEnGrilla()
        {
            dgbDatos.Rows.Clear();
            foreach (var donacion in _asd)
            {
                DataGridViewRow r = construirfila();
                setearFila(r, donacion);
                agregarfila(r);
            }
        }

        private void agregarfila(DataGridViewRow r)
        {
            dgbDatos.Rows.Add(r);
        }

        private void setearFila(DataGridViewRow r, TipoDonacion donacion)
        {
            r.Cells[cmnTipoDonaciones.Index].Value = donacion.Descripcion;
        }

        private DataGridViewRow construirfila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgbDatos);
            return r;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
