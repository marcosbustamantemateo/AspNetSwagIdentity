using System.Configuration;

namespace AccesoBaseDatos.ComunBD
{
    public static class ConexionBD
    {
        public static string CadenaConexionBD
        {
            get
            {
                var configCnnStr = ConfigurationManager.ConnectionStrings["ConexionAnsotec"];
                return configCnnStr.ConnectionString;
            }
        }
    }
}
