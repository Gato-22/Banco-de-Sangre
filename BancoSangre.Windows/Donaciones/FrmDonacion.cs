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
    public partial class FrmDonacion : Form
    {
        public FrmDonacion()
        {
            InitializeComponent();
        }
        private IServicioDonacion _servi;
        private List<Donacion> _lista;

        private void FrmDonacion_Load(object sender, EventArgs e)
        {
            _servi = new ServicioDonacio();
            try
            {
                _lista = _servi.GetDonacion();
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
            foreach (var donacion in _lista)
            {
                DataGridViewRow r = construirfila();
                setearfila(r, donacion);
                agregarfila(r);
            }
        }

        private DataGridViewRow construirfila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgbDatos);
            return r;
        }

        private void setearfila(DataGridViewRow r, Donacion donacion)
        {
            r.Cells[cmnFechaDonacion.Index].Value = donacion.FechaDonacion;
            //r.Cells[cmnIdenti.Index].Value = donacion.Identificacion;
            r.Cells[cmnDonante.Index].Value = donacion.Donante.NombreDonante + donacion.Donante.ApellidoDonante;
            r.Cells[cmnPaciente.Index].Value = donacion.Paciente.NombrePaciente + donacion.Paciente.ApellidoPaciente;
            r.Cells[cmnTipoDonacion.Index].Value = donacion.TipoDonacion.Descripcion;
            
            //r.Cells[cmnFechaingre.Index].Value = donacion.FechaIngreso;
            //r.Cells[cmnVenci.Index].Value = donacion.vencimiento;
            r.Cells[cmnCanti.Index].Value = donacion.Cantidad;
            r.Tag = donacion;
        }

        private void agregarfila(DataGridViewRow r)
        {
            dgbDatos.Rows.Add(r);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (dgbDatos.SelectedRows.Count > 0)
            {
                DataGridViewRow r = dgbDatos.SelectedRows[0];
                Donacion donacion = (Donacion)r.Tag;
                DialogResult dr = MessageBox.Show($@"vas a dar de baja el registro que seleccionaste recien",
                    @"Confirmar baja", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        _servi.borrar(donacion.DonacionId);
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

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FrmDonacionAE frm = new FrmDonacionAE();
            frm.Text = "Agregar una nueva Donacion";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    Donacion donacion = frm.GetTipoDonacion();
                    if (!_servi.existe(donacion))
                    {
                        _servi.guardar(donacion);
                        DataGridViewRow r = construirfila();
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

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgbDatos.SelectedRows.Count > 0)
            {
                DataGridViewRow r = dgbDatos.SelectedRows[0];
                Donacion donacion = (Donacion)r.Tag;
                Donacion SanAux = (Donacion)donacion.Clone();
                FrmDonacionAE frm = new FrmDonacionAE();
                frm.Text = "editar Donacion Automatizada";
                frm.SetDonacion(donacion);
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.OK)
                {
                    try
                    {
                        donacion = frm.GetTipoDonacion();
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
