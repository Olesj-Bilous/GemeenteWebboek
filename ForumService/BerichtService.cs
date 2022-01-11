using ForumData.Entities;
using ForumData.Repositories.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ForumService
{
    public class BerichtService
    {
        //INJECTION
        private IBerichtRepository berichtRepository;
        public BerichtService(IBerichtRepository berichtRepository) => this.berichtRepository = berichtRepository;

        //METHODS
        public async Task<Bericht> GetBerichtById (int Id)
        {
            return await berichtRepository.GetBerichtByIdAsync(Id);
        }

        public async Task AddBerichtAsync (Bericht newBericht)
        {
            await berichtRepository.AddBerichtAsync(newBericht);
        }

        public async Task DeleteBerichtAsync (Bericht deleteBericht)
        {
            await berichtRepository.DeleteBerichtAsync(deleteBericht);
        }

        public async Task UpdateBerichtAsync (Bericht updateBericht)
        {
            await berichtRepository.UpdateBerichtAsync(updateBericht);
        }

    }
}
