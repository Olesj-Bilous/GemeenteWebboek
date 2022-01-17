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
        private ProfielService profielService;
        private MedewerkerService medewerkerService;

        public AccountController(PersoonService persoonService, ProfielService profielService, MedewerkerService medewerkerService)
        {
            this.medewerkerService = medewerkerService;
            this.profielService = profielService;
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
        public async Task<IActionResult> Inloggen(InloggenViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                Persoon gebruiker = await persoonService.GetPersoonByLoginNaamAndPaswoordAsync(model.Naam, model.Paswoord);
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
        public async Task<IActionResult> Edit(Profiel updateProfiel)
        {
            if (this.ModelState.IsValid)
            {
                    await profielService.UpdateProfielAsync(updateProfiel);
                    return RedirectToAction("ProfielBeheer");
            }else
            {
                return View("EditForm", updateProfiel);
            }
        }

        public IActionResult Uitloggen()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
