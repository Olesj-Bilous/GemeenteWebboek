using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ForumData.Entities;
using ForumData.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace ForumData.Repositories.DbConnect
{
    public class InteresseRepository : IInteresseRepository
    {
        private GemeenteForumDbContext context;
        public InteresseRepository(GemeenteForumDbContext context) => this.context = context;

        public async Task<List<Interesse>> GetInteressesToListAsync()
        {
            return await context.Interesses.ToListAsync();
        }

        public Interesse GetById(int id)
        {
            return context.Interesses.Find(id);
        }

        public List<Interesse> GetInteresses()
        {
            return context.Interesses.ToList();
        }
    }
}
