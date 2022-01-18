using ForumData.Entities;
using ForumService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumWeb.Controllers
{
    [Route("Select")]
    [ApiController]
    public class SelectController : ControllerBase
    {
        private readonly GemeenteService gemeenteService;
        private readonly StraatService straatService;
        public SelectController(GemeenteService gemeenteService, StraatService straatService)
        {
            this.gemeenteService = gemeenteService;
            this.straatService = straatService;
        }

        [HttpGet("Gemeenten/{filter}")]
        public ActionResult GetGemeentenByFilter(string filter)
        {
            List<SelectListItem> items = gemeenteService
                .GetGemeentenByFilter(filter)
                .ToSelectList(g => g.GemeenteId.ToString(), g => g.GemeenteNaam);
            return items.Any() ? base.Ok(items) : base.NotFound();
        }

        [HttpGet("Straten/{gemeenteId}/{filter}")]
        public ActionResult GetStratenByGemeenteIdAndFilter(int gemeenteId, string filter)
        {
            List<SelectListItem> items = straatService
                .GetStratenByGemeenteIdAndFilter(gemeenteId, filter)
                .ToSelectList(s => s.StraatId.ToString(), s => s.StraatNaam);
            return items.Any() ? base.Ok(items) : base.NotFound();
        }
    }
}
