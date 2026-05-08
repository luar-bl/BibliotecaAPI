using ProyectoBibliotecaAPI.Models.Biblioteca;

namespace ProyectoBibliotecaAPI.DTOs.Libro
{
    public class CrearLibroDto
    {
        /// <summary>
        /// SEPARAR EN 2 DTos. ¿Por qué? Una clase para crear un libro (request)
        /// LAS DTO's existen para no exponer tu clase oficial, solo necesitas los campos necesarios (tema de seguridad)
        /// </summary>
        public required string Titulo { get; set; }
        public required string Autor { get; set; }
        public required string? Descripcion { get; set; }
        public required DateTime FechaLanzamiento { get; set; }
        //public Mo_Biblioteca Biblioteca { get; set; }
    }
}
