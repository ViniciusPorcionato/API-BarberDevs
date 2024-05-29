using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BarberDevs_API.Domains
{
    [Table("Usuario")]
    [Index(nameof(Email), IsUnique = true)]
    public class Usuario
    {
        [Key]
        public Guid IdUsuario { get; set; } = new Guid();

        [Column(TypeName = "VARCHAR(200)")]
        [Required(ErrorMessage = "O campo email é obrigatório!")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "O campo senha é obrigatório!")]
        [Column(TypeName = "VARCHAR(100)")]
        [StringLength(65, MinimumLength = 4, ErrorMessage = "A senha é de 4 a 65 caracteres")]
        public string? Senha { get; set; }


        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O campo nome é obrigatório!")]
        public string? Nome { get; set; }

        //public virtual Cliente? Cliente { get; set; }

        //public virtual Barbeiro? Barbeiro { get; set; }

    }
}
