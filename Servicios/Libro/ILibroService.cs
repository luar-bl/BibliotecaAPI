using ProyectoBibliotecaAPI.DTOs.Libro;
using ProyectoBibliotecaAPI.Models.Libro;

namespace ProyectoBibliotecaAPI.Servicios.Libro
{
    public interface ILibroService
    {
        Task<IEnumerable<LibroDto>> ObtenerLibrosAsync();
        Task<LibroDto?> ObtenerLibroIdAsync(Guid Oid);
        Task<LibroDto?> CrearLibroAsync(CrearLibroDto libro);
        Task<LibroDto?> ActualizarLibroAsync(Guid Oid, CrearLibroDto crearLibro);
        Task<bool> EliminarLibroAsync(Guid Oid);
    }
}
