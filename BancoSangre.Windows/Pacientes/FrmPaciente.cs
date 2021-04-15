using BancoSangre.BL.Entidades.DTO.Pacientes;
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

namespace BancoSangre.Windows.Pacientes
{
    public partial class FrmPaciente : Form
    {
        public FrmPaciente()
        {
            InitializeComponent();
        }
        private IServicioPaciente _servi;
        private List<PacienteListDto> _list;

        private void FrmPaciente_Load(object sender, EventArgs e)
        {
            try
            {
                _servi = new ServicioPaciente();
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
            foreach (var pacienteListDto in _list)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, pacienteListDto);
                AgregarFila(r);
            }
        }
        private void AgregarFila(DataGridViewRow r)
        {
            dgbDatos.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, PacienteListDto pacienteListDto)
        {
            r.Cells[CmnNombre.Index].Value = pacienteListDto.NombreDonante;
            r.Cells[cmnApellido.Index].Value = pacienteListDto.ApellidoDonante;
            r.Cells[cmnLoca.Index].Value = pacienteListDto.localidad;
            r.Cells[cmnProv.Index].Value = pacienteListDto.provincia;
            r.Cells[cmnGrupo.Index].Value = pacienteListDto.tipoSangre;
            r.Cells[cmnInstitu.Index].Value = pacienteListDto.institucion;
            r.Tag = pacienteListDto;
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
