namespace AccesoBaseDatos.ComunBD
{
    interface IQuery
    {
        /// <summary>
        /// Método que ejecuta query
        /// </summary>
        /// <param name="sql">Cadena instrucción sql</param>
        /// <returns>Número de filas afectadas</returns>
        int Ejecutar(string sql);
    }
}
