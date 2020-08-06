using LocacaoFilmes.Entidades.Padroes;
using LocacaoFilmes.Entidades.Relacionamento;
using System;
using System.Collections.Generic;

namespace LocacaoFilmes.Entidades.Locacao
{
    public class Locacao : Entidade
    {
        public string CpfCliente { get; set; }
        public DateTime DataLocacao { get; set; }
        public virtual ICollection<FilmeLocacao> Filmes { get; set; }
        
    }
}
