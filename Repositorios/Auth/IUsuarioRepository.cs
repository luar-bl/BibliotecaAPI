using ProyectoBibliotecaAPI.Models.Usuario;

namespace ProyectoBibliotecaAPI.Repositorios.Auth
{
    public interface IUsuarioRepository
    {
        Task<Mo_Usuario?> RegistrarUsuarioAsync(Mo_Usuario newUsuario);
        Task<Mo_Usuario?> LoginUsuarioAsync(string email);
        Task<bool> ExisteUsuarioAsync(Mo_Usuario usuario);
    }
}
