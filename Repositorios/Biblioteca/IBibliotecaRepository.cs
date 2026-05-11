using ProyectoBibliotecaAPI.Models.Biblioteca;

namespace ProyectoBibliotecaAPI.Repositorios.Biblioteca
{
    public interface IBibliotecaRepository
    {
        Task<Mo_Biblioteca?> CrearBibliotecaAsync(Mo_Biblioteca nuevaBiblio);
        Task<IEnumerable<Mo_Biblioteca>> ObtenerBibliotecasAsync();
        Task EliminarBibliotecaAsync(Guid oid);
        Task<Mo_Biblioteca?> ActualizarBibliotecaAsync(Mo_Biblioteca editarBiblioteca);
        Task<Mo_Biblioteca?> ObtenerBibliotecaIdAsync(Guid oid);

    }
}
