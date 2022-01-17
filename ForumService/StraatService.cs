using ForumData.Entities;
using ForumData.Repositories.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumService
{
    public class StraatService
    {   
        //INJECTIE
        private IStraatRepository straatRepository;
        public StraatService(IStraatRepository straatRepository) => this.straatRepository = straatRepository;

        //METHODS
        public async Task<List<Straat>> GetStratenMet2FiltersToList(string filter1, string filter2)
        {
            return await straatRepository.GetStratenMet2FiltersToListAsync(filter1, filter2);
        }

        public List<Straat> GetStraten()
        {
            return straatRepository.GetStraten();
        }

        public List<Straat> GetStratenByGemeenteIdAndFilter(int gemeenteId, string filter)
        {
            return GetStraten().Where(s => s.GemeenteId == gemeenteId && s.StraatNaam.Contains(filter)).ToList();
        }
    }
}
