using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Services;
using SalesWebMvc.Models;

namespace SalesWebMvc.Controllers
{

    public class VendedoresController : Controller
    {
        private readonly SellerService _sellerService;

        public VendedoresController(SellerService sellerService)
        {
            _sellerService = sellerService;
        }

        public IActionResult Index()
        {

            var list = _sellerService.FindAll();

            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]//
        public IActionResult Create(Vendedor seller)
        {
            _sellerService.Insert(seller);
            return RedirectToAction(nameof(Index));
        }
    }
}