using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BarberDevs_API.Domains
{
    [Table("Barbearia")]
    public class Barbearia
    {
        [Key]
        public Guid IdBarbearia { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        public string? NomeFantasia { get; set; }

        [Column(TypeName = "INT")]
        public int CNPJ { get; set; }

        [Column(TypeName = "DECIMAL(6,2)")]
        public decimal? Latitude { get; set; }

        [Column(TypeName = "DECIMAL(6,2)")]
        public decimal? Longitude{ get; set; }

        [Column(TypeName = "INT")]
        public int Cep { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        public string? Logradouro { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        public string? Bairro { get; set; }

        [Column(TypeName = "INT")]
        public int Numero { get; set; }

    }

}
