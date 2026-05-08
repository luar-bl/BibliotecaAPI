using ProyectoBibliotecaAPI.DTOs.Libro;
using ProyectoBibliotecaAPI.Models.Libro;
using ProyectoBibliotecaAPI.Repositorios.Libro;

namespace ProyectoBibliotecaAPI.Servicios.Libro
{
    public class LibroService : ILibroService
    {

        #region -- Propiedades --

        private readonly LibroRepository _libroRepository;

        #endregion

        #region  -- Constructor -- 
        public LibroService(LibroRepository libroRepos)
        {
            _libroRepository = libroRepos;
        }

        #endregion

        /// <summary>
        /// Actualizamos los valores del libro
        /// </summary>
        /// <param name="Oid"></param>
        /// <param name="crearLibro"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<LibroDto?> ActualizarLibroAsync(Guid Oid, CrearLibroDto crearLibro)
        {
            Mo_Libro libro = new Mo_Libro()
            {
                Oid = Oid,
                Autor = crearLibro.Autor,
                Descripcion = crearLibro.Descripcion,
                Titulo = crearLibro.Titulo,
                FechaLanzamiento = crearLibro.FechaLanzamiento
                //OidBiblioteca = 
            };

            var result = await _libroRepository.ActualizarLibroAsync(libro);

            if(result == null) { return null; }

            return new LibroDto() 
            { 
                Oid = result.Oid,
                Titulo = result.Titulo,
                Autor = result.Autor,
                Descripcion = result.Descripcion,
                FechaLanzamiento = result.FechaLanzamiento,
            };
        }

        public async Task<LibroDto?> CrearLibroAsync(CrearLibroDto libro)
        {
            Mo_Libro nuevoLibro = new Mo_Libro()
            {
                Titulo = libro.Titulo,
                Autor = libro.Autor,
                Descripcion = libro.Descripcion,
                FechaLanzamiento = libro.FechaLanzamiento,
                //OidBiblioteca
            };

            var result = await _libroRepository.CrearLibroAsync(nuevoLibro);

            if (result == null) { return null; }

            return new LibroDto()
            {
                Oid = result.Oid,
                Titulo = result.Titulo,
                Autor = result.Autor,
                Descripcion = result.Descripcion,
                FechaLanzamiento = result.FechaLanzamiento,
            };
        }

        public async Task<bool> EliminarLibroAsync(Guid Oid)
        {
            //primero se comprueba que exista
            var libro = await _libroRepository.ObtenerLibroIdAsync(Oid);

            if(libro == null) { return false; }

            await _libroRepository.EliminarLibroAsync(Oid);

            return true;

        }

        public async Task<LibroDto?> ObtenerLibroIdAsync(Guid Oid)
        {
            var result = await _libroRepository.ObtenerLibroIdAsync(Oid);

            if (result == null) { return null; }

            return new LibroDto()
            {
                Oid = result.Oid,
                Autor = result.Autor,
                Descripcion = result.Descripcion,
                Titulo = result.Titulo,
                FechaLanzamiento = result.FechaLanzamiento
            };
        }

        public async Task<IEnumerable<LibroDto>> ObtenerLibrosAsync()
        {
            var lstLibros = await _libroRepository.ObtenerLibrosAsync();
            return lstLibros.Select(x => new LibroDto()
            { 
                Oid = x.Oid,
                Titulo = x.Titulo,
                Autor = x.Autor,
                Descripcion = x.Descripcion,
                FechaLanzamiento = x.FechaLanzamiento,
                //Biblioteca
            });
        }
    }
}
