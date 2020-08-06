using LocacaoFilmes.Entidades.Cadastro;
using LocacaoFilmes.Negocios.Servicos;
using LocacaoFilmes.Repositorio.EntityCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LocacaoFilmes.Negocios.Cadastro
{
    public class GeneroCrudServico : CrudServico<Genero>, IGeneroCrudServico
    {
        private readonly IGeneroRepositorio _generoRepositorio;

        private readonly IFilmeRepositorio _filmeRepositorio;

        public GeneroCrudServico(IGeneroRepositorio repositorio, IFilmeRepositorio filmeRepositorio)
            : base(repositorio)
        {
            _generoRepositorio = repositorio;
            _filmeRepositorio = filmeRepositorio;
        }

        //Verifica se pode ser excluido
        public override bool CanDelete(long id)
        {
            var movie = _filmeRepositorio.BuscarPeloCodigoGenero(id);

            return movie == null;
        }

        public override async Task<Genero> InserirAsync(Genero entity)
        {
            return await base.InserirAsync(entity);
        }


        public override Genero Alterar(Genero entity)
        {
            var persisted = Buscar(entity.Id);

            persisted.Nome = entity.Nome;
            persisted.Ativo = entity.Ativo;

            return base.Alterar(persisted);
        }


        public List<Genero> BuscarTodosAtivosPeloNome(string name)
        {
            return _generoRepositorio.BuscarTodosAtivosPeloNome(name);
        }
    }
}
