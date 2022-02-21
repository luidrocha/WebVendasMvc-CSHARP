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

// No controlador deve-se manter o padrão de nome por isso não mudamos o nome para ASYNC
// Somento os metodos são mudados

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

        public async Task<IActionResult> Index()
        {
            var lista = await _sellerService.FindAllAsync(); // Executa o metodo do MODEL da classe de serviço SellerService

            return View(lista); // passa a lista como argumento para view.
        }

        public async Task<IActionResult> Create()
        {
            // Metodo que abre a tela de cadastro do Usuario

            var departments = await _departmentService.FindAllAsync(); // pega a lista de departamentos

            var viewModel = new SellerFormViewModel { Departments = departments };// instancia os departamentos com a Lista 

            return View(viewModel); // Passa a lista para View
        }

        public async Task<IActionResult> Delete(int? id)
        {
            //  Este metodo apenas acha o usuario e passa para view apresentar dos dados. Não EXCLUI

            if (id == null)
            {
                // Retorna a pagina de erro /  new { message = "Id não encontrado" }= Cria um objeto anonimo

                return RedirectToAction(nameof(Error), new { message = "Id não especificado" });
            }

            var obj = await _sellerService.FindByIdAsync(id.Value); // Como o Id é opcinal tem que colocar o .Value
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não contrado" });
            }

            return View(obj);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não especificado" });
            }

            var obj = await _sellerService.FindByIdAsync(id.Value); // Como o Id é opcinal temque colocar o .Value
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
            }

            return View(obj);
        }

        public async Task<IActionResult> Edit(int? Id)
        {


            if (Id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não especificado" });
            }

            var obj = await _sellerService.FindByIdAsync(Id.Value);

            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
            }

            List<Department> departments = await _departmentService.FindAllAsync();

            SellerFormViewModel viewModel = new SellerFormViewModel { Seller = obj, Departments = departments };

            return View(viewModel);

        }


        public IActionResult Error(string message)
        {
            // Erro viewModel e uma classe 

            var viewModel = new ErrorViewModel
            {
                Message = message,
                // Pegando o ID internoda Requisição pacote: using System.Diagnostics;
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };

            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken] // Impede que outras pessoas enviem dados maliciosos usando sua sessão
        public async Task<IActionResult> Create(Seller seller) // Framework instancia automaticamente o obj
        {
            // Valida no back-end, server-side se o objeto seller foi validado. 
            // Se o JavaScript for desbilitado no navegador do usuario as validaçães não serão executadas 

            if (!ModelState.IsValid)
            {
                var departments = await _departmentService.FindAllAsync();
                var viewModel = new SellerFormViewModel { Seller = seller, Departments = departments };
                // Devolve o objeto para view até validar
                return View(viewModel);
            }

            await _sellerService.InsertAsync(seller);

            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int Id)
        {

            await _sellerService.RemoveAsync(Id);

            return RedirectToAction(nameof(Index));


        }


        [HttpPost]
        [AutoValidateAntiforgeryToken]
        // int? Id = recuperado da URL
        public async Task<IActionResult> Edit(int? Id, Seller seller)
        {
            // Valida no back-end, server-side se o objeto seller foi validado. 
            // Se o JavaScript for desbilitado no navegador do usuario as validaçães não serão executadas 

            if (!ModelState.IsValid)
            {
                var departments = await _departmentService.FindAllAsync();
                var viewModel = new SellerFormViewModel { Seller = seller, Departments = departments };

                // Devolve o objeto para viewl até validar
                return View(viewModel);
            }

            // Verifica se o ID da url é o mesmo do Vendedor

            if (Id != seller.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id da solicitação diferente do Id do vendedor" });
            }

            try
            {
                await _sellerService.UpdateAsync(seller);
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



    }
}
