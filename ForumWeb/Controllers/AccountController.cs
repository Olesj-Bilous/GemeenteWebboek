using ForumData.Entities;
using ForumData.Repositories.Interface;
using ForumService;
using ForumWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumWeb.Controllers
{
    public class AccountController : Controller
    {
        private readonly IPersoonRepository persoonRepo;
        private readonly IProfielRepository profielRepo;
        private TaalService taalService;
        public AccountController(IPersoonRepository persoonRepo, IProfielRepository profielRepo, TaalService taalService)
        {
            this.persoonRepo = persoonRepo;
            this.profielRepo = profielRepo;
            this.taalService = taalService;
        }
        public IActionResult Index()
        {
            AccountViewModel model = new AccountViewModel();
            model.Gebruiker = HttpContext.Session.GetUser();
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
                    HttpContext.Session.SetBoolean("IsMedewerker", gebruiker is Medewerker);
                    AccountViewModel accModel = new AccountViewModel();
                    accModel.Gebruiker = gebruiker;
                    return View("Index", accModel);
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
            HttpContext.Session.Clear();
            return View("Index", new AccountViewModel());
        }

        public IActionResult Registreren()
        {
            RegistrerenViewModel model = new RegistrerenViewModel();
            model.Geslacht = "M";
            List<Taal> Talen = taalService.GetTalen();
            foreach (Taal taal in Talen)
            {
                model.Talen.Add(new SelectListItem { Value = taal.TaalCode, Text = taal.TaalNaam });
            }
            model.Taal = Talen.FirstOrDefault().TaalCode;
            return View(model);
        }

        [HttpPost]
        public IActionResult Registreren(RegistrerenViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                Profiel profiel = new Profiel();
                profiel.VoorNaam = model.VoorNaam;
                profiel.FamilieNaam = model.FamilieNaam;
                profiel.GeboorteDatum = model.GeboorteDatum;
                profiel.TelefoonNr = model.TelefoonNr;
                profiel.KennismakingTekst = model.KennismakingTekst;
                profiel.EmailAdres = model.EmailAdres;
                profiel.BeroepTekst = model.BeroepTekst;
                profiel.FirmaNaam = model.FirmaNaam;
                profiel.WebsiteAdres = model.WebsiteAdres;
                profiel.Geslacht = model.Geslacht == "M" ? Geslacht.M : Geslacht.V;
                profiel.WoontHierSinds = model.WoontHierSinds;
                profiel.Taal = taalService.GetTaalByCode(model.Taal);

                try
                {
                    profielRepo.AddProfiel(profiel);
                } 
                catch (Exception)
                {
                    model.RegistrerenGelukt = false;
                    return View(model);
                }

                AccountViewModel accModel = new AccountViewModel();
                accModel.RegistrerenGelukt = true;
                return View("Index", accModel);
            }
            else
            {
                return View(model);
            }
        }
    }
}
