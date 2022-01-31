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
            AccountViewModel model = new AccountViewModel();
            model.Gebruiker = await HttpContext.Session.GetUser(persoonService);
            return View(model);
        }
    }
}
