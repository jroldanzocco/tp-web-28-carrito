using Infraestructure.Core.Repository.Interface.Actions;
using Infraestructure.Entity;

namespace Infraestructure.Core.Repository.Interface
{
    public interface IMarcaRepository : IReadRepository<MarcaEntity,int>, ICreateRepository<MarcaEntity>, IUpdateRepository<MarcaEntity>, IRemoveRepository<int>
    {
    }
}
