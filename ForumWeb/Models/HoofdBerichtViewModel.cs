using ForumData.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ForumWeb.Models
{
    public class HoofdBerichtViewModel
    {
        public List<SelectListItem> Themas { get; set; } = new List<SelectListItem>();

        [Required]
        [Display(Name="Thema")]
        public string ThemaId { get; set; }

        [Required]
        public string Titel { get; set; }

        [Required]
        public string Tekst { get; set; }
    }
}
