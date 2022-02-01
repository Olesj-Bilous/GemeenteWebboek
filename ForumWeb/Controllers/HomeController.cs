using ForumService;
using ForumWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ForumWeb.Controllers
{
    public class HomeController : Controller
    {
        //INJECTIE
        private readonly ILogger<HomeController> _logger;
        private readonly PersoonService persoonService;
        public HomeController(ILogger<HomeController> logger,
            PersoonService persoonService)
        {
            _logger = logger;
            this.persoonService = persoonService;
        }

        //METHODS
        public async Task<IActionResult> Index()
        {
            return View(await HttpContext.Session.GetUser(persoonService));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
