using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp.BLL;
using WinFormsApp.DAL;
using WinFormsApp.DAL.Modelos;

namespace WinFormsApp.PL
{
    public partial class FrmEmpleados : Form
    {
        private byte[]? imagenEmpleado;
        private readonly EmpleadoService _EmpleadoService;
        private readonly DepartamentoService _DepartamentoService;
        public FrmEmpleados( EmpleadoService EmpleadoService, DepartamentoService DepartamentoService)
        {
           
            InitializeComponent();
            _DepartamentoService = DepartamentoService;
            _EmpleadoService = EmpleadoService;
            InicializarFormulario();
        }
        private void InicializarFormulario()
        {
            ActualizarGrid();
            LimpiarEntradas();
        }
        private void FrmEmpleados_Load(object sender, EventArgs e)
        {
            CargarDepartamentos();
            ConfigurarEncabezadosGrid();
        }

        private void CargarDepartamentos()
        {
            DepartamentoService departamentos = _DepartamentoService;
            Cbo_Departamento.DataSource = departamentos.Mostrar();
            Cbo_Departamento.DisplayMember = "departamento";
            Cbo_Departamento.ValueMember = "ID";
        }
        private void ConfigurarEncabezadosGrid()
        {
            Dgv_Empleados.Columns[0].HeaderText = "ID";
            Dgv_Empleados.Columns[1].HeaderText = "Nombres";
            Dgv_Empleados.Columns[2].HeaderText = "Primer Apellido";
            Dgv_Empleados.Columns[3].HeaderText = "Segundo Apellido";
            Dgv_Empleados.Columns[4].HeaderText = "Correo";
            Dgv_Empleados.Columns[5].HeaderText = "Foto Perfil";
            Dgv_Empleados.Columns[6].HeaderText = "Departamento";
        }
        private Empleado RecolectarDatos()
        {
            try
            {
                int id = 0;
                if (!string.IsNullOrEmpty(Txt_Id.Text))
                {
                    if (!int.TryParse(Txt_Id.Text, out id))
                    {
                        MessageBox.Show("El ID proporcionado no es válido.");
                        return null;
                    }
                }
                return new Empleado
                {

                    ID = id,
                    Nombre = Txt_Nombre.Text,
                    PrimerApellido = Txt_PrimerApellido.Text,
                    SegundoApellido = Txt_SegundoApellido.Text,
                    Correo = Txt_Correo.Text,
                    Departamento = int.TryParse(Cbo_Departamento.SelectedValue.ToString(), out int idDepartamento) ? idDepartamento : 0,
                    FotoEmpleado = imagenEmpleado
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al recolectar datos: {ex.Message}");
                return null;
            }
        }

        private void BtnExaminar_Click(object sender, EventArgs e)
        {
            SeleccionarImagen();
        }

        private void SeleccionarImagen()
        {
            using (OpenFileDialog dialogoSeleccionImagen = new OpenFileDialog())
            {
                dialogoSeleccionImagen.Title = "Seleccionar Imagen";

                if (dialogoSeleccionImagen.ShowDialog() == DialogResult.OK)
                {
                    CargarImagen(dialogoSeleccionImagen);
                }
            }
        }

        private void CargarImagen(OpenFileDialog dialogoSeleccionImagen)
        {
            using (var archivoImagen = dialogoSeleccionImagen.OpenFile())
            {
                Pib_Foto.Image = Image.FromStream(archivoImagen);
                imagenEmpleado = ConvertirImagenABytes(Pib_Foto.Image);
            }
        }

        private byte[] ConvertirImagenABytes(Image imagen)
        {
            using (var stream = new MemoryStream())
            {
                imagen.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                return stream.ToArray();
            }
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            EjecutarAccionConErrorControlado(() =>
            {
                var empleado = RecolectarDatos();
                if (string.IsNullOrEmpty(empleado.Nombre) || string.IsNullOrEmpty(empleado.Correo))
                {
                    MessageBox.Show($"Los campos {Lbl_Correo.Text} y {Lbl_Nombre.Text} deben ser completados.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string mensaje;
                var success = _EmpleadoService.Agregar(empleado,out mensaje);
                if (success)
                {
                    MostrarMensajeExito(mensaje);
                    ActualizarGrid();
                    LimpiarEntradas();
                }
            }, "Error al modificar");

        }
        private void BtnModificar_Click(object sender, EventArgs e)
        {
            EjecutarAccionConErrorControlado(() =>
            {
                var empleado = RecolectarDatos();
                string mensaje;
                var success = _EmpleadoService.Modificar(empleado, out mensaje);
                if (success)
                {
                    MostrarMensajeExito(mensaje);
                    ActualizarGrid();
                    LimpiarEntradas();
                }
            }, "Error al modificar");

        }

        private void BtnBorrar_Click(object sender, EventArgs e)
        {
            EjecutarAccionConErrorControlado(() =>
            {
                var empleado = RecolectarDatos();
                string mensaje;
                var success = _EmpleadoService.Eliminar(empleado, out mensaje);
                if (success)
                {
                    MostrarMensajeExito(mensaje);
                    ActualizarGrid();
                    LimpiarEntradas();
                }
            }, "Error al borrar");
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarEntradas();
        }
        private void Seleccionar(object sender, DataGridViewCellMouseEventArgs e)
        {
            EjecutarAccionConErrorControlado(() =>
            {
                int indice = e.RowIndex;
                if (EsIndiceValido(indice))
                {
                    CargarDatosEnFormulario(indice);
                    CargarImagen(indice);
                    ActivarModoEdicion();

                }
            }, "Error al seleccionar");
        }
        private void CargarDatosEnFormulario(int indice)
        {
            Txt_Id.Text = ObtenerValorCelda(indice, 0);
            Txt_Nombre.Text = ObtenerValorCelda(indice, 1);
            Txt_PrimerApellido.Text = ObtenerValorCelda(indice, 2);
            Txt_SegundoApellido.Text = ObtenerValorCelda(indice, 3);
            Txt_Correo.Text = ObtenerValorCelda(indice, 4);
            var idDepartamentoSeleccionado = ObtenerValorCelda(indice, 6);
            if (idDepartamentoSeleccionado == "") return;
            CargarYSeleccionarDepartamento(Convert.ToInt32(idDepartamentoSeleccionado));
        }

        private string ObtenerValorCelda(int indice, int columna)
        {
            return Dgv_Empleados.Rows[indice].Cells[columna].Value?.ToString() ?? string.Empty;
        }

        private void CargarImagen(int indice)
        {
            var imagenBytes = ObtenerBytesImagen(indice, 5);

            if (imagenBytes != null)
            {
                Pib_Foto.Image = ConvertirBytesAImagen(imagenBytes);
            }
            else
            {
                LimpiarImagen();
            }
        }

        private byte[]? ObtenerBytesImagen(int indice, int columna)
        {
            return Dgv_Empleados.Rows[indice].Cells[columna].Value as byte[];
        }

        private Image ConvertirBytesAImagen(byte[] imagenBytes)
        {
            using (var stream = new MemoryStream(imagenBytes))
            {
                return Image.FromStream(stream);
            }
        }
        private void EstablecerDepartamentoSeleccionado(int idDepartamentoSeleccionado)
        {
            Cbo_Departamento.SelectedValue = idDepartamentoSeleccionado;
        }
        private void CargarYSeleccionarDepartamento(int idDepartamentoSeleccionado)
        {
            CargarDepartamentos();
            EstablecerDepartamentoSeleccionado(idDepartamentoSeleccionado);
        }
        private void LimpiarImagen()
        {
            Pib_Foto.Image = null; // Limpiar la imagen si no hay datos
        }

        private bool EsIndiceValido(int indice)
        {
            return indice >= 0 && indice < Dgv_Empleados.Rows.Count;
        }

        public void ActualizarGrid()
        {
            var datos = _EmpleadoService.Mostrar();
            Dgv_Empleados.DataSource = datos;
            Dgv_Empleados.Columns[6].Visible = false;

        }

        public void LimpiarEntradas()
        {
            Txt_Id.ReadOnly = false;
            Txt_Id.Text = string.Empty;
            Txt_Nombre.Text = string.Empty;
            Txt_PrimerApellido.Text = string.Empty;
            Txt_SegundoApellido.Text = string.Empty;
            Txt_Correo.Text = string.Empty;
            Txt_Id.ReadOnly = true;
            Pib_Foto.Image = null;
            CargarDepartamentos();
            ActualizarEstadoBotones(modoAgregar: true);
        }
        public void ActivarModoEdicion()
        {
            Txt_Id.ReadOnly = true;
            ActualizarEstadoBotones(modoAgregar: false);
        }
        private void ActualizarEstadoBotones(bool modoAgregar)
        {
            Btn_Agregar.Enabled = modoAgregar;
            Btn_Borrar.Enabled = !modoAgregar;
            Btn_Cancelar.Enabled = !modoAgregar;
            Btn_Modificar.Enabled = !modoAgregar;
        }
        private void MostrarMensajeExito(string mensaje)
        {
            MessageBox.Show(mensaje);
        }

        private void EjecutarAccionConErrorControlado(Action accion, string mensajeError)
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


    }
}