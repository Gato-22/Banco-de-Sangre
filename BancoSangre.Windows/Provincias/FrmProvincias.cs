using BancoSangre.BL.Entidades;
using BancoSangre.BL.Entidades.DTO.Provincia;
using BancoSangre.Servicios.Servicios;
using BancoSangre.Servicios.Servicios.Facades;
using BancoSangre.Windows.Provincias;
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
    public partial class FrmProvincias : Form
    {
        public FrmProvincias()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private iServiciosProvincia _servicio;
        private List<ProvinciaListDto> _lista;
        private void FrmProvincias_Load(object sender, EventArgs e)
        {
            _servicio = new ServicioProvincias();
            try
            {
                _lista = _servicio.GetProvincias();
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
            foreach (var provincia in _lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, provincia);
                AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgbDatos.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, ProvinciaListDto provincia)
        {
            r.Cells[cmnProvincias.Index].Value = provincia.NombreProvincia;
            r.Tag=provincia;
        }

        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgbDatos);
            return r;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FrmProvinciasAE frm = new FrmProvinciasAE();
            frm.Text = "Agregar una Provincia";
            DialogResult dr = frm.ShowDialog(this);
            if(dr==DialogResult.OK)
            {
                try
                {
                    ProvinciaEditDto provinciaEditDto = frm.GetProvincia();
                    if (!_servicio.Existe(provinciaEditDto))
                    {
                        _servicio.Guardar(provinciaEditDto);
                        DataGridViewRow r = ConstruirFila();
                        ProvinciaListDto provinciaListDto = new ProvinciaListDto
                        {
                            Provinciaid = provinciaEditDto.ProvinciaId,
                            NombreProvincia=provinciaEditDto.NombreProvincia
                        };
                        SetearFila(r, provinciaListDto);
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

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgbDatos.SelectedRows.Count >0)
            {
                DataGridViewRow r = dgbDatos.SelectedRows[0];
                ProvinciaListDto provincia = (ProvinciaListDto)r.Tag;
                ProvinciaListDto provincia1 =(ProvinciaListDto) provincia.Clone();
                ProvinciaEditDto provinciaEditDto = new ProvinciaEditDto
                {
                    ProvinciaId = provincia.Provinciaid,
                    NombreProvincia = provincia.NombreProvincia
                };
                FrmProvinciasAE frm = new FrmProvinciasAE();
                frm.Text = "editar Provincia";
                frm.SetProvincia(provinciaEditDto);
                DialogResult dr = frm.ShowDialog(this);
                if (dr==DialogResult.OK)
                {
                    try
                    {
                        provinciaEditDto = frm.GetProvincia();
                        if (!_servicio.Existe(provinciaEditDto))
                        {
                            _servicio.Guardar(provinciaEditDto);
                            provincia.NombreProvincia = provinciaEditDto.NombreProvincia;
                            SetearFila(r, provincia);
                            MessageBox.Show("registro Modifica3", "mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            
                        }
                        else
                        {
                            SetearFila(r, provincia1);
                            MessageBox.Show("registro ya existente", "mensajee", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }
                    catch (Exception ex)
                    {
                        SetearFila(r, provincia1);
                        MessageBox.Show(ex.Message, "error llamar al programador", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (dgbDatos.SelectedRows.Count >0)
            {
                DataGridViewRow r = dgbDatos.SelectedRows[0];
                ProvinciaListDto provincia = (ProvinciaListDto)r.Tag;
                DialogResult dr = MessageBox.Show($@"vas a dar de baja el registro que seleccionaste recien: {provincia.NombreProvincia}",
                    @"Confirmar baja", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        _servicio.Borrar(provincia.Provinciaid);
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

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarGrilla();
        }

        private void ActualizarGrilla()
        {
            throw new NotImplementedException();
        }
    }
}
