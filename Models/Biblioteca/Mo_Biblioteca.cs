using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace ProyectoBibliotecaAPI.Models.Biblioteca
{
    [Table("mo_biblioteca")]
    public class Mo_Biblioteca : BaseModel
    {
        public Mo_Biblioteca()
        {

        }

        [PrimaryKey("oid", false)]
        public Guid Oid { get; set; }
        [Column("nombre")]
        public string Nombre { get; set; }
        [Column("direccion")]
        public string Direccion { get; set; }
    }
}
