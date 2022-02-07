using ForumData.Entities;
using ForumData.Repositories.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumService
{
    public class PersoonService
    {
        readonly private IPersoonRepository persoonRepository;
        public PersoonService(IPersoonRepository persoonRepository) => this.persoonRepository = persoonRepository;

        //async repo methods
        public async Task<List<Persoon>> GetAllAsync()
        {
            return await persoonRepository.GetAllAsync();
        }

        public async Task<Persoon> GetPersoonByIdAsync(int Id)
        {
            return await persoonRepository.GetPersoonByIdAsync(Id);
        }

        public async Task UpdatePersoonAsync(Persoon updatePersoon)
        {
            await persoonRepository.UpdatePersoonAsync(updatePersoon);
        }

        //custom methods
        public async Task<Persoon> GetByLoginNaamAndPaswoordAsync(string naam, string paswoord)
        {
            List<Persoon> all = await GetAllAsync();
            return all
                .Where(p => p.LoginNaam == naam && p.LoginPaswoord == paswoord)
                .FirstOrDefault();
        }
    }
}
