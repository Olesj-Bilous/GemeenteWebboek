using ForumData.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumWeb.Models
{
    public class HoofdBerichtViewModel
    {
        public Profiel Profiel { get; set; }
        public List<SelectListItem> BerichtThemas { get; set; } = new List<SelectListItem>();
        public string Titel { get; set; }
        public string Tekst { get; set; }
    }
}
