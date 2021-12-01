using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

            if (!ModelState.IsValid)
            {
                var departamantos = _departamentoService.FindAll();
                var viewModel = new VendedorFormViewModel { Vendedor = vendedor, Departamentos = departamantos };
                return View(viewModel);
            }
            _vendedoresService.Inserir(vendedor);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Deletar(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não foi fornecido!" });
            }
            var obj = _vendedoresService.BuscarId(id.Value);

            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado!" });
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

        public IActionResult Detalhes(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido!" });
            }
            var obj = _vendedoresService.BuscarId(id.Value);

            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado!" });
            }
            return View(obj);

        }
        public IActionResult Editar(int? id)
        {
            if(id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido!" });
            }
            var obj = _vendedoresService.BuscarId(id.Value);
            if (obj == null )
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado!" });
            }
            List<Departamento> departamentos = _departamentoService.FindAll();
            VendedorFormViewModel viewModel = new VendedorFormViewModel { Vendedor = obj, Departamentos = departamentos };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(int id, Vendedor vendedor)
        {
            if (!ModelState.IsValid)
            {
                var departamantos = _departamentoService.FindAll();
                var viewModel = new VendedorFormViewModel { Vendedor = vendedor, Departamentos = departamantos };
                return View(viewModel);
            }
            if (id != vendedor.ID)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não correspondem!" });
            }
            try
            {
                _vendedoresService.Update(vendedor);
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