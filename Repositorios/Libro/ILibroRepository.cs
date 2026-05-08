using Microsoft.AspNetCore.Mvc;
using ProyectoBibliotecaAPI.Models.Libro;

namespace ProyectoBibliotecaAPI.Repositorios.Libro
{
    public interface ILibroRepository
    {
        Task<IEnumerable<Mo_Libro>> ObtenerLibrosAsync();
        Task<Mo_Libro?> ObtenerLibroIdAsync(Guid Oid);
        Task<Mo_Libro?> CrearLibroAsync(Mo_Libro libro);
        Task<Mo_Libro> ActualizarLibroAsync(Mo_Libro libroEditado);
        Task EliminarLibroAsync(Guid Oid);
    }
}
