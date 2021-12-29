using ForumData.Models;
using ForumData.Repositories.Interface;

namespace ForumData.Repositories.DbConnect
{
    public class ProfielInteresseRepository : IProfielInteresse
    {
        private GemeenteForumDbContext context;
        public ProfielInteresseRepository(GemeenteForumDbContext context) => this.context = context;

    }
}
