using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using WinFormsApp.DAL.Contrato;

namespace WinFormsApp.DAL
{
    public class DbConexionFactory : IDbConexionFactory
    {
        private readonly string _connectionString;
        private SqlConnection _connection;
       
        public DbConexionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public SqlConnection GetConnection()
        {
            if (_connection == null || _connection.State == ConnectionState.Closed)
            {
                _connection = new SqlConnection(_connectionString);
                _connection.Open();
            }
            return _connection;
        }

        public void Dispose()
        {
            if (_connection != null && _connection.State == ConnectionState.Open)
            {
                _connection.Close();
                _connection.Dispose();
            }
        }

        public bool EjecutarComandosSinRetornoDatos(string query, List<SqlParameter> parametros)
        {
            try
            {
                using (var connection = GetConnection())
                {
                using (var cmd = new SqlCommand(query, connection))
                 {
                    if (parametros != null)
                        cmd.Parameters.AddRange(parametros.ToArray());

                    cmd.ExecuteNonQuery();
                    return true;
                 }
                }
            }
            catch (SqlException ex)
            {

                if (ex.Number == 2627)
                {
                    MessageBox.Show("Error: El identificador del departamento ya existe. Por favor, elija un identificador diferente.", "Error de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show($"Error de SQL: {ex.Message}", "Error de SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return false;
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Error general: {ex.Message}");
                return false;
            }
        }



        public DataSet EjecutarSentenciaSql(SqlCommand sqlCommand)
        {
            try
            {
                var ds = new DataSet();
            using (var connection = GetConnection())  // Obtener y manejar la conexión
            {
                sqlCommand.Connection = connection;
                using (var adapter = new SqlDataAdapter(sqlCommand))
                {
                    adapter.Fill(ds);
                }
            }
            return ds;
            }
            catch (SqlException ex)
            {

                MessageBox.Show($"Error de SQL: {ex.Message}");
                return new DataSet();
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Error general: {ex.Message}");
                return new DataSet();
            }
        }

       
        public DataSet EjecutarSentenciaSql(string query, List<SqlParameter> parametros)
        {
            try
            {
                var ds = new DataSet();
                using (var connection = GetConnection())  // Obtener y manejar la conexión
                {
                    using (var cmd = CrearComando(query, connection, parametros))
                    {
                        using (var adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(ds);
                        }
                    }
                }
                return ds;
            }
            catch (SqlException ex)
            {

                MessageBox.Show($"Error de SQL: {ex.Message}");
                return new DataSet();
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Error general: {ex.Message}");
                return new DataSet();
            }
        }
        public bool EjecutarSPSinRetornoDatos(string strCmd, List<SqlParameter> parametros)
        {
            try
            {
                using (var connection = GetConnection())  // Abre la conexión
                {
                    using (var cmd = CrearComando(strCmd, connection, parametros))  
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.ExecuteNonQuery();  
                    }
                }
                return true;  
            }
            catch (SqlException ex)
            {
                
                MessageBox.Show($"Error de SQL: {ex.Message}");
                return false;  
            }
            catch (Exception ex)
            {
                
                MessageBox.Show($"Error general: {ex.Message}");
                return false;
            }
        }
        public int EjecutarComandosScopeIdentity(string strCmd, List<SqlParameter> parametros)
        {
            try
            {
                using (var connection = GetConnection())
                {
                    using (var cmd = CrearComando($"{strCmd}; SELECT SCOPE_IDENTITY();", connection, parametros))
                    {
                        
                        return Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
            }
            catch (SqlException ex)
            {
               
                MessageBox.Show($"Error de SQL: {ex.Message}");
                return -1;  
            }
            catch (Exception ex)
            {
                
                MessageBox.Show($"Error general: {ex.Message}");
                return -1;  
            }
        }
        //Metodos auxiliares
        private SqlCommand CrearComando(string query, SqlConnection connection, List<SqlParameter> parametros)
        {
            var cmd = new SqlCommand(query, connection);
            if (parametros != null)
            {
                cmd.Parameters.AddRange(parametros.ToArray());
            }
            return cmd;
        }

    }

}
