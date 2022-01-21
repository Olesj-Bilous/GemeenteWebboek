using ForumData.Entities;
using System.Collections.Generic;

namespace ForumData.Repositories.Interface
{
    public interface IProfielInteresseRepository
    {
        List<ProfielInteresse> GetAll();

        ProfielInteresse GetById(int id);

        void AddRange(List<ProfielInteresse> profielInteresses);

        void UpdateRange(List<ProfielInteresse> profielInteresses);

        void Delete(ProfielInteresse pi);
    }
}
