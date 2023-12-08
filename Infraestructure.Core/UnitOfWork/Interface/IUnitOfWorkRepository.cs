using Infraestructure.Core.Repository.Interface;

namespace Infraestructure.Core.UnitOfWork.Interface
{
    public interface IUnitOfWorkRepository
    {
        IArticuloRepository ArticuloRepository { get;} 
        ICategoriaRepository CategoriaRepository { get; } 
        IImagenRepository ImagenRepository { get;}
        IMarcaRepository MarcaRepository { get;}
    }
}
