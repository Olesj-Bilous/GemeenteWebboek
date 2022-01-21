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

            //get interesses and profielInteresses
            IEnumerable<Interesse> interesses = interesseService.GetInteresses();
            List<ProfielInteresse> profielInteresses = profiel.ProfielInteresses.ToList();

            //filter profielInteresses from interesses
            foreach (ProfielInteresse pi in profielInteresses)
            {
                interesses = interesses.Where(i => i != pi.Interesse);
            }

            //fill ViewModel
            model.ProfielId = profiel.PersoonId.ToString();
            model.Interesses = interesses.ToList().ToSelectList(i => i.InteresseId.ToString(), i => i.InteresseNaam);
            model.ProfielInteresses = profielInteresses;
            return View(model);
        }
    }
}
