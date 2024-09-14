using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp.DAL.Modelos;

namespace WinFormsApp.BLL.Contratos
{
    public interface IDepartamentoService
    {
        bool Agregar(Departamento departamento, out string mensaje);
        bool Modificar(Departamento departamento, out string mensaje);
        bool Eliminar(Departamento departamento, out string mensaje);
        DataTable Mostrar();
    }
}
