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
    public partial class AccountController : Controller
    {
        private readonly IPersoonRepository persoonRepo;
        private readonly IProfielRepository profielRepo;
        private readonly AdresService adresService;
        private readonly GemeenteService gemeenteService;
        private readonly StraatService straatService;
        private readonly TaalService taalService;
        public AccountController(IPersoonRepository persoonRepo, IProfielRepository profielRepo, 
            AdresService adresService,
            GemeenteService gemeenteService, StraatService straatService, TaalService taalService)
        {
            this.persoonRepo = persoonRepo;
            this.profielRepo = profielRepo;
            this.adresService = adresService;
            this.gemeenteService = gemeenteService;
            this.straatService = straatService;
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
    }
}
