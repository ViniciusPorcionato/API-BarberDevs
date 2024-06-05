using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BarberDevs_API.Domains
{
    [Table("Barbeiro")]
    public class Barbeiro
    {
        [Key]
        public Guid IdBarbeiro { get; set; } = Guid.NewGuid();

        [Column(TypeName = "INT")]
        public int Rg { get; set; }

        [Column(TypeName = "INT")]
        public int Cpf { get; set; }

        [Column(TypeName = "TEXT")]
        public string? Descricao { get; set; }

        //Chave referencia Barbearia
        [ForeignKey("IdBarbearia")]
        public Barbearia? Barbearia { get; set; }

        public virtual ICollection<Agendamento> Agendamento { get; set; } = new List<Agendamento>();

        public virtual Usuario? UsuarioBarbeiro { get; set; } = null!;

    }
}
