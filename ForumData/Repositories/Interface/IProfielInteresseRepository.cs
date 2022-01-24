using ForumData.Entities;
using System.Collections.Generic;

namespace ForumData.Repositories.Interface
{
    public interface IProfielInteresseRepository
    {
        List<ProfielInteresse> GetAll();

        ProfielInteresse GetByProfielIdAndInteresseId(int profielId, int interesseId);

        void AddRange(List<ProfielInteresse> profielInteresses);

        void UpdateRange(List<ProfielInteresse> profielInteresses);

        void Delete(ProfielInteresse pi);
    }
}
