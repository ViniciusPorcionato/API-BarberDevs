using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using IndexAttribute = Microsoft.EntityFrameworkCore.IndexAttribute;

namespace BarberDevs_API.Domains
{
    [Table("Cliente")]
    [Index(nameof(Rg), IsUnique = true)]
    [Index(nameof(Cpf), IsUnique = true)]
    public class Cliente
    {

        //Chave referencia Tipo de Usuario
        [ForeignKey("IdUsuario")]
        public Usuario? Usuario { get; set; }

        [Key]
        public Guid IdCliente { get; set; } = new Guid();

        [Column(TypeName = "INT")]
        public int Rg { get; set; }

        [Column(TypeName = "INT")]
        public int Cpf { get; set; }

        public virtual ICollection<Agendamento> Agendamento { get; set; } = new List<Agendamento>();
        public virtual Usuario? UsuarioCliente { get; set; } = null!;
    }
}
