using LocacaoFilmes.App.Models.Compartilhado;
using System;
using System.ComponentModel.DataAnnotations;

namespace LocacaoFilmes.App.Models.Cadastro
{
    public class FilmeViewModel : ViewModel
    {
        [Display(Name = "Genêro")]
        public long GeneroId { get; set; }

        [Display(Name = "Genêro")]
        public string GeneroNome { get; set; }

        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Display(Name = "Ativo")]
        public bool Ativo { get; set; }

        [Display(Name = "Data de criação")]
        public DateTime DataCriacao { get; set; }
    }
}
