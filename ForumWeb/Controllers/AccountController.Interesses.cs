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
        public IActionResult Interesses(Profiel profiel)
        {
            InteressesViewModel model = new InteressesViewModel();
            model.Interesses = interesseService
                .GetInteresses()
                .ToSelectList(i => i.InteresseId.ToString(), i => i.InteresseNaam);
            model.ProfielInteresses = profiel.ProfielInteresses.ToList();
            return View(model);
        }
    }
}
