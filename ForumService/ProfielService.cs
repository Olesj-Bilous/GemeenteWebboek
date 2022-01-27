using ForumData.Entities;
using ForumData.Repositories.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ForumService
{
    public class ProfielService
    {
        //INJECTION
        readonly private IProfielRepository profielRepository;
        public ProfielService(IProfielRepository profielRepository) => this.profielRepository = profielRepository;

        //METHODS
        public async Task AddProfielAsync(Profiel nieuwProfiel)
        {
            await profielRepository.AddProfielAsync(nieuwProfiel);
        }

        public async Task DeleteProfielAsync(Profiel deleteProfiel)
        {
            await profielRepository.DeleteProfielAsync(deleteProfiel);
        }

        public async Task<Profiel> GetProfielByPersoonIdAsync(int Id)
        {
             return await profielRepository.GetProfielByPersoonIdAsync(Id);
        }

        public async Task UpdateProfielAsync(Profiel updateProfiel)
        {
            await profielRepository.UpdateProfielAsync(updateProfiel);
        }

        public async Task <IEnumerable<Profiel>> GetAllProfiels()
        {
            return await profielRepository.GetAllProfiels();
        }
    }
}
