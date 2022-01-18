using ForumData.Entities;
using ForumData.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumService
{
    public class GemeenteService
    {
        //INJECTIE
        private IGemeenteRepository gemeenteRepository;
        public GemeenteService(IGemeenteRepository gemeenteRepository) => this.gemeenteRepository = gemeenteRepository;

        //METHODS
        public async Task<List<Gemeente>> GetGemeenteMet1FilterToListAsync(string filter)
        {
            return await gemeenteRepository.GetGemeentesMet1FilterToListAsync(filter);
        }

        public async Task<Gemeente> GetGemeenteByIdAsync(int Id)
        {
            return await gemeenteRepository.GetGemeenteByIdAsync(Id);
        }
        public List<Gemeente> GetGemeenten()
        {
            return gemeenteRepository.GetGemeenten();
        }

        public List<Gemeente> GetGemeentenByFilter(string filter)
        {
            return GetGemeenten()
                .Where(g => g.GemeenteNaam.Contains(filter, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        public Gemeente GetGemeenteById(int id)
        {
            return gemeenteRepository.GetGemeenteById(id);
        }
    }
}
