using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventTracker.Services
{
    public interface ICommonService<TEntity>
    {
        Task Create(TEntity entity);

        IEnumerable<TEntity> GetAll(bool? withNonActive = false, int? count = null);

        TEntity GetById(int id, bool? withNonActive = false);

        Task Update(TEntity entity);

        Task ChangeActiveStatus(TEntity entity);
    }
}
