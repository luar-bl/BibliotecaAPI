using ProyectoBibliotecaAPI.Models.Biblioteca;

namespace ProyectoBibliotecaAPI.DTOs.Libro
{
    public class LibroDto
    {
        public LibroDto() { }
        /// <summary>
        /// SEPARAR EN 2 DTos. ¿Por qué? Una clase es para devolver datos (response)
        /// </summary>

        public Guid Oid { get; set; }
        public required string Titulo { get; set; }
        public required string Autor { get; set; }
        public required string? Descripcion { get; set; }
        public DateTime FechaLanzamiento { get; set; }
        //public Mo_Biblioteca Biblioteca { get; set; }
    }
}
