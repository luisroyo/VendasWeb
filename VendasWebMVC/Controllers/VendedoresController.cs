using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using VendasWebMVC.Models;
using VendasWebMVC.Models.ViewsModels;
using VendasWebMVC.Services;
using VendasWebMVC.Services.Exceptions;

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

        public async Task<IActionResult> Index()
        {
            var list = await _vendedoresService.BuscarTodosAsync();
            return View(list);
        }

        public async Task<IActionResult> Criar()
        {
            var departamentos = await _departamentoService.FindAllAsync();
            var viewModel = new VendedorFormViewModel { Departamentos = departamentos };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Criar(Vendedor vendedor)
        {

            if (!ModelState.IsValid)
            {
                var departamantos = await _departamentoService.FindAllAsync();
                var viewModel = new VendedorFormViewModel { Vendedor = vendedor, Departamentos = departamantos };
                return View(viewModel);
            }
            await _vendedoresService.InserirAsync(vendedor);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Deletar(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não foi fornecido!" });
            }
            var obj = await _vendedoresService.BuscarIdAsync(id.Value);

            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado!" });
            }
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Deletar(int id)
        {
            await _vendedoresService.RemoverAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Detalhes(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido!" });
            }
            var obj = await _vendedoresService.BuscarIdAsync(id.Value);

            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado!" });
            }
            return View(obj);

        }
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido!" });
            }
            var obj = await _vendedoresService.BuscarIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado!" });
            }
            List<Departamento> departamentos = await _departamentoService.FindAllAsync();
            VendedorFormViewModel viewModel = new VendedorFormViewModel { Vendedor = obj, Departamentos = departamentos };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, Vendedor vendedor)
        {
            if (!ModelState.IsValid)
            {
                var departamantos = await _departamentoService.FindAllAsync();
                var viewModel = new VendedorFormViewModel { Vendedor = vendedor, Departamentos = departamantos };
                return View(viewModel);
            }
            if (id != vendedor.ID)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não correspondem!" });
            }
            try
            {
                await _vendedoresService.UpdateAsync(vendedor);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }

        }
        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }
    }
}