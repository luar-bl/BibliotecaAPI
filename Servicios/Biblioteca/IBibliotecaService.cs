using ProyectoBibliotecaAPI.DTOs.Biblioteca;

namespace ProyectoBibliotecaAPI.Servicios.Biblioteca
{
    public interface IBibliotecaService
    {
        //CREAR
        Task<BibliotecaDto?> CrearBibliotecaAsync(BibliotecaDto nuevaBiblio);
        //ACTUALIZAR
        Task<BibliotecaDto?> ActualizarBiliotecaAsync(Guid oid, CrearBibliotecaDto actualizarBiblio);
        //LISTADO
        Task<IEnumerable<BibliotecaDto>> ObtenerLibrosAsync();
        //ELIMINAR
        Task EliminarLibroAsync(Guid oid);
        //OBTENER POR OID
        Task<BibliotecaDto?> ObtenerLibroIdAsync(Guid oid);
    }
}
