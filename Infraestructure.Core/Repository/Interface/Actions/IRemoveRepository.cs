namespace Infraestructure.Core.Repository.Interface.Actions
{
    public interface IRemoveRepository<T>
    {
        void Delete(T id);
    }
}
