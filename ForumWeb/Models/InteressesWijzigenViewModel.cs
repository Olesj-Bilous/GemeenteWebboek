using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumWeb.Models
{
    public class InteresseViewModel
    {
        public string Id { get; set; }
        public string Tekst { get; set; }
    }
    public class InteressesWijzigenViewModel
    {
        public string ProfielId { get; set; }
        public InteresseViewModel[] Toegevoegd { get; set; }
        public InteresseViewModel[] Aangepast { get; set; }
        public string[] Verwijderd { get; set; }
    }
}
