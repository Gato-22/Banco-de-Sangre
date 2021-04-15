using BancoSangre.BL.Entidades.DTO;
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
    public partial class FrmDonante : Form
    {
        public FrmDonante()
        {
            InitializeComponent();
        }
        private IServicioDonante _servi;
        private List<DonanteListDto> _list;
        private void FrmDonante_Load(object sender, EventArgs e)
        {
            try
            {
                _servi = new ServicioDonante();
                _list = _servi.GetLista();
                MostrarDatosEnGrilla();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception  );
                throw;
            }
        }
        private void MostrarDatosEnGrilla()
        {
            dgbDatos.Rows.Clear();
            foreach (var donanteListDto in _list)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, donanteListDto);
                AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgbDatos.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, DonanteListDto donanteListDto)
        {
            r.Cells[CmnNombre.Index].Value = donanteListDto.NombreDonante;
            r.Cells[cmnApellido.Index].Value = donanteListDto.ApellidoDonante;
            r.Cells[cmnLoca.Index].Value = donanteListDto.localidad;
            r.Cells[cmnProv.Index].Value = donanteListDto.provincia;
            r.Cells[cmnGrupo.Index].Value = donanteListDto.tipoSangre;
            r.Tag = donanteListDto;
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
