using Crow.Data.Repository;
using Crow.Models;

namespace Crow.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _repository;

        public ClienteService(IClienteRepository repository)
        {
            _repository = repository;
        }

        public void Atualizar(ClienteModel cliente) => _repository.Update(cliente);

        public void CriarConta(ClienteModel cliente) => _repository.Add(cliente);

        public void Deletar(int id)
        {
            var cliente = _repository.ListData(id);

            if (cliente != null) _repository.Delete(cliente);
        }

        public ClienteModel? ListarDados(int id) => _repository.ListData(id);
    }
}
