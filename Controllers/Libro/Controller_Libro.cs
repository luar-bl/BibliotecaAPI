using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoBibliotecaAPI.DTOs.Libro;
using ProyectoBibliotecaAPI.Models.Libro;
using ProyectoBibliotecaAPI.Repositorios.Libro;
using ProyectoBibliotecaAPI.Servicios.Libro;
using Supabase.Gotrue;
using Supabase.Gotrue.Mfa;
using System.Numerics;

namespace ProyectoBibliotecaAPI.Controllers.Biblioteca
{
    [Authorize]
    [ApiController]
    [Route("api/v1/libros")] //Una ruta mas limpia...
    public class Controller_Libro: ControllerBase
    {
        private readonly ILibroService _iLibroServicio;

        public Controller_Libro(ILibroService ilibServ)
        {
            _iLibroServicio = ilibServ;
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<Mo_Libro>>> CtrlObtenerLibrosAsync()
        {
            try
            {
                var result = await _iLibroServicio.ObtenerLibrosAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("{oid}")]
        public async Task<ActionResult<LibroDto>> CtrlObtenerLibroIdAsync(Guid Oid)
        {
            try
            {
                var resLibro = _iLibroServicio.ObtenerLibroIdAsync(Oid);
                if (resLibro == null) { return NotFound(); }

                return Ok(resLibro);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }


        [HttpPost()]
        public async Task<ActionResult<LibroDto>> CtrlCrearLibroAsync([FromBody] CrearLibroDto crearLibro)
        {
            try
            {
                var resultCreacion = await _iLibroServicio.CrearLibroAsync(crearLibro);
                if(resultCreacion == null) { return BadRequest(); }

                //201 Created
                //Location: /api/v1/libros/123e4567   ← URL donde encontrar el nuevo libro
                //Body: { id, titulo, autor... }       ← el objeto completo
                return CreatedAtAction(nameof(CtrlObtenerLibroIdAsync),  // nombre del método GET por Id
                                            new { oid = resultCreacion.Oid },// parámetro para construir la URL
                                            resultCreacion); // cuerpo de la respuesta
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{oid}")]
        public async Task<ActionResult<LibroDto>> CtrlActualizarLibroAsync(Guid oid, [FromBody] CrearLibroDto crearLibro)
        {
            try
            {
                var resultActualizacion = await _iLibroServicio.ActualizarLibroAsync(oid, crearLibro);

                if (resultActualizacion == null) { return NotFound(); }

                return Ok(resultActualizacion);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{oid}")]
        public async Task<ActionResult<LibroDto>> CtrlEliminarLibroAsync(Guid oid)
        {
            try
            {
                bool resultEliminar = await _iLibroServicio.EliminarLibroAsync(oid);

                if (!resultEliminar)
                {
                    return NotFound();
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
