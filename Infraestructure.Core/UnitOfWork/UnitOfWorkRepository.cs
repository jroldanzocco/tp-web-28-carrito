using Infraestructure.Core.UnitOfWork.Interface;
using System.Data.SqlClient;

namespace Infraestructure.Core.UnitOfWork
{
    public class UnitOfWorkRepository : IUnitOfWorkRepository
    {
        //public IProveedorRepository ProveedorRepository { get; }
        //public ICategoriaIvaRepository CategoriaIvaRepository { get; }
        public UnitOfWorkRepository(SqlConnection connection, SqlTransaction transaction)
        {
            //ProveedorRepository = new ProveedorRepository(connection, transaction);
            //CategoriaIvaRepository = new CategoriaIvaRepository(connection, transaction);
        }
    }
}
