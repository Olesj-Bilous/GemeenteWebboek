using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumData.Entities
{
    public class ProfielInteresse
    {
        public ProfielInteresse() { }

        public ProfielInteresse(Profiel profiel, Interesse interesse)
        {
            Profiel = profiel;
            Interesse = interesse;
        }
        public int ProfielId { get; set; }
        public Profiel Profiel { get; set; }
        public int InteresseId { get; set; }
        public Interesse Interesse { get; set; }
#nullable enable
        public string? ProfielInteresseTekst { get; set; }
#nullable disable

        public byte[] Aangepast { get; set; }
    }
}
