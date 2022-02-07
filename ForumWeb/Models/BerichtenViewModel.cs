using ForumData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumWeb.Models
{
    public class BerichtenViewModel
    {
        public List<HoofdBericht> HoofdBerichten { get; set; }
        public Gemeente Gemeente { get; set; }
    }
}
