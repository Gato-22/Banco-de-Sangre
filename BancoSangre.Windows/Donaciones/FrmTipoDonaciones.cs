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
    public partial class FrmTipoDonaciones : Form
    {
        public FrmTipoDonaciones()
        {
            InitializeComponent();
        }
        private IServicioTipoDonacion _servicio;
        private List<TipoDonacion> _asd;

        private void FrmTipoDonaciones_Load(object sender, EventArgs e)
        {
            _servicio = new ServicioTipoDonacion();
            {
                try
                {
                    _asd = _servicio.GetTipoDonacions();
                    MostrarDatosEnGrilla();
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                    throw;
                }
            }
        }

        private void MostrarDatosEnGrilla()
        {
            dgbDatos.Rows.Clear();
            foreach (var donacion in _asd)
            {
                DataGridViewRow r = construirfila();
                setearFila(r, donacion);
                agregarfila(r);
            }
        }

        private void agregarfila(DataGridViewRow r)
        {
            dgbDatos.Rows.Add(r);
        }

        private void setearFila(DataGridViewRow r, TipoDonacion donacion)
        {
            r.Cells[cmnTipoDonaciones.Index].Value = donacion.Descripcion;
            r.Tag = donacion;
        }

        private DataGridViewRow construirfila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgbDatos);
            return r;
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
                TipoDonacion tipoDonacion = (TipoDonacion)r.Tag;
                DialogResult dr = MessageBox.Show($@"vas a dar de baja el registro que seleccionaste recientemente: {tipoDonacion.Descripcion}",
                    @"Confirmar baja", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        _servicio.borrar(tipoDonacion.TipoDonacionID);
                        dgbDatos.Rows.Remove(r);
                        MessageBox.Show(@"Registro borra3", @"message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message, @"errore", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FrmTipoDonacionesAE frm = new FrmTipoDonacionesAE();
            frm.Text = "Agregar nuevo tipo de Donacion";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    TipoDonacion tipoDonacion = frm.GetTipoDonacion();
                    if (!_servicio.existe(tipoDonacion))
                    {
                        _servicio.guardar(tipoDonacion);
                        DataGridViewRow r = construirfila();
                        setearFila(r, tipoDonacion);
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
                TipoDonacion tipodonacion = (TipoDonacion)r.Tag;
                TipoDonacion tipoAUX = (TipoDonacion)tipodonacion.Clone();
                FrmTipoDonacionesAE frm = new FrmTipoDonacionesAE();
                frm.Text = "editar Donacion";
                frm.SetTipoDonacion(tipodonacion);
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.OK)
                {
                    try
                    {
                        tipodonacion = frm.GetTipoDonacion();
                        if (!_servicio.existe(tipodonacion))
                        {
                            _servicio.guardar(tipodonacion);
                            setearFila(r, tipodonacion);
                            MessageBox.Show("registro Modifica3", "mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else
                        {
                            setearFila(r, tipoAUX);
                            MessageBox.Show("registro ya existente", "mensajee", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }
                    catch (Exception ex)
                    {
                        setearFila(r, tipoAUX);
                        MessageBox.Show(ex.Message, "error llamar al programador", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
