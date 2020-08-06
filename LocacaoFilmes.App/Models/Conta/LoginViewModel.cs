using System.ComponentModel.DataAnnotations;

namespace LocacaoFilmes.App.Models.Conta
{
    public class LoginViewModel
    {
        [Required, EmailAddress, Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required, DataType(DataType.Password), Display(Name = "Senha")]
        public string Password { get; set; }

        [Display(Name = "Mantenha-me conectado")]
        public bool RememberMe { get; set; }
    }
}
