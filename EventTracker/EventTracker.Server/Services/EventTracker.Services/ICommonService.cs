using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventTracker.Services
{
    public interface ICommonService<TEntity, TInputModel>
    {
        Task Create(TEntity entity);

        IEnumerable<TEntity> GetAll(bool? withNonActive = false, int? count = null);

        TEntity GetById(int id, bool? withNonActive = false);

        Task Update(TEntity entity, TInputModel inputModel);

        Task ChangeActiveStatus(TEntity entity);
    }
}
