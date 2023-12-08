using Infraestructure.Core.Repository;
using Infraestructure.Core.Repository.Interface;
using Infraestructure.Core.UnitOfWork.Interface;
using System.Data.SqlClient;

namespace Infraestructure.Core.UnitOfWork
{
    public class UnitOfWorkRepository : IUnitOfWorkRepository
    {
        public IArticuloRepository ArticuloRepository { get; }
        public ICategoriaRepository CategoriaRepository { get; }
        public IImagenRepository ImagenRepository { get; }
        public IMarcaRepository MarcaRepository { get; }
        public UnitOfWorkRepository(SqlConnection connection, SqlTransaction transaction)
        {
            ArticuloRepository = new ArticuloRepository(connection, transaction);
            CategoriaRepository = new CategoriaRepository(connection, transaction);
            ImagenRepository = new ImagenRepository(connection, transaction);
            MarcaRepository = new MarcaRepository(connection, transaction);
        }

        
    }
}
