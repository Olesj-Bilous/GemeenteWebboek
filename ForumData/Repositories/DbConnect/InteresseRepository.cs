using System.Collections.Generic;
using System.Threading.Tasks;
using ForumData.Entities;
using ForumData.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace ForumData.Repositories.DbConnect
{
    public class InteresseRepository : IInteresseRepository
    {
        readonly private GemeenteForumDbContext context;
        public InteresseRepository(GemeenteForumDbContext context) => this.context = context;

        public async Task<List<Interesse>> GetInteressesToListAsync()
        {
            return await context.Interesses.ToListAsync();
        }
    }
}
