using LocacaoFilmes.Entidades.Cadastro;
using LocacaoFilmes.Entidades.Padroes;

namespace LocacaoFilmes.Entidades.Relacionamento
{
    public class FilmeLocacao : Entidade
    {
        public long FilmeId { get; set; }
        public Filme Filme { get; set; }
        public long LocacaoId { get; set; }
        public Locacao.Locacao Locacao { get; set; }
    }
}
