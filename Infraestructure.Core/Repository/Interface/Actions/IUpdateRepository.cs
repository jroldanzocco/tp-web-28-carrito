namespace Infraestructure.Core.Repository.Interface.Actions
{
    public interface IUpdateRepository<T> where T : class
    {
        void Update(T entity);
    }
}
