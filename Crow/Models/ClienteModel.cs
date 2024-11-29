namespace Crow.Models
{
    public class ClienteModel
    {
        public int ClienteId { get; set; }
        public string? Nome { get; set; }
        public string? SenhaHash { get; set; }
        public string? Email { get; set; }
        public string Role { get; set; } = "Default";
        public DateTime DataCadastro { get; set; } = DateTime.Now;
    }
}
