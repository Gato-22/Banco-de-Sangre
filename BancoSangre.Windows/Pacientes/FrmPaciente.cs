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
            r.Cells[CmnNombre.Index].Value = pacienteListDto.NombrePaciente;
            r.Cells[cmnApellido.Index].Value = pacienteListDto.ApellidoPaciente;
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

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FrmPacienteAE frm = new FrmPacienteAE();
            frm.Text = "Agregar Paciente";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }
            try
            {
                PacienteEditDto pacienteEditDto = frm.getPaciente();
                if (_servi.existe(pacienteEditDto))
                {
                    MessageBox.Show("Registro Repetido", "Mensaje", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
                _servi.guardar(pacienteEditDto);
                DataGridViewRow r = ConstruirFila();
                PacienteListDto pacienteListDto = new PacienteListDto
                {
                    PacienteID = pacienteEditDto.PacienteID,
                    NombrePaciente= pacienteEditDto.NombrePaciente,
                    ApellidoPaciente= pacienteEditDto.ApellidoPaciente,
                    institucion=pacienteEditDto.institucion.Denominacion,
                    localidad=pacienteEditDto.localidad.NombreLocalidad,
                    provincia=pacienteEditDto.provincia.NombreProvincia,
                    tipoSangre=pacienteEditDto.tipoSangre.Grupo
                };
                SetearFila(r, pacienteListDto);
                AgregarFila(r);
                MessageBox.Show("Registro Agregado", "Mensaje", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (dgbDatos.SelectedRows.Count == 0)
            {
                return;
            }
            DataGridViewRow r = dgbDatos.SelectedRows[0];
            PacienteListDto pacienteListDto = (PacienteListDto)r.Tag;
            PacienteListDto institucionListDtoaux = (PacienteListDto)pacienteListDto.Clone();
            DialogResult dr = MessageBox.Show($"¿Desea dar de baja al registro seleccionado {pacienteListDto.NroDocumento}?",
                "Confirmar Baja", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.No)
            {
                return;
            }

            try
            {
                _servi.borrar(pacienteListDto.PacienteID);
                dgbDatos.Rows.Remove(r);
                MessageBox.Show("Registro Borrado", "Mensaje", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgbDatos.SelectedRows.Count == 0)
            {
                return;
            }
            DataGridViewRow r = dgbDatos.SelectedRows[0];
            PacienteListDto pacienteListDto = (PacienteListDto)r.Tag;
            PacienteListDto InstitucionListDtoAuxiliar = (PacienteListDto)pacienteListDto.Clone();
            FrmPacienteAE frm = new FrmPacienteAE();
            PacienteEditDto pacienteEditDto = _servi.getPacientePorID(pacienteListDto.PacienteID);
            frm.Text = "Editar Paciente";
            frm.SetPaciente(pacienteEditDto);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }

            try
            {
                pacienteEditDto = frm.getPaciente();
                //Controlar repitencia

                if (!_servi.existe(pacienteEditDto))
                {
                    _servi.guardar(pacienteEditDto);
                    pacienteListDto.PacienteID = pacienteEditDto.PacienteID;
                    pacienteListDto.NombrePaciente = pacienteEditDto.NombrePaciente;
                    pacienteListDto.ApellidoPaciente = pacienteEditDto.ApellidoPaciente;
                    pacienteListDto.Genero = pacienteEditDto.genero.GeneroDescripcion;
                    pacienteListDto.TipoDocumento = pacienteEditDto.documento.Descripcion;
                    pacienteListDto.NroDocumento = pacienteEditDto.NroDocumento;
                    pacienteListDto.direccion = pacienteEditDto.Direccion;
                    pacienteListDto.provincia = pacienteEditDto.provincia.NombreProvincia;
                    pacienteListDto.localidad = pacienteEditDto.localidad.NombreLocalidad;
                    pacienteListDto.TelefonoFijo = pacienteEditDto.TelefonoFijo;
                    pacienteListDto.TelefonoMovil = pacienteEditDto.TelefonoMovil;
                    pacienteListDto.Email = pacienteEditDto.Email;
                    pacienteListDto.fechaNacimiento = pacienteEditDto.FechaNac;
                    pacienteListDto.tipoSangre = pacienteEditDto.tipoSangre.Grupo;
                    pacienteListDto.institucion = pacienteEditDto.institucion.Denominacion;

                    SetearFila(r, pacienteListDto);
                    MessageBox.Show("Registro Agregado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    SetearFila(r, InstitucionListDtoAuxiliar);
                    MessageBox.Show("Registro ya existente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch (Exception exception)
            {
                SetearFila(r, InstitucionListDtoAuxiliar);

                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

}
