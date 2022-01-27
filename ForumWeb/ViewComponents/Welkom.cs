using ForumService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumWeb.ViewComponents
{
    public class Welkom : ViewComponent
    {
        private readonly PersoonService persoonService;
        public Welkom(PersoonService persoonService)
        {
            this.persoonService = persoonService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await HttpContext.Session.GetUser(persoonService));
        }
    }
}
