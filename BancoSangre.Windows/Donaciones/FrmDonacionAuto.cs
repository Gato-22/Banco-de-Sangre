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

namespace BancoSangre.Windows.Donaciones
{
    public partial class FrmDonacionAuto : Form
    {
        public FrmDonacionAuto()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private IServicioDonacionAutomatizada _servi;
        private List<DonacionAutomatizada> _list;

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FrmDonacionAutoAE frm = new FrmDonacionAutoAE();
            frm.Text = "Agregar un nuevo tipo de Donacion Automatizada";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    DonacionAutomatizada donacion = frm.GetTipoDonacionAuto();
                    if (!_servi.existe(donacion))
                    {
                        _servi.guardar(donacion);
                        DataGridViewRow r = construirFila();
                        setearfila(r, donacion);
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

        private void FrmDonacionAuto_Load(object sender, EventArgs e)
        {
            _servi = new ServicioDonacionAutomatizada();
            try
            {
                _list = _servi.GetDonacions();
                MostrarDatosEnGrilla();
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void MostrarDatosEnGrilla()
        {
            dgbDatos.Rows.Clear();
            foreach (var donacion in _list)
            {
                DataGridViewRow r = construirFila();
                setearfila(r, donacion);
                agregarfila(r);
            }
        }

        private void agregarfila(DataGridViewRow r)
        {
            dgbDatos.Rows.Add(r);
        }

        private void setearfila(DataGridViewRow r, DonacionAutomatizada donacion)
        {
            r.Cells[cmnDescripcion.Index].Value = donacion.Descripcion;
            r.Cells[cmnIntervalo.Index].Value = donacion.Intervalo;
            r.Tag = donacion;
        }

        private DataGridViewRow construirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgbDatos);
            return r;
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (dgbDatos.SelectedRows.Count > 0)
            {
                DataGridViewRow r = dgbDatos.SelectedRows[0];
                DonacionAutomatizada donacion = (DonacionAutomatizada)r.Tag;
                DialogResult dr = MessageBox.Show($@"vas a dar de baja el registro que seleccionaste recien: {donacion.Descripcion}  con dias de {donacion.Intervalo}",
                    @"Confirmar baja", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        _servi.borrar(donacion.DonacionAutoID);
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
                DonacionAutomatizada donacion = (DonacionAutomatizada)r.Tag;
                DonacionAutomatizada SanAux = (DonacionAutomatizada)donacion.Clone();
                FrmDonacionAutoAE frm = new FrmDonacionAutoAE();
                frm.Text = "editar Donacion Automatizada";
                frm.SetTipoSangre(donacion);
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.OK)
                {
                    try
                    {
                        donacion = frm.GetTipoDonacionAuto();
                        if (!_servi.existe(donacion))
                        {
                            _servi.guardar(donacion);
                            setearfila(r, donacion);
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
