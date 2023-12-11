using Infraestructure.Core.Repository.Interface;
using Infraestructure.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Infraestructure.Core.Repository
{
    public class ArticuloRepository : Repository, IArticuloRepository
    {
        #region Builder
        public ArticuloRepository(SqlConnection connection, SqlTransaction transaction)
        {
            _connection = connection;
            _transaction = transaction;
        }
        #endregion

        #region Methods
        public void Add(ArticuloEntity entity)
        {
            try
            {
                var command = CrearComando("INSERT INTO ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, Precio) " +
                                           "VALUES (@codigo,@nombre,@descripcion,@idMarca,@idCategoria,@precio)");

                command.Parameters.AddWithValue("@codigo", entity.Codigo);
                command.Parameters.AddWithValue("@nombre", entity.Nombre);
                command.Parameters.AddWithValue("@descripcion", entity.Descripcion);
                command.Parameters.AddWithValue("@idMarca", entity.IdMarca);
                command.Parameters.AddWithValue("@idCategoria", entity.IdCategoria);
                command.Parameters.AddWithValue("@precio", entity.Precio);

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
                var command = CrearComando("DELETE FROM ARTICULOS WHERE Id = @id");
                command.Parameters.AddWithValue("@id", id);

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ArticuloEntity Get(int id)
        {
            try
            {
                var command = CrearComando("SELECT Id, Codigo, Nombre, Descripcion, IdMarca, IdCategoria, Precio " +
                                           "FROM articulos WHERE Id = @id");

                command.Parameters.AddWithValue("@id", id);

                using (var lector = command.ExecuteReader())
                {
                    lector.Read();

                    return new ArticuloEntity
                    {
                        Id = (int)lector["Id"],
                        Codigo = lector["Codigo"].ToString(),
                        Nombre = lector["Nombre"].ToString(),
                        Descripcion = lector["Descripcion"].ToString(),
                        IdMarca = (int)lector["IdMarca"],
                        IdCategoria = (int)lector["IdCategoria"],
                        Precio = (decimal)lector["Precio"]
                    };
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IEnumerable<ArticuloEntity> GetAll()
        {
            var listaArticulos = new List<ArticuloEntity>();

            try
            {
                var command = CrearComando("SELECT Id, Codigo, Nombre, Descripcion, IdMarca, IdCategoria, Precio " +
                                           "FROM articulos ORDER BY Id DESC");

                using (var lector = command.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        listaArticulos.Add(new ArticuloEntity
                        {
                            Id = (int)lector["Id"],
                            Codigo = lector["Codigo"].ToString(),
                            Nombre = lector["Nombre"].ToString(),
                            Descripcion = lector["Descripcion"].ToString(),
                            IdMarca = (int)lector["IdMarca"],
                            IdCategoria = (int)lector["IdCategoria"],
                            Precio = (decimal)lector["Precio"]
                        });
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return listaArticulos;
        }

        public void Update(ArticuloEntity entity)
        {
            try
            {
                var command = CrearComando("UPDATE ARTICULOS SET Codigo = @codigo, Nombre = @nombre, Descripcion = @descripcion, " +
                                           "IdMarca = @idMarca, IdCategoria = @idCategoria, Precio = @precio " +
                                           "WHERE ID = @id");

                command.Parameters.AddWithValue("@id", entity.Id);
                command.Parameters.AddWithValue("@codigo", entity.Codigo);
                command.Parameters.AddWithValue("@nombre", entity.Nombre);
                command.Parameters.AddWithValue("@descripcion", entity.Descripcion);
                command.Parameters.AddWithValue("@idMarca", entity.IdMarca);
                command.Parameters.AddWithValue("@idCategoria", entity.IdCategoria);
                command.Parameters.AddWithValue("@precio", entity.Precio);

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
