using System;
using System.Collections.Generic;

namespace webapi.barberdevs.Domains;

public partial class Barbeiro
{
    public Guid IdBarbeiro { get; set; }

    public Guid? IdBarbearia { get; set; }

    public string? Descricao { get; set; }

    public virtual ICollection<Agendamento> Agendamentos { get; set; } = new List<Agendamento>();

    public virtual Barbearium? IdBarbeariaNavigation { get; set; }

    public virtual Usuario IdBarbeiroNavigation { get; set; } = null!;
}
