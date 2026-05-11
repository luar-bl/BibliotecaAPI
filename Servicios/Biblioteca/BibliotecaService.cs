using ProyectoBibliotecaAPI.DTOs.Biblioteca;
using ProyectoBibliotecaAPI.Models.Biblioteca;
using ProyectoBibliotecaAPI.Repositorios.Biblioteca;

namespace ProyectoBibliotecaAPI.Servicios.Biblioteca
{
    public class BibliotecaService : IBibliotecaService
    {

        #region -- Propiedades --

        private readonly BibliotecaRepository _bibliotecaRepositorio;

        #endregion

        public BibliotecaService(BibliotecaRepository bibliotecaRepositorio)
        {
            _bibliotecaRepositorio = bibliotecaRepositorio;
        }

        #region -- Métodos --
        public async Task<BibliotecaDto?> ActualizarBiliotecaAsync(Guid oid, CrearBibliotecaDto actualizarBiblio)
        {
            if (actualizarBiblio == null)
            {
                return null;
            }

            Mo_Biblioteca obtenerBiblio = await _bibliotecaRepositorio.ObtenerBibliotecaIdAsync(oid);

            if (obtenerBiblio == null)
            {
                return null;
            }

            var result = await _bibliotecaRepositorio.ActualizarBibliotecaAsync(obtenerBiblio);

            return new BibliotecaDto()
            {
                Oid = result.Oid,
                Nombre = result.Nombre,
                Descripcion = result.Direccion
            };
        }

        public async Task<BibliotecaDto?> CrearBibliotecaAsync(BibliotecaDto nuevaBiblio)
        {
            throw new NotImplementedException();
        }

        public async Task EliminarLibroAsync(Guid oid)
        {
            throw new NotImplementedException();
        }

        public async Task<BibliotecaDto?> ObtenerLibroIdAsync(Guid oid)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<BibliotecaDto>> ObtenerLibrosAsync()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
