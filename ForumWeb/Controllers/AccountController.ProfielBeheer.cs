using ForumData.Entities;
using ForumWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumWeb.Controllers
{
    public partial class AccountController
    {

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
