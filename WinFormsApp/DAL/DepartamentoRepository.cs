using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using WinFormsApp;
using System.Data;
using WinFormsApp.DAL.Contrato;
using WinFormsApp.DAL.Modelos;
namespace WinFormsApp.DAL
{
    public class DepartamentoRepository : IGenericRepository<Departamento>
    {
        private readonly DbConexionFactory _conexion;

        // Nombres de las columnas en la base de datos como constantes
        private const string TableName = "[Departamentos]";
        private const string ColumnIddepartamento = "id_departamento";
        private const string ColumnId = "id";
        private const string ColumnDepartamento = "departamento";

        public DepartamentoRepository(DbConexionFactory conexion)
        {
            _conexion = conexion;
        }

        public bool Agregar(Departamento oDepartamento)
        {
            string query = $"INSERT INTO {TableName} ([{ColumnDepartamento}], [{ColumnIddepartamento}]) " +
                           "VALUES (@departamento, @id_departamento)";

            var parametros = CrearParametrosDepartamento(oDepartamento);
            return _conexion.EjecutarComandosSinRetornoDatos(query, parametros);
        }

        public bool Eliminar(Departamento oDepartamento)
        {
            string query = $"DELETE FROM {TableName} WHERE [{ColumnIddepartamento}] = @id_departamento";

            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@id_departamento", oDepartamento.ID)
            };

            return _conexion.EjecutarComandosSinRetornoDatos(query, parametros);
        }

        public bool Modificar(Departamento oDepartamento)
        {
            string query = $"UPDATE {TableName} SET [{ColumnDepartamento}] = @departamento " +
                           $"WHERE [{ColumnIddepartamento}] = @id_departamento";

            var parametros = CrearParametrosDepartamento(oDepartamento);
            return _conexion.EjecutarComandosSinRetornoDatos(query, parametros);
        }

        public DataSet Mostrar()
        {
            string query = $"SELECT TOP (1000) [{ColumnId}],[{ColumnIddepartamento}], [{ColumnDepartamento}] FROM {TableName}";

            using (var cmd = new SqlCommand(query))
            {
                return _conexion.EjecutarSentenciaSql(cmd);
            }
        }
        public DataSet Mostrar(int id)
        {
            //Inyeccion Sql
            string query = $"SELECT id FROM [form_practice].[dbo].[Departamentos] Where id_departamento ={id}";

            using (var cmd = new SqlCommand(query))
            {
                return _conexion.EjecutarSentenciaSql(cmd);
            }
        }

        // Métodos auxiliares privados para evitar duplicación
        private List<SqlParameter> CrearParametrosDepartamento(Departamento oDepartamento)
        {
            return new List<SqlParameter>
            {
                new SqlParameter("@departamento", oDepartamento.Nombre ?? (object)DBNull.Value),
                new SqlParameter("@id_departamento", oDepartamento.ID)
            };
        }


    }
}
