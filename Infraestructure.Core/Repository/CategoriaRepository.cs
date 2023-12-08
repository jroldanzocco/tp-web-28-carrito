using Infraestructure.Core.Repository.Interface;
using Infraestructure.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Infraestructure.Core.Repository
{
    public class CategoriaRepository : Repository, ICategoriaRepository
    {
        #region Builder
        public CategoriaRepository(SqlConnection connection, SqlTransaction transaction)
        {
            _connection = connection;
            _transaction = transaction;
        }
        #endregion

        #region Methods
        public void Add(CategoriaEntity entity)
        {
            try
            {
                var command = CrearComando("INSERT INTO CATEGORIAS VALUES (@descripcion)");

                command.Parameters.AddWithValue("@descripcion", entity.Descripcion);

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
                var command = CrearComando("DELETE FROM CATEGORIAS WHERE Id = @id");
                command.Parameters.AddWithValue("@id", id);

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public CategoriaEntity Get(int id)
        {
            try
            {
                var command = CrearComando("SELECT Id, Descripcion FROM CATEGORIAS WHERE Id = @id");

                command.Parameters.AddWithValue("@id", id);

                using (var lector = command.ExecuteReader())
                {
                    lector.Read();

                    return new CategoriaEntity
                    {
                        Id = (int)lector["Id"],
                        Descripcion = lector["Descripcion"].ToString(),
                    };
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IEnumerable<CategoriaEntity> GetAll()
        {
            var listaCategorias = new List<CategoriaEntity>();

            try
            {
                var command = CrearComando("SELECT Id, Descripcion FROM CATEGORIAS");

                using (var lector = command.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        listaCategorias.Add(new CategoriaEntity
                        {
                            Id = (int)lector["Id"],
                            Descripcion = lector["Descripcion"].ToString(),
                        });
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return listaCategorias;
        }

        public void Update(CategoriaEntity entity)
        {
            try
            {
                var command = CrearComando("UPDATE CATEGORIAS SET Descripcion = @descripcion WHERE ID = @id");

                command.Parameters.AddWithValue("@id", entity.Id);
                command.Parameters.AddWithValue("@descripcion", entity.Descripcion);

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
