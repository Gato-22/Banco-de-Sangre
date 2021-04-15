using BancoSangre.BL.Entidades;
using BancoSangre.BL.Entidades.DTO.Provincia;
using BancoSangre.Servicios.Servicios;
using BancoSangre.Servicios.Servicios.Facades;
using BancoSangre.Windows.Ahelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BancoSangre.Windows.Localidades
{
    public partial class FrmBuscarLocalidad : Form
    {
        public FrmBuscarLocalidad()
        {
            InitializeComponent();
        }
       

        private void FrmBuscarLocalidad_Load(object sender, EventArgs e)
        {
            Helper.CargarDatosComboProvincias(ref comboBoxProvincia);
        }
        private ProvinciaListDto provinciadto;
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                provinciadto =(ProvinciaListDto) comboBoxProvincia.SelectedItem;
                DialogResult = DialogResult.OK; 
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (comboBoxProvincia.SelectedIndex==0)
            {
                valido = false;
                errorProvider1.SetError(comboBoxProvincia, "debe elejir una provincia");
            }
            return valido;
        }

        public ProvinciaListDto GetProvincia()
        {
            return provinciadto;
        }
    }
}
