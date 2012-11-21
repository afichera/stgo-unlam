using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Persistence.DAO;
using Model;
using System.Data.SqlClient;
using System.Data;
using Model.Exceptions;
using log4net;
using Persistence.Util;

namespace Persistence.DAOImpl
{
    public class RegistracionDAO : BaseDAO, IRegistracionDAO
    {
        private static ILog logger = log4net.LogManager.GetLogger(typeof(RegistracionDAO));
        public List<Registracion> getAll()
        {
            throw new NotImplementedException();
        }

        public Registracion getFindById(long id)
        {
            throw new NotImplementedException();
        }

        public Registracion saveOrUpdate(Registracion entity)
        {
            throw new NotImplementedException();
        }

        public void delete(Registracion entity)
        {
            try
            {
                if (base.conectar())
                {
                    SqlDataReader dataReader;
                    base.Command = new SqlCommand();


                    base.Command.Connection = base.Conexion;
                    Command.CommandText = "DELETE FROM dbo.Registracion WHERE email = @username;";
                    Command.CommandType = CommandType.Text;
                    Command.Parameters.AddWithValue("username", entity.Email);

                    dataReader = Command.ExecuteReader();

                }
                else
                {
                    logger.Error(Constantes.ERROR_BDD_CONEXION);
                    throw new BDDException();
                }
                
            }
            catch (SqlException ex)
            {
                logger.Error("Ocurrio un error al intentar eliminar la registración del usuario: " + entity.Email);
                throw new BDDException("Ocurrio un error al intentar eliminar la registración del usuario previo. Detalle: " + ex.Message);
            }
            finally
            {
                base.desconectar();
            }
        }

        public Registracion getFindByUserName(string userName)
        {
            Registracion registracion = null;
            try
            {
                if (base.conectar())
                {
                    SqlDataReader dataReader;
                    base.Command = new SqlCommand();

                    base.Command.Connection = base.Conexion;
                    Command.CommandText = "SELECT r.razonSocial, r.email, r.cuit, r.telefono, r.fechaHoraRegistro, r.pendiente, r.link FROM Registracion r WHERE r.email = @userName";
                    Command.CommandType = CommandType.Text;
                    Command.Parameters.AddWithValue("userName", userName);
                    dataReader = Command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        registracion = new Registracion();
                        registracion.RazonSocial = dataReader.GetSqlString(0).ToString();
                        registracion.Email = dataReader.GetSqlString(1).ToString();
                        registracion.Cuit = dataReader.GetSqlString(2).ToString();
                        registracion.Telefono = dataReader.GetSqlString(3).ToString();
                        registracion.FechaHoraRegistro = DateTime.Parse(dataReader.GetSqlDateTime(4).ToString());
                        registracion.Pendiente = Convert.ToBoolean(dataReader.GetSqlByte(5).Value);
                        registracion.linkActivacion = new Guid(dataReader.GetSqlGuid(6).ToString());
                    }
                }
                else
                {
                    logger.Error(Constantes.ERROR_BDD_CONEXION);
                    throw new BDDException();
                }
                return registracion;
            }
            catch (SqlException ex)
            {
                logger.Error("Ocurrio un error al intentar obtener la Registración de la Base de datos. Detalle: " + ex.Message);
                throw new BDDException("Ocurrio un error al intentar obtener la Registración de la Base de datos. Detalle: " + ex.Message);
            }
            finally
            {
                base.desconectar();
            }

        }


        public void crearPendiente(Registracion entity, Guid guid)
        {
            Registracion registracion = entity;
            try
            {
                if (base.conectar())
                {

                    string sp = "SP_REGISTRACION_CREAR_PENDIENTE";
                    SqlCommand Command = new SqlCommand(sp, base.Conexion);
                    Command.CommandType = CommandType.StoredProcedure;
                    SqlParameter paramUserId = new SqlParameter("userId", SqlDbType.UniqueIdentifier);
                    SqlParameter paramTelefono = new SqlParameter("telefono", SqlDbType.VarChar);
                    SqlParameter paramCuit = new SqlParameter("cuit", SqlDbType.VarChar);
                    SqlParameter paramRazonSocial = new SqlParameter("razonSocial", SqlDbType.VarChar);

                    paramUserId.Direction = ParameterDirection.Input;
                    paramUserId.Value = guid;

                    paramTelefono.Direction = ParameterDirection.Input;
                    paramTelefono.Value = registracion.Telefono;

                    paramCuit.Direction = ParameterDirection.Input;
                    paramCuit.Value = registracion.Cuit;

                    paramRazonSocial.Direction = ParameterDirection.Input;
                    paramRazonSocial.Value = registracion.RazonSocial;

                    Command.Parameters.Add(paramUserId);
                    Command.Parameters.Add(paramTelefono);
                    Command.Parameters.Add(paramCuit);
                    Command.Parameters.Add(paramRazonSocial);

                    int filasAfectadas = Command.ExecuteNonQuery();

                }
                else
                {
                    logger.Error(Constantes.ERROR_BDD_CONEXION);
                    throw new BDDException();
                }

            }
            catch (SqlException ex)
            {
                logger.Error("Ocurrio un error al intentar crear la registración pendiente en la Base de Datos. Detalle: " + ex.Message);
                throw new BDDException("Ocurrio un error al intentar crear la registración pendiente en la Base de Datos. Detalle: " + ex.Message);
            }
            finally
            {

                base.desconectar();
            }

        }


        public Registracion getFindByActivationKey(Guid activationKey)
        {
            Registracion registracion = null;
            try
            {
                if (base.conectar())
                {
                    SqlDataReader dataReader;
                    base.Command = new SqlCommand();

                    base.Command.Connection = base.Conexion;
                    Command.CommandText = "SELECT r.razonSocial, r.email, r.cuit, r.telefono, r.fechaHoraRegistro, r.pendiente, r.link FROM Registracion r WHERE r.link= @key";
                    Command.CommandType = CommandType.Text;
                    Command.Parameters.AddWithValue("key", activationKey);
                    dataReader = Command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        registracion = new Registracion();
                        registracion.RazonSocial = dataReader.GetSqlString(0).ToString();
                        registracion.Email = dataReader.GetSqlString(1).ToString();
                        registracion.Cuit = dataReader.GetSqlString(2).ToString();
                        registracion.Telefono = dataReader.GetSqlString(3).ToString();
                        registracion.FechaHoraRegistro = DateTime.Parse(dataReader.GetSqlDateTime(4).ToString());
                        registracion.Pendiente = Convert.ToBoolean(dataReader.GetSqlByte(5).Value);
                        registracion.linkActivacion = new Guid(dataReader.GetSqlGuid(6).ToString());
                    }
                }
                else
                {
                    logger.Error(Constantes.ERROR_BDD_CONEXION);
                    throw new BDDException();
                }
                return registracion;
            }
            catch (SqlException ex)
            {
                logger.Error("Ocurrio un error al obtener la Registracion por clave de activación. Detalle: " + ex.Message);
                throw new BDDException("Ocurrio un error al obtener la Registracion por clave de activación. Detalle: " + ex.Message);
            }
            finally
            {
                base.desconectar();
            }
        }

        public void activarCuenta(Guid activationKey)
        {
            try
            {
                if (base.conectar())
                {
                    string sp = "SP_ACTIVAR_CUENTA";
                    SqlCommand Command = new SqlCommand(sp, base.Conexion);
                    Command.CommandType = CommandType.StoredProcedure;
                    SqlParameter paramKeyId = new SqlParameter("key", SqlDbType.UniqueIdentifier);
                    paramKeyId.Direction = ParameterDirection.Input;
                    paramKeyId.Value = activationKey;

                    Command.Parameters.Add(paramKeyId);

                    int filasAfectadas = Command.ExecuteNonQuery();
                    base.desconectar();
                    if (filasAfectadas < 1)
                    {
                        logger.Error("Error al activar cuenta.");
                        throw new BusinessException("Error al activar cuenta.");
                    }
                }
            }
            catch (SqlException ex)
            {
                logger.Error("Ocurrio un error al intentar activar la cuenta"+ex.Message);
                throw new BDDException("Ocurrio un error al intentar activar la cuenta" + ex.Message);
            }
            finally
            {
                base.desconectar();
            }

        }
    }
}
