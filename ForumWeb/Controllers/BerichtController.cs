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
        public BerichtController(BerichtThemaService themaService)
        {
            this.themaService = themaService;
        }
        public IActionResult Nieuw()
        {
            HoofdBerichtViewModel model = new HoofdBerichtViewModel();
            model.Profiel = (Profiel)HttpContext.Session.GetUser();
            model.BerichtThemas = themaService.GetAll().ToSelectList(t => t.BerichtTypeId.ToString(), t => t.BerichtTypeNaam);
            return View(model);
        }
    }
}
