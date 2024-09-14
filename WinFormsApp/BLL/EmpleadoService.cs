using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp.BLL.Contratos;
using WinFormsApp.DAL;
using WinFormsApp.DAL.Contrato;
using WinFormsApp.DAL.Modelos;

namespace WinFormsApp.BLL
{
    public class EmpleadoService : IEmpleadoService
    {
        private readonly IGenericRepository<Empleado> _empleadoRepository;

        public EmpleadoService(IGenericRepository<Empleado> empleadoRepository)
        {
            _empleadoRepository = empleadoRepository;
        }
        public bool Agregar(Empleado empleado, out string mensaje)
        {
            try
            {
                if (_empleadoRepository.Agregar(empleado))
                {
                    mensaje = "Agregado correctamente";
                    return true;
                }
                mensaje = "Error al agregar";
                return false;
            }
            catch (Exception ex)
            {

                mensaje = $"Error al agregar {ex.Message}"; 
                return false;
            }
        }

        public bool Eliminar(Empleado empleado, out string mensaje)
        {
            try
            {
                if (_empleadoRepository.Eliminar(empleado))
                {
                    mensaje = "Eliminado correctamente";
                    return true;
                }
                mensaje = "Error al eliminar";
                return false;
            }
            catch (Exception)
            {

                mensaje = "Error al eliminar";
                return false;
            }
        }

        public bool Modificar(Empleado empleado, out string mensaje)
        {
            try
            {
                if (_empleadoRepository.Modificar(empleado))
                {
                    mensaje = "El empleado se modifico correctamente";
                    return true;
                }
                mensaje = "El empleado no se pudo modificar";
                return false;
            }
            catch (Exception ex)
            {

                mensaje = $"El empleado no se pudo modificar {ex.Message}";
                return false;
            }
        }

        public DataTable Mostrar()
        {
            DataTable dataTable = new DataTable();
            try
            {
                dataTable = _empleadoRepository.Mostrar().Tables[0];
            }
            catch (Exception ex)
            {

                dataTable.Columns.Add("Error", typeof(string));
                DataRow row = dataTable.NewRow();
                row["Error"] = "Ocurrió un error al cargar los datos: " + ex.Message;
                dataTable.Rows.Add(row);
            }
            return dataTable;
        }
    }
}
