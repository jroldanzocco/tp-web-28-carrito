using Infraestructure.Core.UnitOfWork.Interface;

namespace Infraestructure.Core.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Methods
        public IUnitOfWorkAdapter Create()
        {
            return new UnitOfWorkAdapter();
        }
        #endregion
    }
}
