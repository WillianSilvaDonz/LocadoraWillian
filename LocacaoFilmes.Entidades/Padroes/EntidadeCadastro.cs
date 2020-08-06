using System;

namespace LocacaoFilmes.Entidades.Padroes
{
    public class EntidadeCadastro : Entidade
    {
        public string Nome { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public bool Ativo { get; set; }
    }
}
