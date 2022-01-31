using ForumData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumWeb.Models
{
    public class AccountViewModel
    {
        public Persoon Gebruiker { get; set; }
        public bool? RegistrerenGelukt { get; set; }
    }
}
