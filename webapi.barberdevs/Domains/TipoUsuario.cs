using System;
using System.Collections.Generic;

namespace webapi.barberdevs.Domains;

public partial class TipoUsuario
{
    public Guid IdTipoUsuario { get; set; }

    public string? NomeTipoUsuario { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
