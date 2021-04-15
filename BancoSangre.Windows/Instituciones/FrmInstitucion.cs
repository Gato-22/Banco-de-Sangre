using BancoSangre.BL.Entidades.DTO.Institucion;
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

namespace BancoSangre.Windows.Instituciones
{
    public partial class FrmInstitucion : Form
    {
        public FrmInstitucion()
        {
            InitializeComponent();
        }
        private IServicioIntitucion _servi;
        private List<InstitucionListDto> _list;
        

        private void FrmInstitucion_Load(object sender, EventArgs e)
        {
            try
            {
                _servi = new ServicioInstitucion();
                _list = _servi.GetLista();
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
            foreach (var instiListDto in _list)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, instiListDto);
                AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgbDatos.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, InstitucionListDto instiListDto)
        {
            r.Cells[cmnDeno.Index].Value = instiListDto.Denominacion;
            r.Cells[cmnDire.Index].Value = instiListDto.Direccion;
            r.Cells[cmnLoca.Index].Value = instiListDto.localidad;
            r.Cells[cmnProvi.Index].Value = instiListDto.provincia;
            r.Tag = instiListDto;
        }

        private DataGridViewRow ConstruirFila()
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
