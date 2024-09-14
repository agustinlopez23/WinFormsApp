using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp.DAL.Modelos;
using WinFormsApp.DAL;
using WinFormsApp.BLL.Contratos;
using WinFormsApp.DAL.Contrato;
namespace WinFormsApp.BLL
{
    public class DepartamentoService : IDepartamentoService
    {
        private readonly IGenericRepository<Departamento> _departamentoRepository;

        public DepartamentoService(IGenericRepository<Departamento> departamentoRepository)
        {
            _departamentoRepository = departamentoRepository;
        }

        public bool Agregar(Departamento departamento, out string mensaje)
        {
            try
            {
                if (_departamentoRepository.Agregar(departamento))
                {
                    mensaje = "Departamento agregado correctamente.";
                    return true;
                }
                mensaje = "Error al agregar el departamento.";
                return false;
            }
            catch (Exception ex)
            {
                mensaje = $"Error al agregar el departamento: {ex.Message}";
                return false;
            }
        }

        public bool Modificar(Departamento departamento, out string mensaje)
        {
            try
            {
                if (_departamentoRepository.Modificar(departamento))
                {
                    mensaje = "Departamento modificado correctamente.";
                    return true;
                }
                mensaje = "Error al modificar el departamento.";
                return false;
            }
            catch (Exception ex)
            {
                mensaje = $"Error al modificar el departamento: {ex.Message}";
                return false;
            }
        }

        public bool Eliminar(Departamento departamento, out string mensaje)
        {
            try
            {
                if (_departamentoRepository.Eliminar(departamento))
                {
                    mensaje = "Departamento eliminado correctamente.";
                    return true;
                }
                mensaje = "Error al eliminar el departamento.";
                return false;
            }
            catch (Exception ex)
            {
                mensaje = $"Error al eliminar el departamento: {ex.Message}";
                return false;
            }
        }

        public DataTable Mostrar()
        {
            DataTable dataTable = new DataTable();
            try
            {
                dataTable = _departamentoRepository.Mostrar().Tables[0];
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
