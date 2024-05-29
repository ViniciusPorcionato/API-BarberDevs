using BarberDevs_API.Domains;
using Microsoft.EntityFrameworkCore;

namespace BarberDevs_API.Contexts
{
    public class BarberDevsContext : DbContext
    {

        public BarberDevsContext()
        {
        }

        public BarberDevsContext(DbContextOptions<BarberDevsContext> options) : base(options) { }


        public  DbSet<Usuario> Usuario { get; set; }
        public  DbSet<Barbearia> Barbearia { get; set; }
        public  DbSet<Cliente> Cliente { get; set; }
        public  DbSet<Barbeiro> Barbeiro { get; set; }
        public  DbSet<Agendamento> Agendamento { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = NOTE17-S21\\SQLSERVER; Database = BarberDevs; User Id = sa; pwd = Senai@134; TrustServerCertificate = True;");
            base.OnConfiguring(optionsBuilder);

        }
    }
}
