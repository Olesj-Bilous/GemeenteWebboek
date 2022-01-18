using ForumData.Entities;
using ForumWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumWeb.Controllers
{
    public partial class AccountController : Controller
    {
        public IActionResult Registreren()
        {
            RegistrerenViewModel model = new RegistrerenViewModel();
            model.Talen = taalService.GetTalen().ToSelectList(t => t.TaalId.ToString(), t => t.TaalNaam);
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
                profiel.Taal = taalService.GetTaalById(int.Parse(model.Taal));
                profiel.GeboortePlaats = gemeenteService.GetGemeenteById(int.Parse(model.GeboortePlaats));
                profiel.LoginNaam = model.LoginNaam;
                profiel.LoginPaswoord = model.LoginPaswoord;

                //adres
                Gemeente woonPlaats = gemeenteService.GetGemeenteById(int.Parse(model.WoonPlaats));
                Straat straat = straatService.GetStraatById(int.Parse(model.Straat));
                profiel.Adres = adresService.GetOrCreateAndReturnAdres(straat, model.HuisNr, model.BusNr);

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
