using ForumData.Entities;
using ForumData.Repositories.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ForumService
{
    public class PersoonService
    {
        private IPersoonRepository persoonRepository;
        public PersoonService(IPersoonRepository persoonRepository) => this.persoonRepository = persoonRepository;

       public async Task<Persoon> GetPersoonByLoginNaamAndPaswoordAsync(string Naam, string paswoord)
       {
            return await persoonRepository.GetPersoonByLoginNaamAndPaswoordAsync(Naam, paswoord);
       }

        public async Task<Persoon> GetPersoonByIdAsync(int Id)
        {
            return await persoonRepository.GetPersoonByIdAsync(Id);
        }

        public async Task UpdatePersoonAsync(Persoon updatePersoon)
        {
            await persoonRepository.UpdatePersoonAsync(updatePersoon);
        }
    }
}
