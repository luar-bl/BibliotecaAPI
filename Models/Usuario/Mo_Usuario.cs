using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace ProyectoBibliotecaAPI.Models.Usuario
{
    [Table("mo_usuario")]
    public class Mo_Usuario :BaseModel
    {
        public Mo_Usuario()
        {

        }

        [PrimaryKey("oid",false)]
        public Guid Oid { get; set; }
        [Column("email")]
        public string Email { get; set; }
        [Column("passwordhash")]
        public string Password { get; set; }
    }
}
