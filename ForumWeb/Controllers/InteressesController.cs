using ForumData.Entities;
using ForumService;
using ForumWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
        private readonly InteresseService interesseService;
        private readonly ProfielInteresseService piService;

        public InteressesController(ProfielService profielService, InteresseService interesseService, ProfielInteresseService piService)
        {
            this.profielService = profielService;
            this.interesseService = interesseService;
            this.piService = piService;
        }

        [HttpPost]
        public IActionResult Wijzigen([FromBody] InteressesWijzigenViewModel model)
        {
            int profielId = int.Parse(model.ProfielId);
            Profiel profiel = profielService.GetProfielById(profielId);
            List<ProfielInteresse> newPIs = new List<ProfielInteresse>();
            List<ProfielInteresse> altPIs = new List<ProfielInteresse>();

            foreach (InteresseViewModel i in model.Toegevoegd)
            {
                Interesse interesse = interesseService.GetById(int.Parse(i.Id));
                ProfielInteresse pi = new ProfielInteresse {
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
