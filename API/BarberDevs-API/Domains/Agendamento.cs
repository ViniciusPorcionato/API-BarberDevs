using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BarberDevs_API.Domains
{
    [Table("Agendamento")]
    public class Agendamento
    {
        [Key]
        public Guid IdAgendamento { get; set; } = new Guid();

        public DateTime? DataAgendamento { get; set; }

        public DateTime? HoraAgendamento { get; set; }

        [ForeignKey("IdCliente")]
        public Cliente? Cliente { get; set; }
        public Guid IdCliente { get; set; }


        [ForeignKey("IdBarbeiro")]
        public Barbeiro? Barbeiro { get; set; }
        public Guid IdBarbeiro { get; set; }

    }
}
