using System;
using System.Collections.Generic;

namespace webapi.barberdevs.Domains;

public partial class Cliente
{
    public Guid IdCliente { get; set; }

    public virtual ICollection<Agendamento> Agendamentos { get; set; } = new List<Agendamento>();

    public virtual Usuario IdClienteNavigation { get; set; } = null!;
}
