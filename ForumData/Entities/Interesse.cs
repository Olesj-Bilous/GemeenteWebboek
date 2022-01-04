using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumData.Entities
{
    public class Interesse
    {
        public int InteresseId { get; set; }
        public string InteresseNaam { get; set; }

        public virtual ICollection<ProfielInteresse> InteresseProfielen { get; set; } = new List<ProfielInteresse>();
    }
}
