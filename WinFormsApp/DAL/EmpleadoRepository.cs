using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp.DAL.Contrato;
using WinFormsApp.DAL.Modelos;

namespace WinFormsApp.DAL
{
    public class EmpleadoRepository : IGenericRepository<Empleado>
    {
        private readonly DbConexionFactory _conexion;
        // Nombres de las columnas en la base de datos como constantes
        private const string TableEmpleado = "[Empleados]";
        const string TableEmpleadoDepartamento = "[EmpleadoDepartamento]";
        const string TableDepartamento = "[Departamentos]";
        private const string ColumnId = "id";
        private const string ColumnNombres = "nombres";
        private const string ColumnPrimerApellido = "primer_apellido";
        private const string ColumnSegundoApellido = "segundo_apellido";
        private const string ColumnCorreo = "correo";
        private const string ColumnFoto = "foto";
        private const string ColumnIdDepartamento = "idDepartamento";
        private const string ColumnIdEmpleado = "idEmpleado";
        private const string ColumnDepartamento = "departamento";
        public EmpleadoRepository(DbConexionFactory conexion)
        {
            _conexion = conexion;
        }
        public bool Agregar(Empleado empleado)
        {
            string query = $"InsertarEmpleadoConDepartamento";

            var parametros = CrearParametrosEmpleado(empleado);
            return _conexion.EjecutarSPSinRetornoDatos(query, parametros);
        }
       

        public bool Eliminar(Empleado empleado)
        {
            string query = $"DELETE FROM {TableEmpleado} WHERE {ColumnId} = @ID";
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@ID", empleado.ID)
            };

            return _conexion.EjecutarComandosSinRetornoDatos(query, parametros);
        }

        public bool Modificar(Empleado empleado)
        {
            string query = $"UPDATE {TableEmpleado} " +
                           $"SET [{ColumnNombres}] = @NOMBRES, [{ColumnPrimerApellido}] = @PRIMER_APELLIDO, " +
                           $"[{ColumnSegundoApellido}] = @SEGUNDO_APELLIDO, [{ColumnCorreo}] = @CORREO, [{ColumnFoto}] = @FOTO " +
                           $"WHERE {ColumnId} = @ID;" +
                           $"UPDATE [dbo].{TableEmpleadoDepartamento}   SET [{ColumnIdDepartamento}] = @idDepartamento  WHERE [{ColumnIdEmpleado}] = @id";

            var parametros = CrearParametrosEmpleado(empleado);
            parametros.Add(new SqlParameter("@ID", empleado.ID));
            parametros.Add(new SqlParameter("@idDepartamento", empleado.Departamento)); 

            return _conexion.EjecutarComandosSinRetornoDatos(query, parametros);
        }

        public DataSet Mostrar()
        {
            string query = $"SELECT TOP(1000) e.[{ColumnId}], e.[{ColumnNombres}], e.[{ColumnPrimerApellido}], " +
                   $"e.[{ColumnSegundoApellido}], e.[{ColumnCorreo}], e.[{ColumnFoto}], " +
                   $"d.[{ColumnId}], d.[{ColumnDepartamento}] " +
                   $"FROM {TableEmpleado} e " +
                   $"LEFT JOIN {TableEmpleadoDepartamento} ed ON e.[{ColumnId}] = ed.[{ColumnIdEmpleado}] " +
                   $"LEFT JOIN {TableDepartamento} d ON ed.[{ColumnIdDepartamento}] = d.[{ColumnId}]";

            using (var cmd = new SqlCommand(query))
            {
                return _conexion.EjecutarSentenciaSql(cmd);
            }
        }


        // Métodos auxiliares privados para evitar duplicación
        private List<SqlParameter> CrearParametrosEmpleado(Empleado empleado)
        {
            return new List<SqlParameter>
            {
                new SqlParameter("@NOMBRES", empleado.Nombre ?? (object)DBNull.Value),
                new SqlParameter("@PRIMER_APELLIDO", empleado.PrimerApellido ?? (object)DBNull.Value),
                new SqlParameter("@SEGUNDO_APELLIDO", empleado.SegundoApellido ?? (object)DBNull.Value),
                new SqlParameter("@CORREO", empleado.Correo ?? (object)DBNull.Value),
                new SqlParameter("@FOTO", SqlDbType.VarBinary) { Value = (object)empleado.FotoEmpleado ?? DBNull.Value },
                 new SqlParameter("@ID_DEPARTAMENTO", empleado.Departamento != null ? empleado.Departamento : (object)DBNull.Value),
            };
        }
 
      
        public int ObtenerIdDepartamento(int idDepartamento)
        {
            // Consulta SQL
            string query = "SELECT TOP 1 id FROM [form_practice].[dbo].[Departamentos] WHERE id_departamento = @ID_DEPARTAMENTO";

            // Parámetros SQL
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@ID_DEPARTAMENTO", idDepartamento)
            };

            // Ejecuta la sentencia y obtiene el resultado como DataSet
            DataSet resultado = _conexion.EjecutarSentenciaSql(query, parametros);

            if (resultado.Tables.Count > 0 && resultado.Tables[0].Rows.Count > 0)
            {
                return Convert.ToInt32(resultado.Tables[0].Rows[0]["id"]);
            }
            else
            {
                MessageBox.Show("No se encontró el departamento especificado.");
                return -1;
            }
        }

    }
}
