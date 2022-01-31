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
        private readonly BerichtThemaService themaService;
        private readonly PersoonService persoonService;
        public BerichtController(BerichtThemaService themaService, PersoonService persoonService)
        {
            this.themaService = themaService;
            this.persoonService = persoonService;
        }
        public async Task<IActionResult> Nieuw()
        {
            HoofdBerichtViewModel model = new HoofdBerichtViewModel();
            model.Profiel = (Profiel) await HttpContext.Session.GetUser(persoonService);
            model.BerichtThemas = themaService.GetAll().ToSelectList(t => t.BerichtTypeId.ToString(), t => t.BerichtTypeNaam);
            return View(model);
        }
    }
}
