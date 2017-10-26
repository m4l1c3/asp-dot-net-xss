using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using asp_dot_net_xss.Models;

namespace asp_dot_net_xss.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var model = new SaferXssRequestModel();
            return View(model);
        }

        [HttpGet]
        public IActionResult IndexVulnerable()
        {
            var model = new UnsafeXssRequestModel();
            return View("VulnerableIndex", model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult IndexVulnerable(UnsafeXssRequestModel model)
        {
            if(!ModelState.IsValid)
            {
                return View("VulnerableIndex", model);
            }
            var viewModel = new XssResponseModel()
            {
                Response = model.Input
            };

            return View(viewModel);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Index(SaferXssRequestModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            var viewModel = new XssResponseModel()
            {
                Response = model.Input
            };

            return View("ValidationPassed", viewModel);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
