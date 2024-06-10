using System;
using System.Collections.Generic;

namespace webapi.barberdevs.Domains;

public partial class Usuario
{
    public Guid IdUsuario { get; set; }

    public Guid? IdTipoUsuario { get; set; }

    public string Nome { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Senha { get; set; } = null!;

    public string? Foto { get; set; }

    public string? Rg { get; set; }

    public string? Cpf { get; set; }

    public int? CodRecupSenha { get; set; }

    public virtual Barbeiro? Barbeiro { get; set; }

    public virtual Cliente? Cliente { get; set; }

    public virtual TipoUsuario? IdTipoUsuarioNavigation { get; set; }
}
