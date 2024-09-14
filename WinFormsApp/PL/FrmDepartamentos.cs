using System;
using System.Windows.Forms;
using WinFormsApp.DAL;
using WinFormsApp.DAL.Modelos;
using WinFormsApp.BLL;

namespace WinFormsApp.PL
{
    public partial class FrmDepartamentos : Form
    {
        private readonly DepartamentoService _departamentoService;

        public FrmDepartamentos(DepartamentoService departamentoService)
        {
           
            InitializeComponent();
            _departamentoService = departamentoService;
            InicializarFormulario();
        }

        private void InicializarFormulario()
        {
            ActualizarGrid();
            LimpiarEntradas();
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            ManejarAccionSegura(AgregarDepartamento, "Error al agregar");
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            ManejarAccionSegura(ModificarDepartamento, "Error al modificar");
        }

        private void BtnBorrar_Click(object sender, EventArgs e)
        {
            ManejarAccionSegura(EliminarDepartamento, "Error al borrar");
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarEntradas();
        }

        private void SeleccionarDepartamento(object sender, DataGridViewCellMouseEventArgs e)
        {
            ManejarAccionSegura(() =>
            {
                if (EsIndiceValido(e.RowIndex))
                {
                    CargarDatosEnFormulario(e.RowIndex);
                    ActivarModoEdicion();
                }
            }, "Error al seleccionar");
        }

        private void AgregarDepartamento()
        {
            var departamento = RecolectarInformacion();
            if (departamento.ID==0 || string.IsNullOrEmpty(departamento.Nombre))
            {
                MessageBox.Show("Los dos campos deben ser completados.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }
            string mensaje;
            if (_departamentoService.Agregar(departamento, out mensaje))
            {
                MostrarMensajeExito(mensaje);
                ActualizarGrid();
                LimpiarEntradas();
            }
        }

        private void ModificarDepartamento()
        {
            var departamento = RecolectarInformacion();
            string mensaje;
            if (_departamentoService.Modificar(departamento, out mensaje))
            {
                MostrarMensajeExito(mensaje);
                ActualizarGrid();
                LimpiarEntradas();
            }
        }

        private void EliminarDepartamento()
        {
            var departamento = RecolectarInformacion();
            string mensaje;
            if (_departamentoService.Eliminar(departamento, out mensaje))
            {
                MostrarMensajeExito(mensaje);
                ActualizarGrid();
                LimpiarEntradas();
            }
        }

        private Departamento RecolectarInformacion()
        {
            return new Departamento
            {
                ID = int.TryParse(Txt_IdDepartamento.Text, out var id) ? id : 0,
                Nombre = Txt_NombreDepartamento.Text
            };
        }

        private void CargarDatosEnFormulario(int indice)
        {
            Txt_IdDepartamento.Text = Dgv_Departamentos.Rows[indice].Cells[1].Value.ToString();
            Txt_NombreDepartamento.Text = Dgv_Departamentos.Rows[indice].Cells[2].Value.ToString();
        }

        private bool EsIndiceValido(int indice)
        {
            return indice >= 0 && indice < Dgv_Departamentos.Rows.Count;
        }

        private void ActualizarGrid()
        {
            var datos = _departamentoService.Mostrar();
            Dgv_Departamentos.DataSource = datos;
            ConfigurarGrid();
        }

        private void ConfigurarGrid()
        {
            Dgv_Departamentos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            Dgv_Departamentos.Columns[0].Visible = false;
            Dgv_Departamentos.Columns[1].HeaderText = "ID";
            Dgv_Departamentos.Columns[2].HeaderText = "Nombre Departamento";
        }

        private void LimpiarEntradas()
        {
            Txt_IdDepartamento.Text = string.Empty;
            Txt_NombreDepartamento.Text = string.Empty;
            Txt_IdDepartamento.ReadOnly = false;
            ActualizarEstadoBotones(modoAgregar: true);
        }

        private void ActivarModoEdicion()
        {
            Txt_IdDepartamento.ReadOnly = true;
            ActualizarEstadoBotones(modoAgregar: false);
        }

        private void ActualizarEstadoBotones(bool modoAgregar)
        {
            Btn_Agregar.Enabled = modoAgregar;
            Btn_Borrar.Enabled = !modoAgregar;
            Btn_Cancelar.Enabled = !modoAgregar;
            Btn_Modificar.Enabled = !modoAgregar;
        }

        private void ManejarAccionSegura(Action accion, string mensajeError)
        {
            try
            {
                accion();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{mensajeError}: {ex.Message}");
            }
        }

        private void MostrarMensajeExito(string mensaje)
        {
            MessageBox.Show(mensaje, "Operación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}