using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocacaoFilmes.App.Models.Compartilhado
{
    public class PaginaViewModel<TViewModel>
        where TViewModel : ViewModel
    {
        public int Pagina { get; set; } = 1;

        public int PaginaAnterior { get => Pagina == 1 ? Pagina : Pagina - 1; }

        public int ProximaPagina { get => Pagina + 1; }

        public int Limite { get; set; } = 5;

        public int Offset { get => (Pagina - 1) * Limite; }

        public bool TemProximaPagina { get => Lista.Count() == Limite; }

        public bool TemPaginaAnterior { get => Pagina > 1; }

        public List<TViewModel> Lista { get; set; }
    }
}
