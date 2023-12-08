using Infraestructure.Core.Repository.Interface;
using Infraestructure.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Infraestructure.Core.Repository
{
    public class MarcaRepository : Repository, IMarcaRepository
    {
        #region Builder
        public MarcaRepository(SqlConnection connection, SqlTransaction transaction)
        {
            _connection = connection;
            _transaction = transaction;
        }
        #endregion

        #region Methods
        public void Add(MarcaEntity entity)
        {
            try
            {
                var command = CrearComando("INSERT INTO MARCAS VALUES (@descripcion)");

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
                var command = CrearComando("DELETE FROM MARCAS WHERE Id = @id");
                command.Parameters.AddWithValue("@id", id);

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public MarcaEntity Get(int id)
        {
            try
            {
                var command = CrearComando("SELECT Id, Descripcion FROM MARCAS WHERE Id = @id");

                command.Parameters.AddWithValue("@id", id);

                using (var lector = command.ExecuteReader())
                {
                    lector.Read();

                    return new MarcaEntity
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

        public IEnumerable<MarcaEntity> GetAll()
        {
            var listaMarcas = new List<MarcaEntity>();

            try
            {
                var command = CrearComando("SELECT Id, Descripcion " +
                                           "FROM Marcas");

                using (var lector = command.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        listaMarcas.Add(new MarcaEntity
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
            return listaMarcas;
        }

        public void Update(MarcaEntity entity)
        {
            try
            {
                var command = CrearComando("UPDATE MARCAS SET Descripcion = @descripcion WHERE ID = @id");

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
