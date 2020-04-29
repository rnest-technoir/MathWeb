using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MathWeb.Controllers
{
    public class MainController : Controller
    {
        public IActionResult ShowAll()
        {
            return View();
        }
    }
}