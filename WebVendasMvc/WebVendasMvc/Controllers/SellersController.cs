﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebVendasMvc.Models;
using WebVendasMvc.Models.ViewModels;
using WebVendasMvc.Services;

namespace WebVendasMvc.Controllers
{
    public class SellersController : Controller
    {
        public readonly SellerService _sellerService;
        public readonly DepartmentService _departmentService;


        public SellersController(SellerService sellerService, DepartmentService departmentService)
        {

            _sellerService = sellerService;
            _departmentService = departmentService;

        }

        public IActionResult Index()
        {
            var lista = _sellerService.FindAll(); // Executa o metodo do MODEL da classe de serviço SellerService

            return View(lista); // passa a lista como argumento para view.
        }

        public IActionResult Create()
        {
            // Metodo que abre a tela de cadastro do Usuario

            var departments = _departmentService.FindAll(); // pega a lista de departamentos

            var viewModel = new SellerFormViewModel { Departments = departments };// instancia os departamentos com a Lista 

            return View(viewModel); // Passa a lista para View
        }
        [HttpPost]
        [ValidateAntiForgeryToken] // Impede que outras pessoas enviem dados maliciosos usando sua sessão
        public IActionResult Create(Seller seller) // Framework instancia automaticamente o obj
        {

            _sellerService.Insert(seller);

            return RedirectToAction(nameof(Index));
        }

    }
}
