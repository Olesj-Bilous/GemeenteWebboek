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

                await berichtService.AddBerichtAsync(bericht);
                return View("../Home/Index");
            }
            return View(model);
        }
    }
}
