using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace webapi.barberdevs.ViewModel
{
    public class UsuarioViewModel
    {
        [NotMapped]
        [JsonIgnore]
        public IFormFile? Arquivo { get; set; }

        public string? Foto { get; set; }
    }
}
