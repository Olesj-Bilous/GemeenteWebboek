using ForumData.Entities;
using ForumData.Repositories.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace ForumService
{
    public class BerichtTypeService
    {
        //INJECTIE
        private IBerichtTypeRepository berichtTypeRepository;
        public BerichtTypeService(IBerichtTypeRepository berichtTypeRepository) => this.berichtTypeRepository = berichtTypeRepository;

        //METHODS
        public async Task<BerichtThema> GetBerichtTypeByIdAsync(int Id)
        {
            return await berichtTypeRepository.GetBerichtTypeByIdAsync(Id);
        }

        public async Task AddBerichtTypeAsync (BerichtThema nieuwBerichtType)
        {
            await berichtTypeRepository.AddBerichtTypeAsync(nieuwBerichtType);
        }

        public async Task DeleteBerichtTypeAsync (BerichtThema deleteBerichtType)
        {
            await berichtTypeRepository.DeleteBerichtTypeAsync(deleteBerichtType);
        }
    }
}
