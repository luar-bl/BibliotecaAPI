using ProyectoBibliotecaAPI.DTOs.Auth;

namespace ProyectoBibliotecaAPI.Servicios.Auth
{
    public class AuthService : IAuthService
    {
        public async Task<string?> LoginAsync(LoginDto login)
        {
            try
            {
                
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> RegistroAsync(RegistroDto registro)
        {
            throw new NotImplementedException();
        }
    }
}
