using Catalogo.Dominio.DTO.Imagen;
using Catalogo.Dominio.Services.Interface;
using Infraestructure.Core.UnitOfWork.Interface;
using Infraestructure.Entity;

namespace Catalogo.Dominio.Services
{
    public class ImagenServices : IImagenServices
    {
        #region Attributes
        private IUnitOfWork _unitOfWork;
        #endregion

        #region Builder
        public ImagenServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region Methods
        public void Insert(AddImagenDto addImagenDto)
        {
            if (addImagenDto.ImagenUrl.Count > 0)
            {
                using (var connection = _unitOfWork.Create())
                {
                    foreach (string imagenUrl in addImagenDto.ImagenUrl)
                    {
                        ImagenEntity imagen = new ImagenEntity
                        {
                            IdArticulo = addImagenDto.IdArticulo,
                            ImagenUrl = imagenUrl,
                        };
                        connection.Repositories.ImagenRepository.Add(imagen);
                    }

                    connection.SaveChanges();
                }
            }
        }

        public void Update(AddImagenDto imagenDto)
        {
            
        }
        #endregion
    }
}
