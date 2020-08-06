using AutoMapper;
using LocacaoFilmes.App.Models.Compartilhado;
using LocacaoFilmes.Entidades.Padroes;
using LocacaoFilmes.Negocios.Servicos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Framework.Controllers
{

    //controller genérico deve ser herdado nunca instanciado diretamente por isso foi colocado o abstract
    //possui todas as operações necessárias para um crud básico
    //optei por usar ViewModel pq as vezes é necessário passar valores para a view as quais não pertencem ao domain
    public abstract class CrudController<TEntity, TViewModel, TCadastroModel> : Controller
        where TEntity : Entidade
        where TViewModel : ViewModel
        where TCadastroModel: ViewModel
    {
        protected readonly IMapper _mapper;

        protected readonly ICrudServico<TEntity> _service;

        public CrudController(IMapper mapper, ICrudServico<TEntity> service)
        {
            _mapper = mapper;
            _service = service;
        }

        //listagem e paginação
        public virtual IActionResult Index(int page = 1)
        {
            var paginaViewModel = new PaginaViewModel<TViewModel>() { Pagina = page };

            var list = _service.BuscarPagina(paginaViewModel.Limite, paginaViewModel.Offset);

            paginaViewModel.Lista = _mapper.Map<List<TViewModel>>(list);

            return View(paginaViewModel);
        }

        //Detalhes da entidade trazendo as ligações que precisa.
        public virtual async Task<IActionResult> Details(long id)
        {
            var entity = await _service.BuscarPorCodigoAsync(id);

            return View(_mapper.Map<TViewModel>(entity));
        }

        //página com formulário para cadastro
        public virtual IActionResult Create()
        {
            return View();
        }

        //requesicao post para cadastrar os dados.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<IActionResult> Create(TCadastroModel viewModel)
        {
            if (ModelState.IsValid)
            {
                await _service.InserirAsync(_mapper.Map<TEntity>(viewModel));

                return RedirectToAction(nameof(Index));
            }

            return View(viewModel);
        }

        //buscar os dados para alterar assim abrindo a tela de edicao
        public virtual async Task<IActionResult> Edit(long id)
        {
            var entity = await _service.BuscarPorCodigoAsync(id);

            return View(_mapper.Map<TViewModel>(entity));
        }

        //requesição post para alterar os dados.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual IActionResult Edit(long id, TCadastroModel viewModel)
        {
            if (id != viewModel.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _service.Alterar(_mapper.Map<TEntity>(viewModel));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GeneroExists(viewModel.Id)) return NotFound();
                    else throw;
                }

                return RedirectToAction(nameof(Index));
            }

            return View(viewModel);
        }

        //partir daqui sao funcoes padrao de deletar os itens do crud.
        public virtual async Task<IActionResult> Delete(long id)
        {
            var entity = await _service.BuscarPorCodigoAsync(id);

            var viewModel = _mapper.Map<TViewModel>(entity);
            viewModel.CanDelete = _service.CanDelete(id);

            return View(viewModel);
        }

        
        [HttpPost]
        public virtual IActionResult DeletaTodos(long[] ids)
        {
            if (!ids.Any()) return RedirectToAction(nameof(Index));

            var viewModels = _mapper.Map<List<TViewModel>>(_service.GetAllById(ids));

            viewModels.ForEach(v => v.CanDelete = _service.CanDelete(v.Id));

            return View(viewModels);
        }

        
        [HttpPost]
        public virtual IActionResult DeleteManyConfirmed(long[] ids)
        {
            foreach (var id in ids)
            {
                if (_service.CanDelete(id))
                {
                    _service.Deletar(id);
                }
            }

            return RedirectToAction(nameof(Index));
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public virtual IActionResult DeleteConfirmed(long id)
        {
            if (_service.CanDelete(id))
            {
                _service.Deletar(id);

                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Delete), new { id });
        }

        //verifica pelo id se o objeto existe
        private bool GeneroExists(long id)
            => _service.Existe(id);
    }
}