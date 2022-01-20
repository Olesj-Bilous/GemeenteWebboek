using ForumData.Entities;
using ForumData.Repositories.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ForumService
{
    public class ProvincieService
    {
        //INJECTIE
        readonly private IProvincieRepository provincieRepository;
        public ProvincieService(IProvincieRepository provincieRepository) => this.provincieRepository = provincieRepository;

        //METHODS
        public async Task<List<Provincie>> GetProvinciesToListAsync()
        {
            return await provincieRepository.GetProvinciesToListAsync();
        }
    }
}
