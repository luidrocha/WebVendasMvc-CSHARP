using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebVendasMvc.Models;
using WebVendasMvc.Models.ViewModels;
using WebVendasMvc.Services;
using WebVendasMvc.Services.Exceptions;

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

        public IActionResult Delete(int? id)
        {
            //  Este metodo apenas acha o usuario e passa para view apresentar dos dados. Não EXCLUI

            if (id == null)
            {
                // Retorna a pagina de erro /  new { message = "Id não encontrado" }= Cria um objeto anonimo

                return RedirectToAction(nameof(Error), new { message = "Id não especificado" });
            }

            var obj = _sellerService.FindById(id.Value); // Como o Id é opcinal tem que colocar o .Value
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não contrado" });
            }

            return View(obj);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não especificado" });
            }

            var obj = _sellerService.FindById(id.Value); // Como o Id é opcinal temque colocar o .Value
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Delete(int Id)
        {

            _sellerService.Remove(Id);

            return RedirectToAction(nameof(Index));


        }

        public IActionResult Edit(int? Id)
        {
            if (Id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não especificado" });
            }

            var obj = _sellerService.FindById(Id.Value);

            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
            }

            List<Department> departments = _departmentService.FindAll();

            SellerFormViewModel viewModel = new SellerFormViewModel { Seller = obj, Departments = departments };

            return View(viewModel);

        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]

        // int? Id = recuperado da URL
        public IActionResult Edit(int? Id, Seller seller)
        {
            // Verifica se o ID da url é o mesmo do Vendedor

            if (Id != seller.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id da solicitação diferente do Id do vendedor" });
            }

            try
            {
                _sellerService.Update(seller);
                return RedirectToAction(nameof(Index));
            }
            /* Nesse ponto estamos tratando EXCESSÃO
               Poderiamos substituir os dois CATCH por uma excessão APLICATIONEXCEPRION 
               que é SUPER-TIPO das duas classes  */



            catch (NotFoundException e)
            {
                // Passamos a menssagem da excessão para pagina de error

                return RedirectToAction(nameof(Error), new { message = e.Message });

            }
            // Nesse ponto estamos tratando EXCESSÃO

            catch (DbConcurrencyException e)
            {
                // Passamos a menssagem da excessão para pagina de error

                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                // Pegando o ID internoda Requisição pacote: using System.Diagnostics;
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };

            return View(viewModel);
        }

    }
}
