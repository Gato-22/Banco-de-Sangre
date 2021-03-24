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

namespace BancoSangre.Windows
{
    public partial class FrmGeneros : Form
    {
        public FrmGeneros()
        {
            InitializeComponent();
        }
        private IServicioGenero _servicio;
        private List<Genero> _genero;

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

        private void SetearFila(DataGridViewRow r, Genero genero)
        {
            r.Cells[cmnGeneros.Index].Value = genero.GeneroDescripcion;
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
    }
}
