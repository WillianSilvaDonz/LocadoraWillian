using LocacaoFilmes.App.Models.Compartilhado;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LocacaoFilmes.App.Models.Cadastro
{
    public class LocacaoViewModel : ViewModel
    {
        [Display(Name = "CPF")]
        public string CpfCliente { get; set; }

        [Display(Name = "Filmes")]
        public long[] FilmesId { get; set; }

        [Display(Name = "Data da locação")]
        public DateTime DataLocacao { get; set; }

        public IEnumerable<FilmeViewModel> Filmes { get; set; }
    }
}
