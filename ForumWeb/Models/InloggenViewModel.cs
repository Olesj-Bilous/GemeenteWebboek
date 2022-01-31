using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ForumWeb.Models
{
    public class InloggenViewModel
    {
        [Display(Name="Loginnaam")]
        [Required(ErrorMessage = "Geef een loginnaam op")]
        public string Naam { get; set; }

        [Required(ErrorMessage ="Geef een paswoord op")]
        [DataType(DataType.Password)]
        public string Paswoord { get; set; }
    }
}
