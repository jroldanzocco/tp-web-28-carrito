using Infraestructure.Core.Repository.Interface;
using Infraestructure.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Infraestructure.Core.Repository
{
    public class ImagenRepository : Repository, IImagenRepository
    {

        #region Builder
        public ImagenRepository(SqlConnection connection, SqlTransaction transaction)
        {
            _connection = connection;
            _transaction = transaction;
        }
        #endregion

        #region Methods
        public void Add(ImagenEntity entity)
        {
            try
            {
                var command = CrearComando("INSERT INTO IMAGENES VALUES (@idArticulo,@imagenUrl)");

                command.Parameters.AddWithValue("@idArticulo", entity.IdArticulo);
                command.Parameters.AddWithValue("@imagenUrl", entity.ImagenUrl);

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(int id)
        {
            try
            {
                var command = CrearComando("DELETE FROM IMAGENES WHERE Id = @id");
                command.Parameters.AddWithValue("@id", id);

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ImagenEntity Get(int id)
        {
            try
            {
                var command = CrearComando("SELECT Id, IdArticulo, ImagenUrl FROM IMAGENES WHERE Id = @id");

                command.Parameters.AddWithValue("@id", id);

                using (var lector = command.ExecuteReader())
                {
                    lector.Read();

                    return new ImagenEntity
                    {
                        Id = (int)lector["Id"],
                        IdArticulo = (int)lector["IdArticulo"],
                        ImagenUrl = lector["Nombre"].ToString(),
                    };
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<ImagenEntity> GetAll()
        {
            var listaImagenes = new List<ImagenEntity>();

            try
            {
                var command = CrearComando("SELECT Id, IdArticulo, ImagenUrl FROM IMAGENES");

                using (var lector = command.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        listaImagenes.Add(new ImagenEntity
                        {
                            Id = (int)lector["Id"],
                            IdArticulo = (int)lector["IdArticulo"],
                            ImagenUrl = lector["Nombre"].ToString(),
                        });
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return listaImagenes;
        }

        public List<string> GetByIdArticulo(int idArticulo)
        {
            var listaImagenes = new List<string>();

            try
            {
                var command = CrearComando("SELECT ImagenUrl FROM IMAGENES WHERE idArticulo = @idArticulo");
                command.Parameters.AddWithValue("@idArticulo", idArticulo);


                using (var lector = command.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        listaImagenes.Add(
                        lector["ImagenUrl"].ToString()
                        );
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return listaImagenes;
        }

        public void Update(ImagenEntity entity)
        {
            try
            {
                var command = CrearComando("UPDATE IMAGENES SET IdArticulo = @idArticulo, ImagenUrl = @imagenUrl WHERE ID = @id");

                command.Parameters.AddWithValue("@id", entity.Id);
                command.Parameters.AddWithValue("@idArticulo", entity.IdArticulo);
                command.Parameters.AddWithValue("@imagenUrl", entity.ImagenUrl);

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion
    }
}
