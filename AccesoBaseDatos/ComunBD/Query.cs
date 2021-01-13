using System;
using System.Data.SqlClient;

namespace AccesoBaseDatos.ComunBD
{
    public class Query : IQuery
    {
        private static Query _instance = null;
        private static readonly object padlock = new object();
        public static Query GetInstance()
        {
            if (_instance == null)
            {
                lock (padlock)
                {
                    if (_instance == null)
                    {
                        _instance = new Query();
                    }
                }
            }
            return _instance;
        }

        public int Ejecutar(string sql)
        {
            int respuesta = 0;
            using (var connection = new SqlConnection(ConexionBD.CadenaConexionBD))
            {
                try
                {
                    connection.Open();
                    var command = new SqlCommand(sql, connection);
                    respuesta = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    return respuesta;
                }
                finally
                {
                    connection.Close();
                }
                return respuesta;
            }
        }
    }
}
