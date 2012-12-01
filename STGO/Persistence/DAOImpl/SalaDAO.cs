using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Persistence.DAO;
using Model;
using System.Data.SqlClient;
using System.Data;
using System.Data.SqlTypes;
using log4net;
using Persistence.Util;

namespace Persistence.DAOImpl
{
    public class SalaDAO : BaseDAO, ISalaDAO
    {
        private static ILog logger = log4net.LogManager.GetLogger(typeof(SalaDAO));
        public List<Sala> obtenerSalasEmpresa(long idEmpresa)
        {
            List<Sala> salas = new List<Sala>();
            try
            {
                if (base.conectar())
                {
                    SqlDataReader dataReader;
                    base.Command = new SqlCommand();
                    Sala sala;

                    base.Command.Connection = base.Conexion;
                    Command.CommandText = "SELECT s.id, s.nombre, s.permiteMultiplo, s.frecuencia, s.horaInicio, s.horaFin FROM Sala S WHERE s.empresaId = @empresaId AND s.fechaHoraBaja is null";

                    Command.CommandType = CommandType.Text;
                    Command.Parameters.AddWithValue("empresaId", idEmpresa);

                    dataReader = Command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        sala = new Sala();
                        sala.Id = long.Parse(dataReader.GetSqlInt64(0).ToString());
                        sala.Nombre = dataReader.GetSqlString(1).ToString();
                        sala.PermiteMultiplo = Convert.ToBoolean(dataReader.GetSqlByte(2).Value);
                        sala.Frecuencia = int.Parse(dataReader.GetSqlInt32(3).ToString());
                        sala.HoraInicio = DateTime.Parse(dataReader.GetSqlDateTime(4).ToString());
                        sala.HoraCierre = DateTime.Parse(dataReader.GetSqlDateTime(5).ToString());
                        salas.Add(sala);
                    }


                }
                else
                {
                    logger.Error(Constantes.ERROR_BDD_CONEXION);
                    throw new BDDException();
                }
                return salas;

            }
            catch (SqlException ex)
            {
                logger.Error("Ocurrio un error al intentar obtener las salas de la empresa con id: " + idEmpresa + ". Detalle: " + ex.StackTrace);
                throw new BDDException("Ocurrio un error al intentar obtener las salas de la base de datos. Detalle: " + ex.Message);
            }
            finally
            {
                base.desconectar();
            }
        }
        public List<Sala> getAll()
        {
            List<Sala> salas = new List<Sala>();
            try
            {
                if (base.conectar())
                {
                    SqlDataReader dataReader;
                    base.Command = new SqlCommand();
                    Sala sala;

                    base.Command.Connection = base.Conexion;
                    Command.CommandText = "SELECT s.id, s.nombre, s.permiteMultiplo, s.frecuencia, s.horaInicio, s.horaFin FROM Sala S WHERE s.fechaHoraBaja is null";
                    Command.CommandType = CommandType.Text;
                    dataReader = Command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        sala = new Sala();
                        sala.Id = long.Parse(dataReader.GetSqlInt64(0).ToString());
                        sala.Nombre = dataReader.GetSqlString(1).ToString();
                        sala.PermiteMultiplo = Convert.ToBoolean(dataReader.GetSqlByte(2).Value);
                        sala.Frecuencia = int.Parse(dataReader.GetSqlInt32(3).ToString());
                        sala.HoraInicio = DateTime.Parse(dataReader.GetSqlDateTime(4).ToString());
                        sala.HoraCierre = DateTime.Parse(dataReader.GetSqlDateTime(5).ToString());
                        salas.Add(sala);
                    }

                }
                else
                {
                    logger.Error(Constantes.ERROR_BDD_CONEXION);
                    throw new BDDException();
                }
                return salas;

            }
            catch (SqlException ex)
            {
                logger.Error("Ocurrio un error al intentar obtener todas las salas de la Base de datos. Detalle: " + ex.StackTrace);
                throw new BDDException("Ocurrio un error al intentar obtener todas las salas de la Base de datos. Detalle: " + ex.Message);

            }
            finally
            {
                base.desconectar();
            }

        }
        public Sala getFindById(long id)
        {
            Sala sala = null;
            
            try
            {
                if (base.conectar())
                {
                    SqlDataReader dataReader;
                    base.Command = new SqlCommand();

                    base.Command.Connection = base.Conexion;
                    Command.CommandText = "SELECT s.id, s.nombre, s.permiteMultiplo, s.frecuencia, s.horaInicio, s.horaFin, s.empresaId FROM Sala S WHERE s.id = @id and s.fechaHoraBaja is null";

                    Command.CommandType = CommandType.Text;
                    Command.Parameters.AddWithValue("id", id);

                    dataReader = Command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        sala = new Sala();
                        sala.Id = long.Parse(dataReader.GetSqlInt64(0).ToString());
                        sala.Nombre = dataReader.GetSqlString(1).ToString();
                        sala.PermiteMultiplo = Convert.ToBoolean(dataReader.GetSqlByte(2).Value);
                        sala.Frecuencia = int.Parse(dataReader.GetSqlInt32(3).ToString());
                        sala.HoraInicio = DateTime.Parse(dataReader.GetSqlDateTime(4).ToString());
                        sala.HoraCierre = DateTime.Parse(dataReader.GetSqlDateTime(5).ToString());
                        sala.EmpresaId = long.Parse(dataReader.GetSqlInt64(6).ToString());
                        
                    }

                }
                else
                {
                    logger.Error(Constantes.ERROR_BDD_CONEXION);
                    throw new BDDException();
                }
                return sala;

            }
            catch (SqlException ex)
            {
                logger.Error("Ocurrió un error al intentar obtener la sala con id: " + id + ". Detalle: " + ex.StackTrace);
                throw new BDDException("Ocurrió un error al intentar obtener la sala. Detalle: " + ex.Message);
            }
            finally
            {
                base.desconectar();
            }

        }

        public Sala saveOrUpdate(Sala entity, long empresaId)
        {
            Sala sala = entity;
            try
            {
                if (base.conectar())
                {

                    string sp = "SP_SALA_SAVE_OR_UPDATE";
                    SqlCommand Command = new SqlCommand(sp, base.Conexion);
                    Command.CommandType = CommandType.StoredProcedure;
                    SqlParameter paramId = new SqlParameter("id", SqlDbType.BigInt);
                    SqlParameter paramFrecuencia = new SqlParameter("frecuencia", SqlDbType.Int);
                    SqlParameter paramHoraCierre = new SqlParameter("horaCierre", SqlDbType.DateTime);
                    SqlParameter paramHoraInicio = new SqlParameter("horaInicio", SqlDbType.DateTime);
                    SqlParameter paramNombre = new SqlParameter("nombre", SqlDbType.VarChar);
                    SqlParameter paramPermiteMultiplo = new SqlParameter("permiteMultiplo", SqlDbType.TinyInt);
                    SqlParameter paramEmpresaId = new SqlParameter("empresaId", SqlDbType.BigInt);
                    paramId.Direction = ParameterDirection.InputOutput;
                    paramId.Value = sala.Id;
                    paramFrecuencia.Direction = ParameterDirection.Input;
                    paramFrecuencia.Value = sala.Frecuencia;
                    paramHoraCierre.Direction = ParameterDirection.Input;
                    paramHoraCierre.Value = sala.HoraCierre;
                    paramHoraInicio.Direction = ParameterDirection.Input;
                    paramHoraInicio.Value = sala.HoraInicio;
                    paramNombre.Direction = ParameterDirection.Input;
                    paramNombre.Value = sala.Nombre;
                    paramPermiteMultiplo.Direction = ParameterDirection.Input;
                    paramPermiteMultiplo.Value = sala.PermiteMultiplo;
                    paramEmpresaId.Direction = ParameterDirection.Input;
                    paramEmpresaId.Value = empresaId;

                    Command.Parameters.Add(paramId);
                    Command.Parameters.Add(paramFrecuencia);
                    Command.Parameters.Add(paramHoraCierre);
                    Command.Parameters.Add(paramHoraInicio);
                    Command.Parameters.Add(paramNombre);
                    Command.Parameters.Add(paramPermiteMultiplo);
                    Command.Parameters.Add(paramEmpresaId);

                    int filasAfectadas = Command.ExecuteNonQuery();

                    sala.Id = long.Parse(Command.Parameters["id"].Value.ToString());

                }
                else
                {
                    logger.Error(Constantes.ERROR_BDD_CONEXION);
                    throw new BDDException();
                }
                return sala;

            }
            catch (SqlException ex)
            {
                logger.Error("Ocurrio un error al intentar guardar la sala: " + sala.Nombre + " de la empresa id:" + empresaId + " en la base de datos. Detalle: " + ex.StackTrace);
                throw new BDDException("Ocurrio un error al intentar guardar la sala en la base de datos. Detalle: " + ex.Message);
            }
            finally
            {
                base.desconectar();
            }

        }

        public Sala saveOrUpdate(Sala entity)
        {
            throw new NotImplementedException();
        }
        public void delete(Sala entity)
        {
            Sala sala = entity;

            if (base.conectar())
            {
                string sp = "SP_SALA_DELETE";
                SqlCommand Command = new SqlCommand(sp, base.Conexion);
                Command.CommandType = CommandType.StoredProcedure;
                SqlParameter paramId = new SqlParameter("id", SqlDbType.BigInt);
                paramId.Direction = ParameterDirection.Input;
                paramId.Value = sala.Id;
                Command.Parameters.Add(paramId);
                int filasAfectadas = Command.ExecuteNonQuery();
                base.desconectar();
            }
        }

        public int cantidadSalasEmpresa(long idEmpresa)
        {
            int cantidad = 0;
            try
            {
                if (base.conectar())
                {
                    base.Command = new SqlCommand();
                    base.Command.Connection = base.Conexion;
                    Command.CommandText = "SELECT COUNT(s.id) as cant FROM Sala S WHERE s.empresaId = @empresaId AND s.fechaHoraBaja is null";

                    Command.CommandType = CommandType.Text;
                    Command.Parameters.AddWithValue("empresaId", idEmpresa);

                    cantidad = Convert.ToInt32(Command.ExecuteScalar());

                }
                else {
                    logger.Error(Constantes.ERROR_BDD_CONEXION);
                    throw new BDDException();
                }
                return cantidad;

            }
            catch (SqlException ex)
            {
                logger.Error("Ocurrio un error al intentar obtener la cantidad de salas para la empresa id: "+idEmpresa+". Detalle: "+ex.StackTrace);
                throw new BDDException("Ocurrio un error al intentar obtener la cantidad de salas de la empresa. Detalle: "+ex.Message);
            }
            finally {
                base.desconectar();            
            }

        }
    }
}
