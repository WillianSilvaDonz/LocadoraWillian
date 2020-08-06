using LocacaoFilmes.Entidades.Cadastro;
using LocacaoFilmes.Entidades.Locacao;
using LocacaoFilmes.Entidades.Relacionamento;
using LocacaoFilmes.Negocios.Cadastro;
using LocacaoFilmes.Repositorio.EntityCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace LocacaoFilmes.Testes.Negocios
{
    public class LocacaoCrudServicoTeste
    {
        private async Task<Locacao> GerarLocacaoPadrao()
        {
            return new Locacao()
            {
                CpfCliente = "081.895.689-57",
                DataLocacao = DateTime.Now,
                Id = 1,
                Filmes = GerarFilmeLocacao(),
            };
        }

        private List<FilmeLocacao> GerarFilmeLocacao()
        {
            var listaFilmeLocacao = new List<FilmeLocacao>();
            listaFilmeLocacao.Add(new FilmeLocacao
            {
                FilmeId = 1,
                LocacaoId = 1,
                Filme = new Filme()
                {
                    Ativo = true,
                    GeneroId = 1,
                    Nome = "Filme Teste Unitario",
                }
            });

            return listaFilmeLocacao;
        }

        [Fact]
        public void BuscarPorCodigoAsyncVerificaNaoNulo()
        {
            var mockRepositorio = new Mock<ILocacaoRepositorio>();

            mockRepositorio.Setup(x => x.BuscarPeloCodigoFilmesAsync(1)).Returns(GerarLocacaoPadrao());

            var locacaoCrud = new LocacaoCrudServico(mockRepositorio.Object);
            var dadosLocacao = locacaoCrud.BuscarPorCodigoAsync(1);
            Assert.NotNull(dadosLocacao.Result);
        }

        [Fact]
        public void BuscarPorCodigoAsyncVerificaNulo()
        {
            var mockRepositorio = new Mock<ILocacaoRepositorio>();

            mockRepositorio.Setup(x => x.BuscarPeloCodigoFilmesAsync(1)).Returns(GerarLocacaoPadrao());

            var locacaoCrud = new LocacaoCrudServico(mockRepositorio.Object);
            var dadosLocacao = locacaoCrud.BuscarPorCodigoAsync(2);
            Assert.Null(dadosLocacao.Result);
        }
    }
}
