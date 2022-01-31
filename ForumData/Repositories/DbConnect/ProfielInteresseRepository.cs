using ForumData.Entities;
using ForumData.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Linq;

namespace ForumData.Repositories.DbConnect
{
    public class ProfielInteresseRepository : IProfielInteresseRepository
    {
        readonly private GemeenteForumDbContext context;
        public ProfielInteresseRepository(GemeenteForumDbContext context) => this.context = context;

        public void AddRange(List<ProfielInteresse> profielInteresses)
        {
            context.ProfielenInteresses.AddRange(profielInteresses);
            context.SaveChanges();
        }
        public void UpdateRange(List<ProfielInteresse> profielInteresses)
        {
            foreach (ProfielInteresse pi in profielInteresses)
            {
                EntityEntry<ProfielInteresse> newPi = context.ProfielenInteresses.Attach(pi);
                newPi.State = EntityState.Modified;
            }
            context.SaveChanges();
        }

        public ProfielInteresse GetByProfielIdAndInteresseId(int profielId, int interesseId)
        {
            return context.ProfielenInteresses.Find(profielId, interesseId);
        }
        public void Delete(ProfielInteresse pi)
        {
            context.ProfielenInteresses.Remove(pi);
        }

        public List<ProfielInteresse> GetAll()
        {
            return context.ProfielenInteresses.ToList();
        }
    }
}
