using Infraestructure.Core.Repository.Interface.Actions;
using Infraestructure.Entity;

namespace Infraestructure.Core.Repository.Interface
{
    public interface ICategoriaRepository : IReadRepository<CategoriaEntity,int>, ICreateRepository<CategoriaEntity>, IUpdateRepository<CategoriaEntity>, IRemoveRepository<int>
    {
    }
}
