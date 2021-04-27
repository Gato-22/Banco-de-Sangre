using BancoSangre.BL.Entidades;
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
        private List<Donante> _list;
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

        private void SetearFila(DataGridViewRow r, Donante donanteListDto)
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

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FrmDonanteAE frm = new FrmDonanteAE();
            frm.Text = "Agregar Donante";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }
            try
            {
                Donante donanteEditDto = frm.getDonante();
                if (_servi.existe(donanteEditDto))
                {
                    MessageBox.Show("Registro Repetido", "Mensaje", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
                _servi.guardar(donanteEditDto);
                DataGridViewRow r = ConstruirFila();
                Donante donanteListDto = new Donante
                {
                    DonanteID = donanteEditDto.DonanteID,
                    NombreDonante = donanteEditDto.NombreDonante,
                    ApellidoDonante = donanteEditDto.ApellidoDonante,
                    
                    localidad = donanteEditDto.localidad,
                    provincia = donanteEditDto.provincia,
                    tipoSangre = donanteEditDto.tipoSangre
                };
                SetearFila(r, donanteListDto);
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
            Donante pacienteListDto = (Donante)r.Tag;
            Donante institucionListDtoaux = (Donante)pacienteListDto.Clone();
            DialogResult dr = MessageBox.Show($"¿Desea dar de baja al registro seleccionado {pacienteListDto.NroDocumento}?",
                "Confirmar Baja", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.No)
            {
                return;
            }

            try
            {
                _servi.borrar(pacienteListDto.DonanteID);
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
            Donante donanteListDto = (Donante)r.Tag;
            Donante InstitucionListDtoAuxiliar = (Donante)donanteListDto.Clone();
            FrmDonanteAE frm = new FrmDonanteAE();
            Donante donanteEditDto = _servi.getDonantePorId(donanteListDto.DonanteID);
            frm.Text = "Editar Donante";
            frm.setDonante(donanteEditDto);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }

            try
            {
                donanteEditDto = frm.getDonante();
                //Controlar repitencia

                if (!_servi.existe(donanteEditDto))
                {
                    _servi.guardar(donanteEditDto);
                    donanteListDto.DonanteID = donanteEditDto.DonanteID;
                    donanteListDto.NombreDonante = donanteEditDto.NombreDonante;
                    donanteListDto.ApellidoDonante = donanteEditDto.ApellidoDonante;
                    donanteListDto.genero = donanteEditDto.genero;
                    donanteListDto.documento = donanteEditDto.documento;
                    donanteListDto.NroDocumento = donanteEditDto.NroDocumento;
                    donanteListDto.Direccion = donanteEditDto.Direccion;
                    donanteListDto.provincia = donanteEditDto.provincia;
                    donanteListDto.localidad = donanteEditDto.localidad;
                    donanteListDto.TelefonoFijo = donanteEditDto.TelefonoFijo;
                    donanteListDto.TelefonoMovil = donanteEditDto.TelefonoMovil;
                    donanteListDto.Email = donanteEditDto.Email;
                    donanteListDto.FechaNac = donanteEditDto.FechaNac;
                    donanteListDto.tipoSangre = donanteEditDto.tipoSangre;
                    

                    SetearFila(r, donanteListDto);
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
