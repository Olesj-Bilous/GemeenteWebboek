using ForumData.Entities;
using ForumData.Repositories.Interface;
using System.Collections.Generic;
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

    }
}
