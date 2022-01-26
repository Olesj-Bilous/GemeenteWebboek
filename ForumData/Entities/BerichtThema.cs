using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumData.Entities
{
    public class BerichtThema
    {
        public int BerichtTypeId { get; set; }
        public string BerichtTypeCode { get; set; }
        public string BerichtTypeNaam { get; set; }
#nullable enable
        public string? BerichtTypeTekst { get; set; }
#nullable disable
        public virtual ICollection<HoofdBericht> HoofdBerichten { get; set; } = new List<HoofdBericht>();
    }
}
