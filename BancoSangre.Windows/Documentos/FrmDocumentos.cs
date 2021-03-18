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

namespace BancoSangre.Windows.Documentos
{
    public partial class FrmDocumentos : Form
    {
        public FrmDocumentos()
        {
            InitializeComponent();
        }
        private IServicioDocumento _servicio;
        private List<Documento> _list;

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmDocumentos_Load(object sender, EventArgs e)
        {
            _servicio = new ServicioDocumentos();
            {
                try
                {
                    _list = _servicio.GetDocumentos();
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
            foreach (var Documento in _list)
            {
                DataGridViewRow r = construirfila();
                setearfila(r, Documento);
                agregarfila(r);
            }
        }

        private void agregarfila(DataGridViewRow r)
        {
            dgbDatos.Rows.Add(r);
        }

        private void setearfila(DataGridViewRow r, Documento documento)
        {
            r.Cells[cmnDocumentos.Index].Value = documento.Descripcion;
        }

        private DataGridViewRow construirfila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgbDatos);
            return r;
        }
    }
}
