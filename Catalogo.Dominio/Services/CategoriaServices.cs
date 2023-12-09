using Catalogo.Dominio.DTO.Articulo;
using Catalogo.Dominio.DTO.Categoria;
using Catalogo.Dominio.DTO.Marca;
using Catalogo.Dominio.Services.Interface;
using Infraestructure.Core.UnitOfWork.Interface;
using Infraestructure.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogo.Dominio.Services
{
    public class CategoriaServices : ICategoriaServices
    {
        #region Attributes
        private IUnitOfWork _unitOfWork;
        #endregion

        #region Builder
        public CategoriaServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region Methods
        public List<CategoriaDto> GetAll()
        {
            using (var connection = _unitOfWork.Create())
            {
                IEnumerable<CategoriaEntity> list = connection.Repositories.CategoriaRepository.GetAll();

                List<CategoriaDto> categorias = list.Select(x => new CategoriaDto
                {
                    Id = x.Id,
                    Descripcion = x.Descripcion ?? "",
                }).ToList();

                return categorias;
            }
        }

        public void Insert(AddCategoriaDto addCategoriaDto)
        {
            using (var connection = _unitOfWork.Create())
            {
                CategoriaEntity categoria = new CategoriaEntity
                {
                    Descripcion = addCategoriaDto.Descripcion,
                };

                connection.Repositories.CategoriaRepository.Add(categoria);

                connection.SaveChanges();
            }
        }
        #endregion
    }
}
