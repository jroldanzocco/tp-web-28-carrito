namespace Infraestructure.Core.Repository.Interface.Actions
{
    public interface ICreateRepository<T> where T : class
    {
        void Add(T entity);
    }
}
