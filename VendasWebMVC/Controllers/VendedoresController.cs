using Microsoft.AspNetCore.Mvc;
using VendasWebMVC.Models;
<<<<<<< HEAD
using VendasWebMVC.Models.ViewsModels;
=======
>>>>>>> aac1a996cf27aaff57e41c16a07fc619bc675f3e
using VendasWebMVC.Services;

namespace VendasWebMVC.Controllers
{
    public class VendedoresController : Controller
    {
        private readonly VendedorService _vendedoresService;
<<<<<<< HEAD
        private readonly DepartamentoService _departamentoService;

        public VendedoresController(VendedorService vendedorService, DepartamentoService departamentoService)
        {
            _vendedoresService = vendedorService;
            _departamentoService = departamentoService;
=======

        public VendedoresController(VendedorService vendedorService)
        {
            _vendedoresService = vendedorService;
>>>>>>> aac1a996cf27aaff57e41c16a07fc619bc675f3e
        }

        public IActionResult Index()
        {
            var list = _vendedoresService.BuscarTodos();
            return View(list);
        }

        public IActionResult Criar()
        {
<<<<<<< HEAD
            var departamentos = _departamentoService.FindAll();
            var viewModel = new VendedorFormViewModel { Departamentos = departamentos };
            return View(viewModel);
=======
            return View();
>>>>>>> aac1a996cf27aaff57e41c16a07fc619bc675f3e
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
<<<<<<< HEAD
        public IActionResult Detalhar(int? id)
=======

        public IActionResult Detalhes(int? id)
>>>>>>> aac1a996cf27aaff57e41c16a07fc619bc675f3e
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
