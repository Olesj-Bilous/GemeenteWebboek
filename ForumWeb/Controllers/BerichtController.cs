using ForumData.Entities;
using ForumService;
using ForumWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumWeb.Controllers
{
    public class BerichtController : Controller
    {
        private readonly BerichtService berichtService;
        private readonly BerichtThemaService themaService;
        private readonly PersoonService persoonService;

        public BerichtController(
            BerichtService berichtService,
            BerichtThemaService themaService,
            PersoonService persoonService)
        {
            this.berichtService = berichtService;
            this.themaService = themaService;
            this.persoonService = persoonService;
        }

        public IActionResult Nieuw()
        {
            HoofdBerichtViewModel model = new HoofdBerichtViewModel();
            model.Themas = themaService.GetAll().ToSelectList(t => t.Id.ToString(), t => t.Naam);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Nieuw(HoofdBerichtViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                HoofdBericht bericht = new HoofdBericht();
                bericht.ProfielId = HttpContext.Session.GetObject<int>("GebruikerId");
                bericht.BerichtTijdstip = DateTime.Now;
                bericht.BerichtThemaId = int.Parse(model.ThemaId);
                bericht.BerichtTitel = model.Titel;
                bericht.BerichtTekst = model.Tekst;

                await berichtService.AddAsync(bericht);
                return View("Alle");
            }
            return View(model);
        }

        public async Task<IActionResult> Alle()
        {
            Profiel profiel = (Profiel)await HttpContext.Session.GetUser(persoonService);
            int gemeenteId = profiel.Adres.Straat.GemeenteId;
            List<HoofdBericht> hBerichten = await berichtService.GetAllHoofdByGemeenteIdAsync(gemeenteId);
            return View(hBerichten);
        }

        public async Task<IActionResult> Antwoorden(int berichtId)
        {
            AntwoordViewModel model = new();
            Bericht oorsprong = await berichtService.GetByIdAsync(berichtId);
            if (oorsprong is HoofdBericht)
            {
                model.OorsprongHoofd = await berichtService.GetHoofdByIdAsync(berichtId);
            }
            else
            {
                model.OorsprongAntwoord = await berichtService.GetAntwoordByIdAsync(berichtId);
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Antwoorden(AntwoordViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                Antwoord antwoord = new();
                antwoord.BerichtTekst = model.Tekst;
                antwoord.BerichtTijdstip = DateTime.Now;
                antwoord.ProfielId = HttpContext.Session.GetObject<int>("GebruikerId");

                if (model.OorsprongIsHoofd)
                {
                    antwoord.HoofdBericht = await berichtService.GetHoofdByIdAsync(model.OorsprongId);
                }
                else
                {
                    antwoord.ParentAntwoord = await berichtService.GetAntwoordByIdAsync(model.OorsprongId);
                    antwoord.HoofdBericht = antwoord.ParentAntwoord.HoofdBericht;
                }
                await berichtService.AddAsync(antwoord);
                return RedirectToAction("Alle");
            }
            else
            {
                return View(model);
            }
        }
    }
}
