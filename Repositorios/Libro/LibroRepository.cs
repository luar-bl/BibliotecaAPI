using ProyectoBibliotecaAPI.Models.Libro;

namespace ProyectoBibliotecaAPI.Repositorios.Libro
{
    public class LibroRepository : ILibroRepository
    {
        #region -- Propiedades --

        private readonly Supabase.Client _supabaseClient;

        #endregion

        #region -- Constructor --
        public LibroRepository(Supabase.Client _supbasClient)
        {
            _supabaseClient = _supbasClient;
        }

        #endregion


        #region -- Métodos --

        /// <summary>
        /// Actualizamos los valores de un libro
        /// </summary>
        /// <param name="libroEditado"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Mo_Libro?> ActualizarLibroAsync(Mo_Libro libroEditado)
        {
            //COMPROBAR VALOR NULL.
            if(libroEditado == null)
            {
                return null;
            }

            //COMPROBAMOS QUE EXISTA EN LA BBDD Y ACTUALIZA VALORES.
            var result = await _supabaseClient.From<Mo_Libro>()
                                             .Where(l => l.Oid == libroEditado.Oid)
                                             .Update(libroEditado);
            //SI NO EXISTE RETURN...
            if (result == null)
            {
                return null;
            }

            return result.Models.FirstOrDefault();
        }

        /// <summary>
        /// DAR DE ALTA UN LIBRO
        /// </summary>
        /// <param name="Libro"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Mo_Libro?> CrearLibroAsync(Mo_Libro libro)
        {
            //COMPROBAR SI ES NULL
            if (libro == null)
            {
                return null;
            }
            //INSERTAR LIBRO
            var result = await _supabaseClient.From<Mo_Libro>().Insert(libro);
            //DEVOLVER LIBRO
            return result.Models.FirstOrDefault();
        }

        /// <summary>
        /// ELIMINA UN LIBRO POR OID
        /// </summary>
        /// <param name="Oid"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task EliminarLibroAsync(Guid Oid)
        {
            //ELIMINAR LIBRO
            await _supabaseClient.From<Mo_Libro>()
                                 .Where(x => x.Oid == Oid)
                                 .Delete();
        }

        /// <summary>
        /// ¿CAMBIAR NOMBRE? OBTENEMOS UN LIBRO Y/O PODRIAMOS TENER EL DETALLE DE UN LIBRO MASTER-DETAILVIEW.
        /// </summary>
        /// <param name="Oid"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Mo_Libro?> ObtenerLibroIdAsync(Guid Oid)
        {
            Mo_Libro libro = await _supabaseClient.From<Mo_Libro>()
                                        .Where(x => x.Oid == Oid)
                                        .Single();

            return libro;
        }

        /// <summary>
        /// LISTAR LOS LIBROS...
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<IEnumerable<Mo_Libro>> ObtenerLibrosAsync()
        {
            var lstLibros = await _supabaseClient.From<Mo_Libro>().Get();
            return lstLibros.Models;
        }

        #endregion
    }
}
