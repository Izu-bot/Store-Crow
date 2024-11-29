using Crow.Models;

namespace Crow.Services
{
    public interface IClienteService
    {
        ClienteModel? ListarDados(int id);
        void CriarConta(ClienteModel cliente);
        void Atualizar(ClienteModel cliente);
        void Deletar(int id);
    }
}
