using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp.DAL.Contrato
{
    public interface IDbConexionFactory : IDisposable
    {
        SqlConnection GetConnection();
        bool EjecutarComandosSinRetornoDatos(string query, List<SqlParameter> parametros);
        DataSet EjecutarSentenciaSql(SqlCommand sqlCommand);
        DataSet EjecutarSentenciaSql(string query, List<SqlParameter> parametros);
        bool EjecutarSPSinRetornoDatos(string strCmd, List<SqlParameter> parametros);
        int EjecutarComandosScopeIdentity(string strCmd, List<SqlParameter> parametros);
    }
}
