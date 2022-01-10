using ForumData.Entities;
using ForumData.Repositories.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ForumService
{
    public class TaalService
    {
        //INJECTIE     
        private ITaalRepository taalRepository;
        public TaalService(ITaalRepository taalRepository) => this.taalRepository = taalRepository;

        //METHODS
        public async Task<List<Taal>> GetTalenToListAsync()
        {
            return await taalRepository.GetTalenToListAsync();

        }
    }
}
