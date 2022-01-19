using ForumData.Entities;
using ForumData.Repositories.Interface;
using System.Collections.Generic;

namespace ForumData.Repositories.DbConnect
{
    public class ProfielInteresseRepository : IProfielInteresseRepository
    {
        private GemeenteForumDbContext context;
        public ProfielInteresseRepository(GemeenteForumDbContext context) => this.context = context;

        public List<ProfielInteresse> GetProfielenInteresses()
        {
            throw new System.NotImplementedException();
        }
    }
}
