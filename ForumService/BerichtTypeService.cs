using ForumData.Entities;
using ForumData.Repositories.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace ForumService
{
    public class BerichtTypeService
    {
        //INJECTIE
        readonly private IBerichtTypeRepository berichtTypeRepository;
        public BerichtTypeService(IBerichtTypeRepository berichtTypeRepository) => this.berichtTypeRepository = berichtTypeRepository;

        //METHODS
        public async Task<BerichtType> GetBerichtTypeByIdAsync(int Id)
        {
            return await berichtTypeRepository.GetBerichtTypeByIdAsync(Id);
        }

        public async Task AddBerichtTypeAsync (BerichtType nieuwBerichtType)
        {
            await berichtTypeRepository.AddBerichtTypeAsync(nieuwBerichtType);
        }

        public async Task DeleteBerichtTypeAsync (BerichtType deleteBerichtType)
        {
            await berichtTypeRepository.DeleteBerichtTypeAsync(deleteBerichtType);
        }
    }
}
