using LocacaoFilmes.Entidades.Cadastro;
using LocacaoFilmes.Negocios.Servicos;
using LocacaoFilmes.Repositorio.EntityCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LocacaoFilmes.Negocios.Cadastro
{
    public class FilmeCrudServico : CrudServico<Filme>, IFilmeCrudServico
    {
        protected readonly IFilmeRepositorio _repository;
        private readonly IFilmeLocacaoRepositorio _filmeLocacaoRepositorio;

        public FilmeCrudServico(IFilmeRepositorio repository, IFilmeLocacaoRepositorio filmeLocacaoRepositorio)
            : base(repository)
        {
            _repository = repository;
            _filmeLocacaoRepositorio = filmeLocacaoRepositorio;
        }

        public override bool CanDelete(long id)
        {
            var location = _filmeLocacaoRepositorio.BuscarPorCodigoFilme(id);

            return location == null;
        }

        public override List<Filme> BuscarPagina(int limit, int offset)
        {
            return _repository.BuscarPaginaComGenero(limit, offset);
        }

        public override async Task<Filme> BuscarPorCodigoAsync(long id)
        {
            return await _repository.BuscarPeloCodigoGeneroAsync(id);
        }

        public override async Task<Filme> InserirAsync(Filme entity)
        {
            entity.DataCriacao = DateTime.Now;
            return await base.InserirAsync(entity);
        }

        public override Filme Alterar(Filme entity)
        {
            var persisted = Buscar(entity.Id);

            persisted.Nome = entity.Nome;
            persisted.Ativo = entity.Ativo;
            persisted.GeneroId = entity.GeneroId;

            return base.Alterar(persisted);
        }

        public List<Filme> BuscarTodosAtivosPeloNome(string nome)
        {
            return _repository.BuscarTodosAtivosPeloNome(nome);
        }
    }
}
