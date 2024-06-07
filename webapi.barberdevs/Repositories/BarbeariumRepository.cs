using webapi.barberdevs.Contexts;
using webapi.barberdevs.Domains;
using webapi.barberdevs.Interfaces;

namespace webapi.barberdevs.Repositories
{
    public class BarbeariumRepository : IBarbeariumRepository
    {

        private readonly BarberDevsContext _context;

        public BarbeariumRepository()
        {
            _context = new BarberDevsContext();
        }
        public void Atualizar(Guid id, Barbearium barbearium)
        {
            try
            {
                Barbearium barbeariaBuscada = _context.Barbearia.Find(id)!;

                if (barbeariaBuscada != null)
                {
                    barbeariaBuscada.NomeFantasia = barbearium.NomeFantasia;
                    barbeariaBuscada.Cnpj = barbearium.Cnpj;
                    barbeariaBuscada.Latitude = barbearium.Latitude;
                    barbeariaBuscada.Longitude = barbearium.Longitude;
                    barbeariaBuscada.Cep = barbearium.Cep;
                    barbeariaBuscada.Logradouro = barbearium.Logradouro;
                    barbeariaBuscada.Bairro = barbearium.Bairro;
                    barbeariaBuscada.Numero = barbearium.Numero;
                }

                _context.Barbearia.Update(barbeariaBuscada!);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Barbearium BuscarPorId(Guid id)
        {
            try
            {
                return _context.Barbearia.Find(id)!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Barbearium barbearium)
        {
            try
            {
                _context.Barbearia.Add(barbearium);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Deletar(Guid id)
        {
            try
            {
                Barbearium barbeariaBuscada = _context.Barbearia.Find(id)!;

                if (barbeariaBuscada != null)
                {
                    _context.Barbearia.Remove(barbeariaBuscada);
                }

                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Barbearium> Listar()
        {
            try
            {
                return _context.Barbearia.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
