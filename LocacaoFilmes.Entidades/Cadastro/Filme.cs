using LocacaoFilmes.Entidades.Padroes;
using LocacaoFilmes.Entidades.Relacionamento;
using System.Collections.Generic;

namespace LocacaoFilmes.Entidades.Cadastro
{
    public class Filme : EntidadeCadastro
    {
        public long GeneroId { get; set; }

        public Genero Genero { get; set; }

        public virtual ICollection<FilmeLocacao> Locacoes { get; set; }
    }
}
