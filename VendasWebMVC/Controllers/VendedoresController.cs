using Microsoft.AspNetCore.Mvc;
using VendasWebMVC.Models;
using VendasWebMVC.Models.ViewsModels;
using VendasWebMVC.Services;

namespace VendasWebMVC.Controllers
{
    public class VendedoresController : Controller
    {
        private readonly VendedorService _vendedoresService;
        private readonly DepartamentoService _departamentoService;

        public VendedoresController(VendedorService vendedorService, DepartamentoService departamentoService)
        {
            _vendedoresService = vendedorService;
            _departamentoService = departamentoService;
        }

        public IActionResult Index()
        {
            var list = _vendedoresService.BuscarTodos();
            return View(list);
        }

        public IActionResult Criar()
        {
            var departamentos = _departamentoService.FindAll();
            var viewModel = new VendedorFormViewModel { Departamentos = departamentos };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Criar(Vendedor vendedor)
        {
            _vendedoresService.Inserir(vendedor);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Deletar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var obj = _vendedoresService.BuscarId(id.Value);

            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Deletar(int id)
        {
            _vendedoresService.Remover(id);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Detalhar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var obj = _vendedoresService.BuscarId(id.Value);

            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
    }
}
