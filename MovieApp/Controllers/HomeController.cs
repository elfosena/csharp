using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MovieApp.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index() {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }
        
    }
}