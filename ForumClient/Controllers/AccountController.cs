using ForumData.Entities;
using ForumData.Repositories.Interface;
using ForumWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumWeb.Controllers
{
    public class AccountController : Controller
    {
        private readonly IPersoonRepository persoonRepo;
        public AccountController(IPersoonRepository persoonRepo)
        {
            this.persoonRepo = persoonRepo;
        }
        public IActionResult Index()
        {
            AccountViewModel model = new AccountViewModel();
            model.Gebruiker = 
                HttpContext.Session.GetObject<bool>("IsMedewerker") 
                ? HttpContext.Session.GetObject<Medewerker>("Gebruiker")
                : HttpContext.Session.GetObject<Profiel>("Gebruiker");
            return View(model);
        }

        public IActionResult Inloggen()
        {
            return View(new InloggenViewModel());
        }

        [HttpPost]
        public IActionResult Inloggen(InloggenViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                Persoon gebruiker = persoonRepo.GetPersoonByLoginNaamAndPaswoord(model.Naam, model.Paswoord);
                if (gebruiker is not null)
                {
                    HttpContext.Session.SetObject("Gebruiker", gebruiker);
                    HttpContext.Session.SetObject("IsMedewerker", gebruiker is Medewerker);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(model);
                }
            }
            else
            {
                return View(model);
            }
        }

        public IActionResult Uitloggen()
        {
            return View();
        }
    }
}
