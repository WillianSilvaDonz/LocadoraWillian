using LocacaoFilmes.Entidades.Locacao;
using LocacaoFilmes.Negocios.Servicos;
using LocacaoFilmes.Repositorio.EntityCore;
using System;
using System.Threading.Tasks;

namespace LocacaoFilmes.Negocios.Cadastro
{
    public class LocacaoCrudServico : CrudServico<Locacao>, ILocacaoCrudServico
    {
        private readonly ILocacaoRepositorio _repositorio;

        public LocacaoCrudServico(ILocacaoRepositorio repositorio)
            : base(repositorio)
        {
            _repositorio = repositorio;
        }

        //pode ser excluida sempre, não há tabelas que dependam
        public override bool CanDelete(long id) => true;

        public override async Task<Locacao> InserirAsync(Locacao entity)
        {
            entity.DataLocacao = DateTime.Now;

            return await base.InserirAsync(entity);
        }

        public override Locacao Alterar(Locacao entity)
        {
            var persistir = _repositorio.BuscarPorFilmeCodigo(entity.Id);

            persistir.CpfCliente = entity.CpfCliente;
            persistir.Filmes = entity.Filmes;

            return base.Alterar(persistir);
        }

        public override async Task<Locacao> BuscarPorCodigoAsync(long id)
        {
            return await _repositorio.BuscarPeloCodigoFilmesAsync(id);
        }
    }
}
