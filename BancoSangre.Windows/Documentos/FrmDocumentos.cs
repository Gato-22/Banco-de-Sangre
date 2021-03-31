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

namespace BancoSangre.Windows.Documentos
{
    public partial class FrmDocumentos : Form
    {
        public FrmDocumentos()
        {
            InitializeComponent();
        }
        private IServicioDocumento _servicio;
        private List<Documento> _list;

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmDocumentos_Load(object sender, EventArgs e)
        {
            _servicio = new ServicioDocumentos();
            {
                try
                {
                    _list = _servicio.GetDocumentos();
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
            foreach (var Documento in _list)
            {
                DataGridViewRow r = construirfila();
                setearfila(r, Documento);
                agregarfila(r);
            }
        }

        private void agregarfila(DataGridViewRow r)
        {
            dgbDatos.Rows.Add(r);
        }

        private void setearfila(DataGridViewRow r, Documento documento)
        {
            r.Cells[cmnDocumentos.Index].Value = documento.Descripcion;
        }

        private DataGridViewRow construirfila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgbDatos);
            return r;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FrmDocumentosAE frm = new FrmDocumentosAE();
            frm.Text = "Agregar nuevo tipo de documento";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    Documento documento = frm.GetDocumento();
                    if (!_servicio.existe(documento))
                    {
                        _servicio.Guardar(documento);
                        DataGridViewRow r = construirfila();
                        setearfila(r, documento);
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
    }
}
