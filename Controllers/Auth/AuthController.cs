using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc;
using ProyectoBibliotecaAPI.DTOs.Auth;
using ProyectoBibliotecaAPI.Models.Usuario;
using ProyectoBibliotecaAPI.Servicios.Auth;

namespace ProyectoBibliotecaAPI.Controllers.Auth
{
    [ApiController]
    [Route("api/v1/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authServicio;
        public AuthController(IAuthService authservicio)
        {
            _authServicio = authservicio;
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> LoginAsync(LoginDto login)
        {
            try
            {
                if (login == null ||
                string.IsNullOrWhiteSpace(login.Email) ||
                string.IsNullOrWhiteSpace(login.Password))
                {
                    return BadRequest();
                }

                var token = await _authServicio.LoginAsync(login);

                if (string.IsNullOrWhiteSpace(token))
                {
                    return Unauthorized();
                }

                return Ok(token);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("registro")]
        public async Task<ActionResult> RegistroAsync(RegistroDto registro)
        {
            try
            {
                if (registro == null ||
               string.IsNullOrWhiteSpace(registro.Email) ||
               string.IsNullOrWhiteSpace(registro.Password))
                {
                    return BadRequest();
                }

                var result = await _authServicio.RegistroAsync(registro);

                if (!result)
                {
                    return BadRequest();
                }

                return StatusCode(StatusCodes.Status201Created);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
