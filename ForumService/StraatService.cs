using ForumData.Entities;
using ForumData.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumService
{
    public class StraatService
    {   
        //INJECTIE
        readonly private IStraatRepository straatRepository;
        public StraatService(IStraatRepository straatRepository) => this.straatRepository = straatRepository;

        //METHODS
        public async Task<List<Straat>> GetStratenMet2FiltersToList(string filter1, string filter2)
        {
            return await straatRepository.GetStratenMet2FiltersToListAsync(filter1, filter2);
        }

        public Straat GetStraatById(int id)
        {
            return straatRepository.GetStraatById(id);
        }

        public List<Straat> GetStraten()
        {
            return straatRepository.GetStraten();
        }

        public List<Straat> GetStratenByGemeenteIdAndFilter(int gemeenteId, string filter)
        {
            return GetStraten()
                .Where(s 
                    => s.GemeenteId == gemeenteId 
                    && s.StraatNaam.Contains(filter, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        //public Straat GetStraatByNaamAndGemeente(string naam, Gemeente gemeente)
        //{
        //    return GetStraten().Where(s => s.StraatNaam == naam && s.Gemeente == gemeente).FirstOrDefault();
        //}
    }
}
