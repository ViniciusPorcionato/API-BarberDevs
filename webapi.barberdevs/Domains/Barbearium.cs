using System;
using System.Collections.Generic;

namespace webapi.barberdevs.Domains;

public partial class Barbearium
{
    public Guid IdBarbearia { get; set; }

    public string? NomeFantasia { get; set; }

    public string? Cnpj { get; set; }

    public decimal? Latitude { get; set; }

    public decimal? Longitude { get; set; }

    public string? Cep { get; set; }

    public string? Logradouro { get; set; }

    public string? Bairro { get; set; }

    public string? Numero { get; set; }

    public virtual ICollection<Barbeiro> Barbeiros { get; set; } = new List<Barbeiro>();
}
