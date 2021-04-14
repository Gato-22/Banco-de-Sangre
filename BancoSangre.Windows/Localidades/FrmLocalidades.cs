using BancoSangre.BL.Entidades;
using BancoSangre.BL.Entidades.DTO.Localidad;
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

namespace BancoSangre.Windows.Localidades
{
    public partial class FrmLocalidades : Form
    {
        public FrmLocalidades()
        {
            InitializeComponent();
        }
        private IServicioLocalidad _servicio;
        private iServiciosProvincia _servicioProvincia;
        private List<LocalidadListDto> lista;
        
        private void FrmLocalidades_Load(object sender, EventArgs e)
        {
            try
            {
                _servicio = new ServicioLocalidad();
                _servicioProvincia = new ServicioProvincias();
                lista = _servicio.GetLista();
                MostrarDatosEnGrilla();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, @"error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void MostrarDatosEnGrilla()
        {
            dgbDatos.Rows.Clear();
            foreach (var LocalidadListDto in lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, LocalidadListDto);
                AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgbDatos.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, LocalidadListDto localidadListDto)
        {
            r.Cells[cmnLocalidad.Index].Value = localidadListDto.NombreLocalidad;
            r.Cells[cmnProvincia.Index].Value = localidadListDto.NombreProvincia;
            r.Tag = localidadListDto;
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
            FrmLocalidadesAE frm = new FrmLocalidadesAE();
            frm.Text = "Agregar Localidad";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    LocalidadEditDto localidadEditdto = frm.GetLocalidad();
                    

                    if (!_servicio.existe(localidadEditdto))
                    {
                        _servicio.guardar(localidadEditdto);
                        LocalidadListDto localidadListDto = new LocalidadListDto
                        {
                            LocalidadID = localidadEditdto.LocalidadID,
                            NombreLocalidad = localidadEditdto.NombreLocalidad,
                            NombreProvincia = (_servicioProvincia.GetProvinciaPorId(localidadEditdto.Provinciaid)).NombreProvincia,
                        };
                        DataGridViewRow r = ConstruirFila();
                        SetearFila(r, localidadListDto);
                        AgregarFila(r);
                        MessageBox.Show("localidad Agrega3", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show("localidad ya existente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                catch (Exception exception)
                {

                    MessageBox.Show(exception.Message, "Errorr", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (dgbDatos.SelectedRows.Count == 0)
            {
                return;
            }

            DataGridViewRow r = dgbDatos.SelectedRows[0];
            LocalidadListDto localidaddto = (LocalidadListDto)r.Tag;
            DialogResult dr =
                MessageBox
                    .Show($"quiere borrar el registro seleccionado de la localidad {localidaddto.NombreLocalidad}",
                        "Confirmar Baja", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button2
                    );
            if (dr == DialogResult.No)
            {
                return;
            }

            try
            {
                
                _servicio.Borrar(localidaddto.LocalidadID);
                dgbDatos.Rows.Remove(r);
                MessageBox.Show("registro borra3", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Errorrrrr", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgbDatos.SelectedRows.Count == 0)
            {
                return;
            }

            DataGridViewRow r = dgbDatos.SelectedRows[0];
            LocalidadListDto LocalidadListDto = (LocalidadListDto)r.Tag;
            LocalidadListDto localidadListDtoAuxiliar = LocalidadListDto.Clone() as LocalidadListDto;
            FrmLocalidadesAE frm = new FrmLocalidadesAE();
            LocalidadEditDto localidadEditDto = _servicio.getLocalidadPorID(LocalidadListDto.LocalidadID);
            frm.Text = "Editar Localidad";
            frm.SetLocalidad(localidadEditDto);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }

            try
            {
            
                localidadEditDto = frm.GetLocalidad();
                

                if (!_servicio.existe(localidadEditDto))
                {
                    _servicio.guardar(localidadEditDto);
                    LocalidadListDto.LocalidadID = localidadEditDto.LocalidadID;
                    LocalidadListDto.NombreLocalidad = localidadEditDto.NombreLocalidad;
                    LocalidadListDto.NombreProvincia = (_servicioProvincia.GetProvinciaPorId(localidadEditDto.Provinciaid)).NombreProvincia;
                    
                    SetearFila(r, LocalidadListDto);
                    MessageBox.Show("registro modifica3", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    SetearFila(r, localidadListDtoAuxiliar);
                    MessageBox.Show("registro ya existenteee", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch (Exception exception)
            {
                SetearFila(r, localidadListDtoAuxiliar);

                MessageBox.Show(exception.Message, "Errorr, contate al programador nuevamente", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
