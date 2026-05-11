using ProyectoBibliotecaAPI.Models.Usuario;

namespace ProyectoBibliotecaAPI.Repositorios.Auth
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly Supabase.Client _supabaseClient;

        public UsuarioRepository(Supabase.Client supBasCli)
        {
            _supabaseClient = supBasCli;
        }


        public async Task<bool> ExisteUsuarioAsync(Mo_Usuario user)
        {
            var existe = await _supabaseClient.From<Mo_Usuario>()
                                               .Where(x => x.Email == user.Email).Single();

            //DEVUELVE TRUE OR FALSE.
            return existe != null;
        }

        public async Task<Mo_Usuario?> LoginUsuarioAsync(string email)
        {
            var obtenerUsuarioBBDD = await _supabaseClient.From<Mo_Usuario>()
                                                    .Where(x => x.Email == email)
                                                    .Single();
            return obtenerUsuarioBBDD;
        }

        public async Task<Mo_Usuario?> RegistrarUsuarioAsync(Mo_Usuario newUsuario)
        {
            //COMPROBAR SI EXISTE EL USUARIO CON EL EMAIL
            var existeUsuario = await ExisteUsuarioAsync(newUsuario);
            //SI EXISTE, DEVOLVER "NULL"
            if(existeUsuario) { return null; }

            //ALTA USUARIO
            var altaUsuario = await _supabaseClient.From<Mo_Usuario>().Insert(newUsuario);

            return altaUsuario.Models.FirstOrDefault();
            
        }
    }
}
