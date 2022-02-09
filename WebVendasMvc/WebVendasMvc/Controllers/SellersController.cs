using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebVendasMvc.Models;
using WebVendasMvc.Services;

namespace WebVendasMvc.Controllers
{
    public class SellersController : Controller
    {
        public readonly SellerService _sellerService;

        public SellersController(SellerService sellerService)
        {

            _sellerService = sellerService;
        }

        public IActionResult Index()
        {
            var lista = _sellerService.FindAll(); // Executa o metodo do MODEL da classe de serviço SellerService

            return View(lista); // passa a lista como argumento para view.
        }

        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken] // Impede que outras pessoas enviem dados maliciosos usando sua sessão
        public IActionResult Create(Seller obj) // Framework instancia automaticamente o obj
        {
            
            
            _sellerService.Insert(obj);

            return RedirectToAction(nameof(Index));
        }

    }
}
