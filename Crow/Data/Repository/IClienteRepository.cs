using Crow.Models;

namespace Crow.Data.Repository
{
    public interface IClienteRepository
    {
        ClienteModel? ListData(int id);
        void Add(ClienteModel cliente);
        void Update(ClienteModel cliente);
        void Delete(ClienteModel cliente);
    }
}
