using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BarberDevs_API.ViewModels
{
    public class ClienteViewModel
    {
        //dados de usuario
        public string? Nome { get; set; }
        //dados de usuario
        public string? Email { get; set; }
        //dados de usuario
        public string? Senha { get; set; }
        //dados de usuario
        public string? Foto { get; set; }

        public int Rg { get; set; }

        public int Cpf { get; set; }

        public Guid? IdCliente { get; set; }

        [JsonIgnore]
        [NotMapped]
        public IFormFile? Arquivo { get; set; }

    }
}
