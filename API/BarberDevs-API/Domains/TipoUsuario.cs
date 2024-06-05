using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BarberDevs_API.Domains
{
    public class TipoUsuario
    {
        [Key]
        public Guid IdTipoUsuario { get; set; } = new Guid();

        [Column(TypeName = "VARCHAR(200)")]
        public string? NomeTipoUsuario { get; set; }
    }
}
