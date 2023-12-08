using Catalogo.Dominio.DTO.Articulo;
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
    public class ArticuloServices : IArticuloServices
    {
        #region Attributes
        private IUnitOfWork _unitOfWork;
        #endregion

        #region Builder
        public ArticuloServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region Methods
        public List<ArticuloDto> GetAll()
        {
            using (var connection = _unitOfWork.Create())
            {
                IEnumerable<ArticuloEntity> list = connection.Repositories.ArticuloRepository.GetAll();

                List<ArticuloDto> articulos = list.Select(x => new ArticuloDto
                {
                    Id = x.Id,
                    Codigo = x.Codigo ?? "",
                    Nombre = x.Nombre ?? "",
                    Descripcion = x.Descripcion ?? "",
                    Marca = getMarca(x.IdMarca),
                    Categoria = getCategoria(x.IdCategoria),
                    Imagen = GetImages(x.Id),
                    Precio = x.Precio
                }).ToList();

                return articulos;
            }
            
        }

        public ArticuloDto GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(AddArticuloDto articulo)
        {
            throw new NotImplementedException();
        }

        public void Update(ArticuloDto articulo)
        {
            throw new NotImplementedException();
        }
        private List<string> GetImages(int idArticulo)
        {
            try
            {
                using (var connection = _unitOfWork.Create())
                {
                    List<string> images = connection.Repositories.ImagenRepository.GetByIdArticulo(idArticulo);
                    if (images.Count == 0)
                        images.Add("");
                    return images;
                }
                }
            catch (Exception ex)
            {
               throw ex;
            }
        }

        private string getMarca(int idMarca)
        {
            try
            {
                using (var connection = _unitOfWork.Create())
                {
                    string marca = connection.Repositories.MarcaRepository.Get(idMarca).Descripcion;

                    return marca;
                }
            }
            catch (Exception)
            {
                return "Marca no encontrada";
            }
        }

        private string getCategoria(int idCategoria)
        {
            try
            {
                using (var connection = _unitOfWork.Create())
                {
                    string categoria = connection.Repositories.CategoriaRepository.Get(idCategoria).Descripcion;

                    return categoria;
                }
            }
            catch (Exception)
            {
                return "Categoria no encontrada";
            }
        }
        #endregion
    }
}
