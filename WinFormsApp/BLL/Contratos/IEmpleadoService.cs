using System.Data;
using WinFormsApp.DAL.Modelos;

namespace WinFormsApp.BLL.Contratos
{
    public interface IEmpleadoService
    {


        bool Agregar(Empleado empleado, out string mensaje);
        bool Modificar(Empleado empleado, out string mensaje);
        bool Eliminar(Empleado empleado, out string mensaje);
        DataTable Mostrar();
    }



}
