using System.Collections.Generic;

namespace AccesoBaseDatos.ComunBD
{
    public interface IAccesoBD<T, K>
    {
        /// <summary>
        /// Método que inserta la entidad
        /// </summary>
        /// <param name="entidad">Entidad a insertar</param>
        /// <returns>Devuelve un entero en función de las filas afectadas</returns>
        T Create(T entidad);

        /// <summary>
        /// Método que inserta una lista de entidades
        /// </summary>
        /// <param name="entidadList">lkista de entidades</param>
        /// <returns>Devuelve un entero en funcion de las filas afectadas</returns>
        T MultipleCreate(List<T> entidadList);

        /// <summary>
        /// Método que devuelve listado de entidades
        /// </summary>
        /// <returns>Listado de entidad</returns>
        List<T> Select();

        /// <summary>
        /// Método que devuelve listado de entidades acorde al filtro
        /// </summary>
        /// <typeparam name="T">Entidad</typeparam>
        /// <param name="entidadFiltro">Filtro de la entidad</param>
        /// <returns>Listado de entidad</returns>
        List<T> Select(K entidadFiltro);

        /// <summary>
        /// Método que actualiza la entidad
        /// </summary>
        /// <typeparam name="T">Entidad</typeparam>
        /// <param name="entidad">Entidad a actualizar</param>
        /// <returns>Devuelve un entero en función de las filas afectadas por la query</returns>
        T Update(T entidad);

        /// <summary>
        /// Método que elimina la entidad
        /// </summary>
        /// <typeparam name="T">Entidad</typeparam>
        /// <param name="entidad">Entidad a eliminar</param>
        /// <returns>Devuelve un entero en función de las filas afectadas por la query</returns>
        T Delete(T entidad);
    }
}
