using Crow.Data.Context;
using Crow.Models;
using Microsoft.EntityFrameworkCore;

namespace Crow.Data.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly DatabaseContext _dbContext;
        public ClienteRepository(DatabaseContext context) => _dbContext = context;
        public void Add(ClienteModel cliente)
        {
            _dbContext.Cliente.Add(cliente);
            _dbContext.SaveChanges();
        }

        public void Delete(ClienteModel cliente)
        {
            _dbContext.Cliente.Remove(cliente);
            _dbContext.SaveChanges();
        }

        public ClienteModel? ListData(int id) => _dbContext.Cliente.Find(id);

        public void Update(ClienteModel cliente)
        {
            _dbContext.Cliente.Update(cliente);
            _dbContext.SaveChanges();
        }
    }
}
