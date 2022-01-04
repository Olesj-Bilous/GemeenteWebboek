using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumData.Entities
{
    public class Provincie
    {
        public Provincie() { }

        //public Provincie(string code, string naam)
        //{
        //    ProvincieCode = code;
        //    ProvincieNaam = naam;
        //}

        public int ProvincieId { get; set; }
        public string ProvincieCode { get; set; }
        public string ProvincieNaam { get; set; }

        //navigation
        public virtual ICollection<Gemeente> Gemeenten { get; set; } = new List<Gemeente>();
    }
}
