using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.IdentityModel.Tokens;
using ProyectoBibliotecaAPI.DTOs.Auth;
using ProyectoBibliotecaAPI.Models.Usuario;
using ProyectoBibliotecaAPI.Repositorios.Auth;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ProyectoBibliotecaAPI.Servicios.Auth
{
    public class AuthService : IAuthService
    {

        private readonly UsuarioRepository _usuarioRepositorio;
        private readonly IConfiguration _configuration;
        public AuthService(UsuarioRepository usuarioRepos, IConfiguration configuration)
        {
            _usuarioRepositorio = usuarioRepos;
            _configuration = configuration;
        }

        public async Task<string?> LoginAsync(LoginDto login)
        {
            try
            {
                if (login == null ||
                    string.IsNullOrWhiteSpace(login.Email) ||
                    string.IsNullOrWhiteSpace(login.Password))
                {
                    return null;
                }

                Mo_Usuario result = await _usuarioRepositorio.LoginUsuarioAsync(login.Email);

                if(result == null)
                {
                    return null;
                }

                // Verificar la password
                var hash = BCrypt.Net.BCrypt.Verify(login.Password, result.Password);

                if(!hash) { return null; }

                var token = GenerarJWT(result);

                return token;


            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> RegistroAsync(RegistroDto registro)
        {
            try
            {
                if (registro == null ||
               string.IsNullOrWhiteSpace(registro.Email) ||
               string.IsNullOrWhiteSpace(registro.Password))
                {
                    return false;
                }

                // Hashear la password
                string hash = BCrypt.Net.BCrypt.HashPassword(registro.Password);

                Mo_Usuario user = new Mo_Usuario()
                {
                    Email = registro.Email,
                    Password = hash
                };

                var result = await _usuarioRepositorio.RegistrarUsuarioAsync(user);

                return result != null;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        #region -- Métodos JWT --

        private string GenerarJWT(Mo_Usuario usuario)
        {
            //1. CLAIMS => INFORMACIÓN QUE VA DENTRO DEL TOKEN
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.Oid.ToString()),
                new Claim(ClaimTypes.Email, usuario.Email)
            };

            //2. CLAVE SECRETA
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));

            //3. FIRMA
            var credenciales = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //4. CONSTRUIR EL TOKEN
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(
                    double.Parse(_configuration["Jwt:ExpirationHours"]!)),
                signingCredentials: credenciales
                );

            //5. SERIALIZAR A STRING
            return new JwtSecurityTokenHandler().WriteToken(token);
        }


        #endregion
    }
}
