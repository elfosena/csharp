using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MovieApp.Controllers
{
    public class MovieController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            // TODO: Your code here
            return View();
        }

        public IActionResult Details()
        {
            // TODO: Your code here
            return View();
        }
        
        public IActionResult List()
        {
            // TODO: Your code here
            return View();
        }
        
        
        
    }
}