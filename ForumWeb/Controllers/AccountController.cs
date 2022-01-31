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
        private readonly PersoonService persoonService;
        private readonly ProfielService profielService;
        private readonly InteresseService interesseService;
        private readonly ProfielInteresseService piService;
        private readonly TaalService taalService;
        private readonly AdresService adresService;
        private readonly GemeenteService gemeenteService;
        private readonly StraatService straatService;

        public AccountController
        (
            PersoonService persoonService,
            ProfielService profielService,
            InteresseService interesseService,
            ProfielInteresseService piService,
            TaalService taalService,
            AdresService adresService,
            GemeenteService gemeenteService,
            StraatService straatService
        )
        {
            this.persoonService = persoonService;
            this.profielService = profielService;
            this.piService = piService;
            this.interesseService = interesseService;
            this.adresService = adresService;
            this.gemeenteService = gemeenteService;
            this.straatService = straatService;
            this.taalService = taalService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await HttpContext.Session.GetUser(persoonService));
        }

        public async Task<IActionResult> ProfielBeheer()
        {
            var IngelogdPersoon = await HttpContext.Session.GetUser(persoonService);
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
            //var profielStatusLijst = profielService.GetAllProfiels();
            //ProfielStatusLijstViewModel profielStatusLijstVM = new ProfielStatusLijstViewModel();
            //profielStatusLijstVM.profielStatusLijst = (System.Collections.IEnumerable)profielStatusLijst;

            return View(IngelogdMedewerker); 
        }

        public async Task<IActionResult> ProfielPage(Profiel ingelogdProfiel)
        {

            var IngelogdProfiel = await profielService.GetProfielByPersoonIdAsync(ingelogdProfiel.PersoonId);
            return View(IngelogdProfiel);
        }

        [HttpGet]
        public async Task<IActionResult> EditFormProfiel(int Id)
        {
            
            return View(await profielService.GetProfielByPersoonIdAsync(Id));       
        }

        [HttpPost]
        public async Task<IActionResult> EditProfiel(Profiel updateProfiel)
        {
            if (this.ModelState.IsValid)
            {
                try
                {
                    await profielService.UpdateProfielAsync(updateProfiel);
                    HttpContext.Session.SetObject("Gebruiker", updateProfiel);
                    return RedirectToAction("ProfielBeheer");
                }
                catch (Exception)
                {
                    ErrorViewModel errorVM = new ErrorViewModel();
                    return View("Error", errorVM);
                }

            }
            else
            {
                return View("EditFormProfiel", updateProfiel);
            }
        }
    }
}
