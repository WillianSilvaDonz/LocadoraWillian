using LocacaoFilmes.App.Models.Compartilhado;
using System;
using System.ComponentModel.DataAnnotations;

namespace LocacaoFilmes.App.Models.Cadastro
{
    public class GeneroCadastroModel : ViewModel
    {
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Display(Name = "Ativo")]
        public bool Ativo { get; set; }

        [Display(Name = "Data de criação")]
        public DateTime DataCriacao { get; set; }
    }
}
