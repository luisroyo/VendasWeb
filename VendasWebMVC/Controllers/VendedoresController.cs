using Microsoft.AspNetCore.Mvc;
using VendasWebMVC.Services;

namespace VendasWebMVC.Controllers
{
    public class VendedoresController : Controller
    {
        private readonly VendedorService _vendedoresService;

        public VendedoresController(VendedorService vendedorService)
        {
            _vendedoresService = vendedorService;
        }

        public IActionResult Index()
        {
            var list = _vendedoresService.BuscarTodos();
            return View(list);
        }
    }
}
