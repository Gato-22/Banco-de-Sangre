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

namespace BancoSangre.Windows.Pacientes
{
    public partial class FrmPaciente : Form
    {
        public FrmPaciente()
        {
            InitializeComponent();
        }
        private IServicioPaciente _servi;
        private List<Paciente> _list;

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

        private void SetearFila(DataGridViewRow r, Paciente pacienteListDto)
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
                Paciente pacienteEditDto = frm.getPaciente();
                if (_servi.existe(pacienteEditDto))
                {
                    MessageBox.Show("Registro Repetido", "Mensaje", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
                _servi.guardar(pacienteEditDto);
                DataGridViewRow r = ConstruirFila();
                Paciente pacienteListDto = new Paciente
                {
                    PacienteID = pacienteEditDto.PacienteID,
                    NombrePaciente= pacienteEditDto.NombrePaciente,
                    ApellidoPaciente= pacienteEditDto.ApellidoPaciente,
                    institucion=pacienteEditDto.institucion,
                    localidad=pacienteEditDto.localidad,
                    provincia=pacienteEditDto.provincia,
                    tipoSangre=pacienteEditDto.tipoSangre
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
            Paciente pacienteListDto = (Paciente)r.Tag;
            Paciente institucionListDtoaux = (Paciente)pacienteListDto.Clone();
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
            Paciente pacienteListDto = (Paciente)r.Tag;
            Paciente InstitucionListDtoAuxiliar = (Paciente)pacienteListDto.Clone();
            FrmPacienteAE frm = new FrmPacienteAE();
            Paciente pacienteEditDto = _servi.getPacientePorID(pacienteListDto.PacienteID);
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
                    pacienteListDto.genero = pacienteEditDto.genero;
                    pacienteListDto.documento = pacienteEditDto.documento;
                    pacienteListDto.NroDocumento = pacienteEditDto.NroDocumento;
                    pacienteListDto.Direccion = pacienteEditDto.Direccion;
                    pacienteListDto.provincia = pacienteEditDto.provincia;
                    pacienteListDto.localidad = pacienteEditDto.localidad;
                    pacienteListDto.TelefonoFijo = pacienteEditDto.TelefonoFijo;
                    pacienteListDto.TelefonoMovil = pacienteEditDto.TelefonoMovil;
                    pacienteListDto.Email = pacienteEditDto.Email;
                    pacienteListDto.FechaNac = pacienteEditDto.FechaNac;
                    pacienteListDto.tipoSangre = pacienteEditDto.tipoSangre;
                    pacienteListDto.institucion = pacienteEditDto.institucion;

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
