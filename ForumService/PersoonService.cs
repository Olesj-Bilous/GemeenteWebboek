using ForumData.Entities;
using ForumData.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumService
{
    public class PersoonService
    {
        private readonly IPersoonRepository repo;
        public PersoonService(IPersoonRepository repo) => this.repo = repo;

        //repo methods
        public List<Persoon> GetAll() => repo.GetAll();

        //sync methods
        public Persoon GetByLoginNaamAndPaswoord(string naam, string pas)
            => GetAll()
                .Where(p => p.LoginNaam == naam && p.LoginPaswoord == pas)
                .FirstOrDefault();
    }
}
