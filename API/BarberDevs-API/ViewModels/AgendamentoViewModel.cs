namespace BarberDevs_API.ViewModels
{
    public class AgendamentoViewModel
    {
        public Guid? IdCliente { get; set; }

        public Guid? IdBarbeiro { get; set; }

        public DateTime?  DataAgendamento{ get; set; }

        public DateTime? HoraAgendamento { get; set; }


    }
}
