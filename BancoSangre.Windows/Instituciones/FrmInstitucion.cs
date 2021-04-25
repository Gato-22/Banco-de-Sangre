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

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FrmInstitucionAE frm = new FrmInstitucionAE();
            frm.Text = "Agregar Institucion";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }
            try
            {
                InstitucionEditdto institucionEditdto = frm.getInstitucion();
                if (_servi.existe(institucionEditdto))
                {
                    MessageBox.Show("Registro Repetido", "Mensaje", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
                _servi.guardar(institucionEditdto);
                DataGridViewRow r = ConstruirFila();
                InstitucionListDto institucionListDto = new InstitucionListDto
                {
                    InstitucionID = institucionEditdto.InstitucionID,
                    Direccion = institucionEditdto.Direccion,
                    Denominacion = institucionEditdto.Denominacion,
                    provincia = institucionEditdto.provincia.NombreProvincia,
                    localidad = institucionEditdto.localidad.NombreLocalidad
                };
                SetearFila(r, institucionListDto);
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
            InstitucionListDto institucionListDto = (InstitucionListDto)r.Tag;
            InstitucionListDto institucionListDtoaux = (InstitucionListDto)institucionListDto.Clone();
            DialogResult dr = MessageBox.Show($"¿Desea dar de baja ala Entidad Sanitaria {institucionListDto.Denominacion}?",
                "Confirmar Baja", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.No)
            {
                return;
            }

            try
            {
                _servi.borrar(institucionListDto.InstitucionID);
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
            InstitucionListDto institucionListDto = (InstitucionListDto)r.Tag;
            InstitucionListDto InstitucionListDtoAuxiliar = (InstitucionListDto)institucionListDto.Clone();
            FrmInstitucionAE frm = new FrmInstitucionAE();
            InstitucionEditdto institucionEditdto = _servi.GetInstitucionPorId(institucionListDto.InstitucionID);
            frm.Text = "Editar Cliente";
            frm.setInstitucion(institucionEditdto);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }

            try
            {
                institucionEditdto = frm.getInstitucion();
                //Controlar repitencia

                if (!_servi.existe(institucionEditdto))
                {
                    _servi.guardar(institucionEditdto);
                    institucionListDto.InstitucionID = institucionEditdto.InstitucionID;
                    institucionListDto.Denominacion = institucionEditdto.Denominacion;
                    institucionListDto.Direccion = institucionEditdto.Direccion;
                    institucionListDto.provincia = institucionEditdto.provincia.NombreProvincia;
                    institucionListDto.localidad = institucionEditdto.localidad.NombreLocalidad;

                    SetearFila(r, institucionListDto);
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
