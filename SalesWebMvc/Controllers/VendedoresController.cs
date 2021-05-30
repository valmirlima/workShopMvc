using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Services;
using SalesWebMvc.Models;
using SalesWebMvc.Models.ViewModels;

namespace SalesWebMvc.Controllers
{

    public class VendedoresController : Controller
    {
        private readonly SellerService _sellerService;
        private readonly DepartamentoService _departamentoService;

        public VendedoresController(SellerService sellerService, DepartamentoService departamentoService)
        {
            _sellerService = sellerService;
            _departamentoService = departamentoService;
        }

        public IActionResult Index()
        {

            var list = _sellerService.FindAll();

            return View(list);
        }

        public IActionResult Create()
        {
            var departamentos = _departamentoService.FindAll();//busca do BD todos os departamentos
            var viewModel = new SellerFormViewModel {departamentos = departamentos};
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]//
        public IActionResult Create(Vendedor vendedor)
        {
            _sellerService.Insert(vendedor);
            return RedirectToAction(nameof(Index));
        }
    }
}