using System;
using System.Collections.Generic;

namespace webapi.barberdevs.Domains;

public partial class Agendamento
{
    public Guid IdAgendamento { get; set; }

    public Guid? IdBarbeiro { get; set; }

    public Guid? IdCliente { get; set; }

    public DateTime? DataAgendamento { get; set; }

    public virtual Barbeiro? IdBarbeiroNavigation { get; set; }

    public virtual Cliente? IdClienteNavigation { get; set; }
}
