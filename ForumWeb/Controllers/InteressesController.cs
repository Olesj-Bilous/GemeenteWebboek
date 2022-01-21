using ForumData.Entities;
using ForumService;
using ForumWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumWeb.Controllers
{
    [Route("Interesses")]
    [ApiController]
    public class InteressesController : ControllerBase
    {
        private readonly ProfielService profielService;
        private readonly ProfielInteresseService piService;

        public InteressesController(ProfielService profielService)
        {
            this.profielService = profielService;
        }

        [HttpPost]
        public IActionResult Wijzigen(InteressesWijzigenViewModel model)
        {
            int profielId = int.Parse(model.ProfielId);
            Profiel profiel = profielService.GetProfielById(profielId);
            List<ProfielInteresse> newPIs = new List<ProfielInteresse>();
            List<ProfielInteresse> altPIs = new List<ProfielInteresse>();

            foreach (InteresseViewModel i in model.Toegevoegd)
            {
                ProfielInteresse pi = new ProfielInteresse 
                    { 
                        ProfielId = profielId,
                        InteresseId = int.Parse(i.Id),
                        ProfielInteresseTekst = i.Tekst
                    };
                newPIs.Add(pi);
            }

            foreach (InteresseViewModel i in model.Aangepast)
            {
                ProfielInteresse pi = piService.GetByProfielIdAndInteresseId(profielId, int.Parse(i.Id));
                pi.ProfielInteresseTekst = i.Tekst;
                altPIs.Add(pi);
            }

            try
            {
                foreach (string id in model.Verwijderd)
                {
                    piService.DeleteById(int.Parse(id));
                }

                piService.AddRange(newPIs);
                piService.UpdateRange(newPIs);
                return base.Ok();
            }
            catch (Exception)
            {
                return base.Problem();
            }
        }
    }
}
