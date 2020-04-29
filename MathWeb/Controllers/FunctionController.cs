using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MathService.Function;
using MathWeb.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MathWeb.Controllers
{
    public class FunctionController : Controller
    {

        private IFunctionService<double> _service;
        private IFunctionCalculation<double> _calculation;

        public FunctionController(IFunctionService<double> service, IFunctionCalculation<double> calculation)
        {
            _service = service;
            _calculation = calculation;
        }


        public IActionResult CalculateFunctionExample()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CalculateFunctionExampleData([FromBody]double[] xlist)
        {
            var domain = new Queue<double>(xlist);
            _service.CreateDomain(domain);

            var result = await _service.CalculateAsync((px) =>
            {
                double denominator = Math.Pow(px, 4) + (3 * Math.Pow(px, 2)) - 4;
                double numerator = (16 - Math.Pow(px, 2));

                double solution = denominator / numerator;
                return new Point<double>(px, solution);
            });
            return Json(result);
        }


    }
}