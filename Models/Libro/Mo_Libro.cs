using ProyectoBibliotecaAPI.Models.Biblioteca;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace ProyectoBibliotecaAPI.Models.Libro
{
    [Table("mo_libro")]
    public class Mo_Libro : BaseModel
    {
        public Mo_Libro()
        {

        }

        [PrimaryKey("oid", false)] // <- el false indica que no se manda en el INSERT
        public Guid Oid { get; set; }
        [Column("titulo")]
        public string Titulo { get; set; }
        [Column("autor")]
        public string Autor { get; set; }
        [Column("descripcion")]
        public string Descripcion { get; set; }
        [Column("fechalanzamiento")]
        public DateTime FechaLanzamiento { get; set; }
        [Column("oidbiblioteca")]
        public Guid OidBiblioteca { get; set; }
    }
}
