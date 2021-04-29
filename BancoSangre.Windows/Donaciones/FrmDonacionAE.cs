using BancoSangre.BL.Entidades;
using BancoSangre.BL.Entidades.DTO;
using BancoSangre.BL.Entidades.DTO.Institucion;
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

namespace BancoSangre.Windows.Donaciones
{
    public partial class FrmDonacionAE : Form
    {
        private IServicioPaciente _servicioPaciente;
        private IServicioDonante _servicioDonante;
        private ServicioDonante servicioDonante = new ServicioDonante();
        public FrmDonacionAE()
        {
            InitializeComponent();
            this.list = servicioDonante.GetLista();
        }
        private Donacion donacion;
        public List<Donante> list;
        
           
            
        public int cantidad = 0;
        public void SetDonacion(Donacion donacion)
        {
            this.donacion = donacion;
        }
        bool esedicion = false;
        internal Donacion GetTipoDonacion()
        {
            return donacion;
        }
        protected override void OnLoad(EventArgs e)
        {
            
            base.OnLoad(e);
            //Helper.CargarDatosComboDonantes(ref DonanteComboBox);
            Helper.CargarDatosComboPaciente(ref PacienteComboBox);
            Helper.CargarDatosComboTipoDonacion(ref TipoDonacionComboBox);
            TipoDonacionAutomatizadaComboBox.Enabled = false;
            DonanteComboBox.Enabled = false;
            Helper.CargarDatosComboInstitucion(ref InstitucionComboBox);

            //Helper.CargarDatosComboTipoDonacionAutomatizada(ref TipoDonacionAutomatizadaComboBox);
            if (donacion != null)
            {
                esedicion = true;
            }
            if (esedicion)
            {
                Helper.CargarDatosComboDonantes(ref DonanteComboBox,donacion.Paciente,this);
                //FechaDonaciondateTimePicker1.Text = donacion.FechaDonacion.ToString();
                //txtident.Text = donacion.Identificacion;
                DonanteComboBox.SelectedValue = donacion.Donante.DonanteID;
                PacienteComboBox.SelectedValue = donacion.Paciente.PacienteID;
                TipoDonacionComboBox.SelectedValue = donacion.TipoDonacion.TipoDonacionID;
                DonanteComboBox.Enabled = true;
                if (donacion.TipoDonacion.TipoDonacionID==2)
                {
                    Helper.CargarDatosComboTipoDonacionAutomatizada(ref TipoDonacionAutomatizadaComboBox);
                    TipoDonacionAutomatizadaComboBox.Enabled = true;
                    TipoDonacionAutomatizadaComboBox.SelectedValue = donacion.DonacionesDonacionesAutomatizadas.donacionAutomatizada.DonacionAutoID;

                }
                //LocalidadComboBox.SelectedValue = donanteEditDto.localidad.LocalidadID;
                //FechaIngresodateTimePicker2.Text = donacion.FechaIngreso.ToString();
                //txtvenc.Text = donacion.vencimiento;
                txtcaNT.Text = donacion.Cantidad.ToString();
                
            }
        }
        
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (donacion == null)
                {
                    donacion = new Donacion();
                }
                //donacion.Intervalo = int.Parse(txtIntervalo.Text);
                //donacion.FechaDonacion = DateTime.Now;
                donacion.FechaDonacion = dateTimePicker1.Value;
                //donacion.Identificacion = txtident.Text;
                //donacion. = Helper.ConvertirInstitucionListDtoEnInstitucion((InstitucionListDto)InstitucionComboBox.SelectedItem);
                donacion.Donante = (Donante)DonanteComboBox.SelectedItem;
                donacion.Paciente = (Paciente)PacienteComboBox.SelectedItem;
                donacion.TipoDonacion = (TipoDonacion)TipoDonacionComboBox.SelectedItem;
                donacion.institucion = Helper.ConvertirInstitucionListDtoEnInstitucionEditDto((InstitucionListDto)InstitucionComboBox.SelectedItem);
                if (donacion.TipoDonacion.TipoDonacionID==2)
                {
                    donacion.DonacionesDonacionesAutomatizadas.donacionAutomatizada = (DonacionAutomatizada)TipoDonacionAutomatizadaComboBox.SelectedItem;
                    donacion.DonacionesDonacionesAutomatizadas.donacion = donacion; 
                }
                //donacion.FechaIngreso = DateTime.Parse(FechaIngresodateTimePicker2.Text);
                //donacion.vencimiento = txtvenc.Text;
                donacion.Cantidad = int.Parse(txtcaNT.Text);
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (DonanteComboBox.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(DonanteComboBox, "Debe seleccionar un Donante");
            }
            if (PacienteComboBox.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(PacienteComboBox, "Debe seleccionar un paciente");
            }
            if (TipoDonacionComboBox.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(TipoDonacionComboBox, "Debe seleccionar un tipo de donacion");
            }
            if (TipoDonacionAutomatizadaComboBox.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(TipoDonacionAutomatizadaComboBox, "Debe seleccionar un Tipo de donacion automatizada");
            }
            if (string.IsNullOrEmpty(txtcaNT.Text) || string.IsNullOrWhiteSpace(txtcaNT.Text))
            {
                valido = false;
                errorProvider1.SetError(txtcaNT, "Datos Numericos Requeridos");
            }
            int cantidad = 0;
            if (!int.TryParse(txtcaNT.Text,out cantidad))
            {
                valido = false;
                errorProvider1.SetError(txtcaNT, "Ingrese numeros validos, enteros");
            }
            if (cantidad <= 0)
            {
                valido = false;
                errorProvider1.SetError(txtcaNT, "Ingrese numeros Mayor a 0, enteros");
            }

            return valido;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void TipoDonacionComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (TipoDonacionComboBox.SelectedIndex==1)
            {
                TipoDonacionAutomatizadaComboBox.Enabled = true;
                Helper.CargarDatosComboTipoDonacionAutomatizada(ref TipoDonacionAutomatizadaComboBox);

            }
            else
            {
                TipoDonacionAutomatizadaComboBox.Enabled = false;
            }
        }

        
        private void PacienteComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                _servicioDonante = new ServicioDonante();
                if (PacienteComboBox.SelectedIndex != 0)
                {
                    //list = _servicioDonante.GetLista();
                    //MostrarDatosEnGrilla();

                    //EditarEsto
                    //Donante donante = (Donante);
                    //list = _servicioDonante.GetLista(donante);
                    //MostrarDatosEnGrilla();

                    //GrupoSanguineotxt.Text = donante.;


                    //Helper.CargarDatosComboDonantes(ref DonanteComboBox, paciente, this);
                }
                else
                {
                    DonanteComboBox.Enabled = false;
                    CantidadDonantestxt.Text = "";
                    GrupoSanguineotxt.Text = "";

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void MostrarDatosEnGrilla()
        {
            dgbDatos.Rows.Clear();
            foreach (var donante in list)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, donante);
                agregarFila(r);
            }
        }

        private void agregarFila(DataGridViewRow r)
        {
            dgbDatos.Rows.Add();
        }

        private void SetearFila(DataGridViewRow r, Donante donante)
        {
            r.Cells[CmnNombre.Index].Value = donante.Nombrecompleto;
            r.Cells[cmnGrupo.Index].Value = donante.tipoSangre.Grupo;
            r.Tag=donante;
        }

        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgbDatos);
            return r;
        }

        private void CantidadDonantestxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void GrupoSanguineotxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void PacienteComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CantidadDonantestxt.Text = cantidad.ToString();
            DonanteComboBox.Enabled = true;
        }
    }
}
