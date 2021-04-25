using BancoSangre.BL.Entidades;
using BancoSangre.BL.Entidades.DTO.Documentos;
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
        private List<DocumentoListDto> _list;

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

        private void setearfila(DataGridViewRow r, DocumentoListDto documento)
        {
            r.Cells[cmnDocumentos.Index].Value = documento.Descripcion;
            r.Tag = documento;
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
                    DocumentoEditDto documentoEditDto = frm.GetDocumento();
                    if (!_servicio.existe(documentoEditDto))
                    {
                        _servicio.Guardar(documentoEditDto);
                        DataGridViewRow r = construirfila();
                        DocumentoListDto documentoListDto = new DocumentoListDto
                        {
                            TipoDocumentoID=documentoEditDto.TipoDocumentoID,
                            Descripcion=documentoEditDto.Descripcion
                        };
                        setearfila(r, documentoListDto);
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
                DocumentoListDto documento = (DocumentoListDto)r.Tag;
                DocumentoListDto DocAux =(DocumentoListDto) documento.Clone();
                DocumentoEditDto documentoEditDto = new DocumentoEditDto
                {
                    TipoDocumentoID = documento.TipoDocumentoID,
                    Descripcion = documento.Descripcion
                };
                FrmDocumentosAE frm = new FrmDocumentosAE();
                frm.Text = "editar Documento";
                frm.SetDocumento(documentoEditDto);
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.OK)
                {
                    try
                    {
                        documentoEditDto = frm.GetDocumento();
                        if (!_servicio.existe(documentoEditDto))
                        {
                            _servicio.Guardar(documentoEditDto);
                            documento.Descripcion = documentoEditDto.Descripcion;
                            setearfila(r, documento);
                            MessageBox.Show("registro Modifica3", "mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else
                        {
                            setearfila(r, DocAux);
                            MessageBox.Show("registro ya existente", "mensajee", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }
                    catch (Exception ex)
                    {
                        setearfila(r, DocAux);
                        MessageBox.Show(ex.Message, "error llamar al programador", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (dgbDatos.SelectedRows.Count > 0)
            {
                DataGridViewRow r = dgbDatos.SelectedRows[0];
                DocumentoListDto documento = (DocumentoListDto)r.Tag;
                DialogResult dr = MessageBox.Show($@"vas a dar de baja el registro que seleccionaste recien: {documento.Descripcion}",
                   @"Confirmar baja", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (dr == DialogResult.Yes)
                {                  
                    try
                    {
                        _servicio.borrar(documento.TipoDocumentoID);
                        dgbDatos.Rows.Remove(r);
                        MessageBox.Show(@"Registro Borra3", @"Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }          
        }
    }
}
