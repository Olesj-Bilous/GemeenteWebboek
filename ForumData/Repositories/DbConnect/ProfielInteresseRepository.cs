using ForumData.Entities;
using ForumData.Repositories.Interface;

namespace ForumData.Repositories.DbConnect
{
    public class ProfielInteresseRepository : IProfielInteresse
    {
        readonly private GemeenteForumDbContext context;
        public ProfielInteresseRepository(GemeenteForumDbContext context) => this.context = context;

    }
}
