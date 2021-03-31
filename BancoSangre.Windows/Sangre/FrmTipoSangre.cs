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

namespace BancoSangre.Windows.Sangre
{
    public partial class FrmTipoSangre : Form
    {
        public FrmTipoSangre()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private IServicioTipoSangre _Servicio;
        private List<TipoSangre> _lista;
        private void FrmTipoSangre_Load(object sender, EventArgs e)
        {
            _Servicio = new ServicioTipoSangre();
            try
            {
                _lista = _Servicio.GetTipoSangres();
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
            foreach (var TipoSangre in _lista)
            {
                DataGridViewRow r = construirFila();
                setearfila(r, TipoSangre);
                agregarfila(r);
            }
        }

        private void agregarfila(DataGridViewRow r)
        {
            dgbDatos.Rows.Add(r);
        }

        private void setearfila(DataGridViewRow r, TipoSangre tipoSangre)
        {
            r.Cells[cmnGrupo.Index].Value = tipoSangre.Grupo;
            r.Cells[cmnFactor.Index].Value = tipoSangre.Factor;
            r.Tag = tipoSangre;
        }

        private DataGridViewRow construirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgbDatos);
            return r;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FrmTipoSangreAE frm = new FrmTipoSangreAE();
            frm.Text = "Agregar un nuevo tipo de SAngre";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    TipoSangre tipoSangre = frm.GetTipoSangre();
                    if (!_Servicio.existe(tipoSangre))
                    {
                        _Servicio.guardar(tipoSangre);
                        DataGridViewRow r = construirFila();
                        setearfila(r, tipoSangre);
                        agregarfila(r);
                        MessageBox.Show("Registro Agregado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Registro ya existente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception exception)
                {

                    MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (dgbDatos.SelectedRows.Count > 0)
            {
                DataGridViewRow r = dgbDatos.SelectedRows[0];
                TipoSangre tipoSangre = (TipoSangre)r.Tag;
                DialogResult dr = MessageBox.Show($@"vas a dar de baja el registro que seleccionaste recien: {tipoSangre.Grupo} {tipoSangre.Factor}",
                    @"Confirmar baja", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        _Servicio.borrar(tipoSangre.GrupoSanguineoID);
                        dgbDatos.Rows.Remove(r);
                        MessageBox.Show(@"Registro borra3", @"message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message, @"error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgbDatos.SelectedRows.Count > 0)
            {
                DataGridViewRow r = dgbDatos.SelectedRows[0];
                TipoSangre tipoSangre = (TipoSangre)r.Tag;
                TipoSangre SanAux = (TipoSangre)tipoSangre.Clone();
                FrmTipoSangreAE frm = new FrmTipoSangreAE();
                frm.Text = "editar Grupo Sanguineo";
                frm.SetTipoSangre(tipoSangre);
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.OK)
                {
                    try
                    {
                        tipoSangre = frm.GetTipoSangre();
                        if (!_Servicio.existe(tipoSangre))
                        {
                            _Servicio.guardar(tipoSangre);
                            setearfila(r, tipoSangre);
                            MessageBox.Show("registro Modifica3", "mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else
                        {
                            setearfila(r, SanAux);
                            MessageBox.Show("registro ya existente", "mensajee", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }
                    catch (Exception ex)
                    {
                        setearfila(r, SanAux);
                        MessageBox.Show(ex.Message, "error llamar al programador", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
