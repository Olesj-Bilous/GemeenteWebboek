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
                return RedirectToAction("Alle");
            }
            return View(model);
        }

        public async Task<IActionResult> Alle()
        {
            BerichtenViewModel model = new();
            Profiel profiel = (Profiel)await HttpContext.Session.GetUser(persoonService);
            model.Gemeente = profiel.Adres.Straat.Gemeente;
            model.HoofdBerichten = await berichtService.GetAllHoofdByGemeenteIdAsync(model.Gemeente.GemeenteId);
            return View(model);
        }

        public async Task<IActionResult> Antwoorden(int bronId)
        {
            AntwoordViewModel model = new();
            model.BronId = bronId;
            Bericht bron = await berichtService.GetByIdAsync(bronId);
            model.BronIsHoofd = bron is HoofdBericht;
            if (model.BronIsHoofd)
            {
                model.BronHoofd = await berichtService.GetHoofdByIdAsync(bronId);
            }
            else
            {
                Antwoord bronAntwoord = await berichtService.GetAntwoordByIdAsync(bronId);
                model.BronAntwoord = bronAntwoord;
                model.BronHoofd = bronAntwoord.HoofdBericht;
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
                antwoord.HoofdBericht = await berichtService.GetHoofdByIdAsync(model.BronHoofdId);
                if (!model.BronIsHoofd)
                {
                    antwoord.ParentAntwoord = await berichtService.GetAntwoordByIdAsync(model.BronAntwoordId);
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
