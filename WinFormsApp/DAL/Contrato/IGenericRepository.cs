using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp.BLL;

namespace WinFormsApp.DAL.Contrato
{
     public interface IGenericRepository<T>
    {
        
        bool Agregar(T entidad);
        bool Eliminar(T entidad);
        bool Modificar(T entidad);
        DataSet Mostrar();
    }
}
