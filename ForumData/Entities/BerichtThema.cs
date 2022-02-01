using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumData.Entities
{
    public class BerichtThema
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Naam { get; set; }
#nullable enable
        public string? Tekst { get; set; }
#nullable disable
        public virtual ICollection<HoofdBericht> HoofdBerichten { get; set; } = new List<HoofdBericht>();
    }
}
