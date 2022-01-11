using ForumData.Entities;
using ForumData.Repositories.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ForumService
{
    public class AfdelingService
    {
        //INJECTION
        private IAfdelingRepository afdelingRepository;
        public AfdelingService(IAfdelingRepository afdelingRepository) => this.afdelingRepository = afdelingRepository;

        //METHODS
        public async Task<Afdeling> GetAfdelingByIdAsync (int Id)
        {
            return await afdelingRepository.GetAfdelingByIdAsync(Id);
        }
    }
}
