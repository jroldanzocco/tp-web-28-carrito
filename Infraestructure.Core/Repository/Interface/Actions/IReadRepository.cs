using System.Collections.Generic;

namespace Infraestructure.Core.Repository.Interface.Actions
{
    public interface IReadRepository<T, TKey> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(TKey id);
    }
}
