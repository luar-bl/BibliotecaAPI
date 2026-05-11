using ProyectoBibliotecaAPI.Models.Biblioteca;

namespace ProyectoBibliotecaAPI.Repositorios.Biblioteca
{
    public class BibliotecaRepository : IBibliotecaRepository
    {
        private readonly Supabase.Client _supabasaClient;

        public BibliotecaRepository(Supabase.Client supabasaClient)
        {
            _supabasaClient = supabasaClient;
        }

        /// <summary>
        /// ACTUALIZAR UNA BIBLIOTECA EXISTENTE
        /// </summary>
        /// <param name="editarBiblioteca"></param>
        /// <returns></returns>
        public async Task<Mo_Biblioteca?> ActualizarBibliotecaAsync(Mo_Biblioteca editarBiblioteca)
        {
            if (editarBiblioteca == null)
            {
                return null;
            }

            var result = await _supabasaClient.From<Mo_Biblioteca>()
                                              .Where(x => x.Oid == editarBiblioteca.Oid)
                                              .Update(editarBiblioteca);

            if (result == null)
            {
                return null;
            }

            return result.Models.FirstOrDefault();
        }

        /// <summary>
        /// AÑADIR UNA NUEVA BIBLIOTECA
        /// </summary>
        /// <param name="nuevaBiblio"></param>
        /// <returns></returns>
        public async Task<Mo_Biblioteca?> CrearBibliotecaAsync(Mo_Biblioteca nuevaBiblio)
        {
            if (nuevaBiblio == null)
            {
                return null;
            }

            var result = await _supabasaClient.From<Mo_Biblioteca>().Insert(nuevaBiblio);

            return result.Models.FirstOrDefault();
        }

        /// <summary>
        /// ELIMINAR UNA BIBLIOTECA
        /// </summary>
        /// <param name="oid"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task EliminarBibliotecaAsync(Guid oid)
        {
            if (oid == Guid.Empty)
            {
                return;
            }

            await _supabasaClient.From<Mo_Biblioteca>()
                                 .Where(x => x.Oid == oid)
                                 .Delete();
        }

        /// <summary>
        /// DEVOLVER BIBLIOTECA POR ID
        /// </summary>
        /// <param name="oid"></param>
        /// <returns></returns>
        public async Task<Mo_Biblioteca?> ObtenerBibliotecaIdAsync(Guid oid)
        {
            if (oid == Guid.Empty)
            {
                return null;
            }

            var result = await _supabasaClient.From<Mo_Biblioteca>()
                                              .Where(x => x.Oid == oid)
                                              .Single() ?? null;
         
            return result;
        }



        public async Task<IEnumerable<Mo_Biblioteca>> ObtenerBibliotecasAsync()
        {
            var result = await _supabasaClient.From<Mo_Biblioteca>().Get();

            return result.Models;
        }
    }
}
