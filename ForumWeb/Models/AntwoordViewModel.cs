using ForumData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumWeb.Models
{
    public class AntwoordViewModel
    {
        public HoofdBericht OorsprongHoofd { get; set; }
        public Antwoord OorsprongAntwoord { get; set; }
        public int OorsprongId { get; set; }
        public bool OorsprongIsHoofd { get; set; }
        public string Tekst { get; set; }
    }
}
