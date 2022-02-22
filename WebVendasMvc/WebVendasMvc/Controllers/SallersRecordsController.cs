using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebVendasMvc.Controllers
{
    public class SallersRecordsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SimpleSearch()
        {

            return View();
        }

        public IActionResult GroupingSearch()
        {

            return View();
        }
    }
}
