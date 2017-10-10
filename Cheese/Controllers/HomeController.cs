using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Cheese.Models;

namespace Cheese.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Land()
        {
         

            return View();
        }

        public IActionResult Type()
        {


            return View();
        }
        public IActionResult Aanbiedingen()
        {
     

            return View();
        }

        public IActionResult Kaasfondue()
        {
            

            return View();
        }

        public IActionResult Kaasgereedschap()
        {
            

            return View();
        }

        public IActionResult Lekker_bij_de_kaas()
        {
            

            return View();
        }

         public IActionResult Kaaspakketten()
        {
            

            return View();
        }
         public IActionResult About()
        {
            

            return View();
        }

        public IActionResult Klantservice()
        {
            

            return View();
        }
         public IActionResult Contact_Informatie()
        {
            

            return View();
        }
         public IActionResult Admin()
        {
            

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
