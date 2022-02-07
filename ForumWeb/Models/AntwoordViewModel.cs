using ForumData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumWeb.Models
{
    public class AntwoordViewModel
    {
        public int BronHoofdId { get; set; }
        public HoofdBericht BronHoofd { get; set; }
        public int BronAntwoordId { get; set; }
        public Antwoord BronAntwoord { get; set; }
        public int BronId { get; set; }
        public bool BronIsHoofd { get; set; }
        public string Tekst { get; set; }
    }
}
