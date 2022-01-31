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

        public IActionResult Inloggen()
        {
            return View(new InloggenViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Inloggen(InloggenViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                Persoon gebruiker = await persoonService.GetByLoginNaamAndPaswoordAsync(model.Naam, model.Paswoord);
                if (gebruiker is not null)
                {
                    HttpContext.Session.SetObject("Gebruiker", gebruiker.PersoonId);
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
