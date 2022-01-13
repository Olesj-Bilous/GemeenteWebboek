using ForumData.Entities;
using ForumData.Repositories.Interface;
using ForumWeb.Models;
using ForumService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumWeb.Controllers
{
    public class AccountController : Controller
    {
    
        private PersoonService persoonService;
        public AccountController(IPersoonRepository persoonRepo, PersoonService persoonService)
        {
            this.persoonService = persoonService;
        }
        public IActionResult Index()
        {
            return View(HttpContext.Session.GetUser());
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
                Persoon gebruiker = persoonService.GetPersoonByLoginNaamAndPaswoord(model.Naam, model.Paswoord);
                if (gebruiker is not null)
                {
                    HttpContext.Session.SetObject("Gebruiker", gebruiker);
                    HttpContext.Session.SetObject("IsMedewerker", gebruiker is Medewerker);
                    return RedirectToAction("index");
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

        public IActionResult ProfielBeheer()
        {

            Persoon IngelogdPersoon = HttpContext.Session.GetUser();
            if (IngelogdPersoon is Profiel)
            {
                return RedirectToAction("ProfielPage", IngelogdPersoon);
            }
            if (IngelogdPersoon is Medewerker)
            {
                return RedirectToAction("MedewerkerPage", IngelogdPersoon);
            }
            else
            {
                return RedirectToAction("Inloggen");
            }
        }       

        public IActionResult MedewerkerPage(Medewerker IngelogdMedewerker)
        {   
            return View(IngelogdMedewerker);
        }

        public IActionResult ProfielPage(Profiel IngelogdProfiel)
        {   
            return View(IngelogdProfiel);
        }

        [HttpGet]
        public async Task<IActionResult> EditForm(int Id)
        {
            return View(await persoonService.GetPersoonByIdAsync(Id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Persoon updatePersoon)
        {
            if (this.ModelState.IsValid)
            {
                await persoonService.UpdatePersoonAsync(updatePersoon);
                return RedirectToAction("ProfielBeheer");
            }else
            {
                return View("EditForm", updatePersoon);
            }
        }

        public IActionResult Uitloggen()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
