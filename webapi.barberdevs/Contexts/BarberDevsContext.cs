using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using webapi.barberdevs.Domains;

namespace webapi.barberdevs.Contexts;

public partial class BarberDevsContext : DbContext
{
    public BarberDevsContext()
    {
    }

    public BarberDevsContext(DbContextOptions<BarberDevsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Agendamento> Agendamentos { get; set; }

    public virtual DbSet<Barbearium> Barbearia { get; set; }

    public virtual DbSet<Barbeiro> Barbeiros { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<TipoUsuario> TipoUsuarios { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=NOTE13-S21; initial catalog=BarberDevs; User Id = sa; pwd = Senai@134; TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Agendamento>(entity =>
        {
            entity.HasKey(e => e.IdAgendamento).HasName("PK__Agendame__DC0823C9EC08E0AF");

            entity.ToTable("Agendamento");

            entity.Property(e => e.IdAgendamento).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DataAgendamento).HasColumnType("datetime");

            entity.HasOne(d => d.IdBarbeiroNavigation).WithMany(p => p.Agendamentos)
                .HasForeignKey(d => d.IdBarbeiro)
                .HasConstraintName("FK__Agendamen__IdBar__5BE2A6F2");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Agendamentos)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("FK__Agendamen__IdCli__5CD6CB2B");
        });

        modelBuilder.Entity<Barbearium>(entity =>
        {
            entity.HasKey(e => e.IdBarbearia).HasName("PK__Barbeari__05AE5EFF616090D8");

            entity.Property(e => e.IdBarbearia).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Bairro)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Cep)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Cnpj)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CNPJ");
            entity.Property(e => e.Latitude).HasColumnType("decimal(8, 6)");
            entity.Property(e => e.Logradouro)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Longitude).HasColumnType("decimal(9, 6)");
            entity.Property(e => e.NomeFantasia)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Numero)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Barbeiro>(entity =>
        {
            entity.HasKey(e => e.IdBarbeiro).HasName("PK__Barbeiro__E29F357C4F99367E");

            entity.ToTable("Barbeiro");

            entity.Property(e => e.IdBarbeiro).ValueGeneratedNever();
            entity.Property(e => e.Descricao).HasColumnType("text");

            entity.HasOne(d => d.IdBarbeariaNavigation).WithMany(p => p.Barbeiros)
                .HasForeignKey(d => d.IdBarbearia)
                .HasConstraintName("FK__Barbeiro__IdBarb__5535A963");

            entity.HasOne(d => d.IdBarbeiroNavigation).WithOne(p => p.Barbeiro)
                .HasForeignKey<Barbeiro>(d => d.IdBarbeiro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Barbeiro__IdBarb__5441852A");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PK__Cliente__D5946642629C1701");

            entity.ToTable("Cliente");

            entity.Property(e => e.IdCliente).ValueGeneratedNever();

            entity.HasOne(d => d.IdClienteNavigation).WithOne(p => p.Cliente)
                .HasForeignKey<Cliente>(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Cliente__IdClien__5812160E");
        });

        modelBuilder.Entity<TipoUsuario>(entity =>
        {
            entity.HasKey(e => e.IdTipoUsuario).HasName("PK__TipoUsua__CA04062B57462385");

            entity.ToTable("TipoUsuario");

            entity.Property(e => e.IdTipoUsuario).HasDefaultValueSql("(newid())");
            entity.Property(e => e.NomeTipoUsuario)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__5B65BF97B407F414");

            entity.ToTable("Usuario");

            entity.HasIndex(e => e.Email, "UQ__Usuario__A9D10534ECB231DA").IsUnique();

            entity.Property(e => e.IdUsuario).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Cpf)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Foto).HasColumnType("text");
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Rg)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Senha)
                .HasMaxLength(250)
                .IsUnicode(false);

            entity.HasOne(d => d.IdTipoUsuarioNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdTipoUsuario)
                .HasConstraintName("FK__Usuario__IdTipoU__5165187F");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
