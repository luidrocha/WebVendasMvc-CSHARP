using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebVendasMvc.Services;

namespace WebVendasMvc.Controllers
{
    public class SallersRecordsController : Controller
    {
        private readonly SalesRecordService _salesRecordService;

        public SallersRecordsController(SalesRecordService salesRecordService)
        {
            _salesRecordService = salesRecordService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> SimpleSearch(DateTime? minDate, DateTime? maxDate)
        {
            // Senão for informada a data minima
            if (!minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);

            }
            // Senão for informado, seta a data atual
            if (!maxDate.HasValue)
            {
                maxDate = DateTime.Now;
            }
            // Cria a chave que será passada para a view

            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");


            var result = await _salesRecordService.FindByDateAsync(minDate, maxDate);

            return View(result);
        }

        public async Task<IActionResult> GroupingSearch(DateTime? minDate, DateTime? maxDate)
        {
            // Senão for informada a data minima
            if (!minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);

            }
            // Senão for informado, seta a data atual
            if (!maxDate.HasValue)
            {
                maxDate = DateTime.Now;
            }
            // Cria a chave que será passada para a view

            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");


            var result = await _salesRecordService.FindGroupingByDateAsync(minDate, maxDate);

            return View(result);
        }
    }
}
