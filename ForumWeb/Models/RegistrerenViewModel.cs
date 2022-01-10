﻿using ForumData.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ForumWeb.Models
{
    public class RegistrerenViewModel
    {
        public bool? RegistrerenGelukt { get; set; }

        [Required]
        [Display(Name="Voornaam*")]
        public string VoorNaam { get; set; }

        [Required]
        [Display(Name = "Familienaam*")]
        public string FamilieNaam { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Geboortedatum*")]
        public DateTime GeboorteDatum { get; set; }

        [Display(Name = "Telefoonnummer")]
        public string TelefoonNr { get; set; }

        [Required]
        [Display(Name = "Kennismakingstekst*")]
        public string KennismakingTekst { get; set; }

        [Required]
        [Display(Name = "E-mailadres*")]
        public string EmailAdres { get; set; }

        [Display(Name = "Beroep")]
        public string BeroepTekst { get; set; }

        [Display(Name = "Firma")]
        public string FirmaNaam { get; set; }

        [Display(Name = "Facebook")]
        public string FacebookNaam { get; set; }

        [Display(Name = "Website")]
        public string WebsiteAdres { get; set; }

        [Required]
        [Display(Name = "Geslacht*")]
        public string Geslacht { get; set; }

        public List<SelectListItem> Geslachten { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "M", Text = "Man" },
            new SelectListItem { Value = "V", Text = "Vrouw" }
        };

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Woont hier sinds")]
        public DateTime? WoontHierSinds { get; set; }

        [Required]
        [Display(Name = "Taal*")]
        public string Taal { get; set; }

        public List<SelectListItem> Talen { get; set; } = new List<SelectListItem>();

    //    [Display(Name = "Geboorteplaats")]
    //    public Gemeente GeboortePlaats { get; set; }

    //    public List<SelectListItem> Gemeenten { get; set; }

    //    [Required]
    //    [Display(Name = "Woonplaats*")]
    //    public Gemeente WoonPlaats { get; set; }

    //    [Required]
    //    [Display(Name = "Straatnaam*")]
    //    public string StraatNaam { get; set; }
    //    public List<SelectListItem> Straa { get; set; }

    //[Required]
    //    [Display(Name = "Huisnummer*")]
    //    public string HuisNr { get; set; }

    //    [Required]
    //    [Display(Name = "Busnummer*")]
    //    public string BusNr { get; set; }

        [Required]
        [Display(Name = "Loginnaam*")]
        public string LoginNaam { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Paswoord*")]
        public string LoginPaswoord { get; set; }
    }
}
