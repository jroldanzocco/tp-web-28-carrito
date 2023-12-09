using Catalogo.Dominio.DTO.Articulo;
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
    public class MarcaServices : IMarcaServices
    {
        #region Attributes
        private IUnitOfWork _unitOfWork;
        #endregion

        #region Builder
        public MarcaServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region Methods
        public List<MarcaDto> GetAll()
        {
            using (var connection = _unitOfWork.Create())
            {
                IEnumerable<MarcaEntity> list = connection.Repositories.MarcaRepository.GetAll();

                List<MarcaDto> marcas = list.Select(x => new MarcaDto
                {
                    Id = x.Id,
                    Descripcion = x.Descripcion ?? "",
                    }).ToList();

                return marcas;
            }
        }

        public void Insert(AddMarcaDto marcaDto)
        {
            using (var connection = _unitOfWork.Create())
            {
                MarcaEntity marca = new MarcaEntity
                {
                    Descripcion = marcaDto.Descripcion,
                };

                connection.Repositories.MarcaRepository.Add(marca);

                connection.SaveChanges();
            }
        }
        #endregion
    }
}
