using ForumData.Entities;
using ForumData.Repositories.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace ForumService
{
    public class BerichtThemaService
    {
        //INJECTIE
        private IBerichtThemaRepository berichtThemaRepository;
        public BerichtThemaService(IBerichtThemaRepository berichtThemaRepository) => this.berichtThemaRepository = berichtThemaRepository;

        //async repo METHODS
        public async Task<BerichtThema> GetBerichtThemaByIdAsync(int Id)
        {
            return await berichtThemaRepository.GetBerichtThemaByIdAsync(Id);
        }

        public async Task AddBerichtThemaAsync(BerichtThema nieuwBerichtThema)
        {
            await berichtThemaRepository.AddBerichtThemaAsync(nieuwBerichtThema);
        }

        public async Task DeleteBerichtThemaAsync(BerichtThema deleteBerichtThema)
        {
            await berichtThemaRepository.DeleteBerichtThemaAsync(deleteBerichtThema);
        }

        //sync repo methods
        public List<BerichtThema> GetAll()
        {
            return berichtThemaRepository.GetAll();
        }
    }
}
