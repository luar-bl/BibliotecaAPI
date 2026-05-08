using ProyectoBibliotecaAPI.DTOs.Auth;

namespace ProyectoBibliotecaAPI.Servicios.Auth
{
    public interface IAuthService
    {
        //REGISTRO ES UN MÉTODO BOOL PORQUE SOLO NECESITAS SABER SI SE HA REGISTRADO BIEN O NO.
        Task<bool> RegistroAsync(RegistroDto registro);

        //LOGIN ES UN MÉTODO STRING PORQUE DEVUELVE EL JWT EN FORMATO TEXTO O NULL
        //SI LAS CREDENCIALES SON INCORRECTAS.
        Task<string?> LoginAsync(LoginDto login);
    }
}
