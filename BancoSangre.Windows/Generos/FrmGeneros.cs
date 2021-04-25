using BancoSangre.BL.Entidades;
using BancoSangre.BL.Entidades.DTO.Generos;
using BancoSangre.Servicios.Servicios;
using BancoSangre.Servicios.Servicios.Facades;
using BancoSangre.Windows.Generos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BancoSangre.Windows
{
    public partial class FrmGeneros : Form
    {
        public FrmGeneros()
        {
            InitializeComponent();
        }
        private IServicioGenero _servicio;
        private List<GeneroListDto> _genero;

        private void FrmGeneros_Load(object sender, EventArgs e)
        {
            _servicio = new ServicioGeneros();
            {
                try
                {
                    _genero = _servicio.GetGeneros();
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
            foreach (var genero in _genero)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, genero);
                AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgbDatos.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, GeneroListDto genero)
        {
            r.Cells[cmnGeneros.Index].Value = genero.GeneroDescripcion;
            r.Tag = genero;
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
            FrmGenerosAE frm = new FrmGenerosAE();
            frm.Text = "Agregar un genero";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    GeneroEditDto genero = frm.GetGenero();
                    if (!_servicio.existe(genero))
                    {
                        _servicio.Guardar(genero);
                        DataGridViewRow r = ConstruirFila();
                        GeneroListDto generoListdto = new GeneroListDto
                        {
                            GeneroID=genero.GeneroID,
                            GeneroDescripcion=genero.GeneroDescripcion
                        };
                        SetearFila(r, generoListdto);
                        AgregarFila(r);
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
                GeneroListDto genero = (GeneroListDto)r.Tag;
                DialogResult dr = MessageBox.Show($@"vas a dar de baja el registro que seleccionaste recien: {genero.GeneroDescripcion}",
                    @"Confirmar baja", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        _servicio.Borar(genero.GeneroID);
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
                GeneroListDto genero = (GeneroListDto)r.Tag;
                GeneroListDto GeneroAUX = (GeneroListDto)genero.Clone();
                GeneroEditDto generoEditDto = new GeneroEditDto
                {

                    GeneroID = genero.GeneroID,
                    GeneroDescripcion = genero.GeneroDescripcion

                };
                FrmGenerosAE frm = new FrmGenerosAE();
                frm.Text = "editar Genero";
                frm.SetGenero(generoEditDto);
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.OK)
                {
                    try
                    {
                        generoEditDto = frm.GetGenero();
                        if (!_servicio.existe(generoEditDto))
                        {
                            _servicio.Guardar(generoEditDto);
                            genero.GeneroDescripcion = generoEditDto.GeneroDescripcion;
                            SetearFila(r, genero);
                            MessageBox.Show("registro Modifica3", "mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else
                        {
                            SetearFila(r, GeneroAUX);
                            MessageBox.Show("registro ya existente", "mensajee", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }
                    catch (Exception ex)
                    {
                        SetearFila(r, GeneroAUX);
                        MessageBox.Show(ex.Message, "error llamar al programador", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
