using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using userSecrets.Models;

namespace userSecrets.Controllers
{
    public class HomeController : Controller
    {
        private Secrets _secrets { get; }

        public HomeController(IOptions<Secrets> secrets)
        {
            this._secrets = secrets.Value;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Our super secret password is:";
            ViewData["UserSecret"] = string.IsNullOrEmpty(this._secrets.SuperStrongPassword)
                    ? "Are you in production?"
                    : this._secrets.SuperStrongPassword;

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
