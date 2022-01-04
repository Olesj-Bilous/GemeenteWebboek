using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumData.Entities
{
    public class Medewerker : Persoon
    {
        public int AfdelingId { get; set; }
        public virtual Afdeling Afdeling { get; set; }
    }
}
