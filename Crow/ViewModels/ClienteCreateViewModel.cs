using System.ComponentModel.DataAnnotations;

namespace Crow.ViewModels
{
    public class ClienteCreateViewModel
    {
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "O nome de usuário é obrigatório")]
        [Display(Name = "Nome")]
        [StringLength(15, ErrorMessage = "O nome não pode exceder 15 caracteres")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória")]
        [MinLength(8, ErrorMessage = "A senha deve ter pelo menos 8 caracteres")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$",
            ErrorMessage = "A senha deve conter pelo menos uma letra maiúscula, uma letra minúscula, um número e um caractere especial")]
        [Display(Name = "Senha")]
        public string? SenhaHash { get; set; }

        [Required(ErrorMessage = "O email é obrigatório")]
        [Display(Name = "E-mail")]
        [EmailAddress(ErrorMessage = "Insira um endereço de E-mail válido")]
        public string? Email { get; set; }
        public DateTime DataCadastro { get; set; } = DateTime.Now;
    }
}
