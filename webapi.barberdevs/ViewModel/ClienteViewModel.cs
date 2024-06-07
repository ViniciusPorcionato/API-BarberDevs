using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace webapi.barberdevs.ViewModel
{
    public class ClienteViewModel
    {
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public string? Rg { get; set; }
        public string? Cpf { get; set; }
        public Guid IdTipoUsuario { get; set; }
        public string? Foto { get; set; }

        [NotMapped]
        [JsonIgnore]
        public IFormFile? Arquivo { get; set; }
    }
}
