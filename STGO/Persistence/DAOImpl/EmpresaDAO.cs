﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Persistence.DAO;
using Model;
using System.Data.SqlClient;
using System.Data;
using Model.Exceptions;
using Persistence.Util;

namespace Persistence.DAOImpl
{
    public class EmpresaDAO : BaseDAO, IEmpresaDAO 
    {        
        public List<Empresa> getAll()
        {
            List<Empresa> empresas = new List<Empresa>();
            try
            {
                if (base.Conectar())
                {
                    SqlDataReader dataReader;
                    base.Command = new SqlCommand();
                    Empresa empresa;
                    Usuario usuario;

                    base.Command.Connection = base.Conexion;
                    Command.CommandText = "SELECT e.id, e.activa, e.cuit, e.maximoSalas, e.razonSocial, e.telefono, u.UserName, u.UserId " +
                        "FROM Empresa e " +
                        "INNER JOIN aspnet_Users u ON (u.UserId = e.UserId) WHERE e.fechaHoraBaja is null";

                    Command.CommandType = CommandType.Text;

                    dataReader = Command.ExecuteReader();


                    while (dataReader.Read())
                    {
                        empresa = new Empresa();
                        usuario = new Usuario();

                        empresa.Id = long.Parse(dataReader.GetSqlInt64(0).ToString());
                        empresa.activo = Convert.ToBoolean(dataReader.GetSqlByte(1).Value);
                        empresa.CUIT = dataReader.GetSqlString(2).ToString();
                        empresa.maximoSalas = int.Parse(dataReader.GetSqlInt16(3).ToString());
                        empresa.RazonSocial = dataReader.GetSqlString(4).ToString();
                        empresa.Telefono = dataReader.GetSqlString(5).ToString();
                        usuario.EMail = dataReader.GetSqlString(6).ToString();
                        usuario.Id = new Guid(dataReader.GetSqlGuid(7).ToString());

                        empresa.Usuario = usuario;
                        empresas.Add(empresa);
                    }
                    return empresas;
                }
                else
                {
                    throw new BDDException();
                }
            }
            catch (SqlException ex)
            {
                throw new BDDException("Error al intentar obtener las empresas de la base de datos. Detalle: " + ex.Message);
            }
            finally
            {
                base.Desconectar();
            }
        }
        
        public Empresa getFindById(long id)
        {
            try
            {
                Empresa empresa = null;
                if (base.Conectar())
                {
                    SqlDataReader dataReader;
                    base.Command = new SqlCommand();
                    Usuario usuario;
                    base.Command.Connection = base.Conexion;
                    Command.CommandText = "SELECT e.id, e.activa, e.cuit, e.maximoSalas, e.razonSocial, e.telefono, u.UserName, u.UserId " +
                        "FROM Empresa e " +
                        "INNER JOIN aspnet_Users u ON (u.UserId = e.UserId) WHERE e.id = @id";

                    Command.CommandType = CommandType.Text;
                    Command.Parameters.AddWithValue("id", id);
                    dataReader = Command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        empresa = new Empresa();
                        usuario = new Usuario();
                        empresa.Id = long.Parse(dataReader.GetSqlInt64(0).ToString());
                        empresa.activo = Convert.ToBoolean(dataReader.GetSqlByte(1).Value);
                        empresa.CUIT = dataReader.GetSqlString(2).ToString();
                        empresa.maximoSalas = int.Parse(dataReader.GetSqlInt16(3).ToString());
                        empresa.RazonSocial = dataReader.GetSqlString(4).ToString();
                        empresa.Telefono = dataReader.GetSqlString(5).ToString();
                        usuario.EMail = dataReader.GetSqlString(6).ToString();
                        usuario.Id = new Guid(dataReader.GetSqlGuid(7).ToString());
                        empresa.Usuario = usuario;

                    }

                    return empresa;
                }
                else
                {
                    throw new BDDException();
                }


            }
            catch (SqlException ex)
            {
                throw new BDDException("Error al intentar recuperar la Empresa de la Base de datos. Detalle: "+ex.Message);

            }
            finally {
                base.Desconectar();
            }
        }

        public Empresa saveOrUpdate(Empresa entity)
        {
            throw new NotImplementedException();
        }

        public void delete(Empresa entity)
        {
            Empresa empresa = entity;
            try
            {
                if (base.Conectar())
                {
                    string sp = "SP_EMPRESA_DELETE";
                    SqlCommand Command = new SqlCommand(sp, base.Conexion);
                    Command.CommandType = CommandType.StoredProcedure;
                    SqlParameter paramId = new SqlParameter("id", SqlDbType.BigInt);
                    paramId.Direction = ParameterDirection.Input;
                    paramId.Value = empresa.Id;
                    Command.Parameters.Add(paramId);
                    int filasAfectadas = Command.ExecuteNonQuery();
                }
                else
                {
                    throw new BDDException();
                }
            }
            catch (SqlException ex)
            {
                throw new BDDException("Error al borrar la empresa. Detalle: " + ex.Message);
            }
            finally
            {
                base.Desconectar();
            }

        }

        public Empresa saveOrUpdate(Empresa entity, Guid userIdentification)
        {
            Empresa empresa = entity;
            try
            {
                if (base.Conectar())
                {
                    string sp = "SP_EMPRESA_SAVE_OR_UPDATE";
                    SqlCommand Command = new SqlCommand(sp, base.Conexion);
                    Command.CommandType = CommandType.StoredProcedure;
                    SqlParameter paramId = new SqlParameter("id", SqlDbType.BigInt);
                    SqlParameter paramRazonSocial = new SqlParameter("razonSocial", SqlDbType.VarChar);
                    SqlParameter paramCuit = new SqlParameter("cuit", SqlDbType.VarChar);
                    SqlParameter paramTelefono = new SqlParameter("telefono", SqlDbType.VarChar);
                    SqlParameter paramMaximoSalas = new SqlParameter("maximoSalas", SqlDbType.SmallInt);
                    SqlParameter paramActiva = new SqlParameter("activa", SqlDbType.TinyInt);
                    SqlParameter paramUserId = new SqlParameter("userId", SqlDbType.UniqueIdentifier);

                    paramId.Direction = ParameterDirection.InputOutput;
                    paramId.Value = empresa.Id;
                    paramRazonSocial.Direction = ParameterDirection.Input;
                    paramRazonSocial.Value = empresa.RazonSocial;
                    paramCuit.Direction = ParameterDirection.Input;
                    paramCuit.Value = empresa.CUIT;
                    paramTelefono.Direction = ParameterDirection.Input;
                    paramTelefono.Value = empresa.Telefono;
                    paramMaximoSalas.Direction = ParameterDirection.Input;
                    paramMaximoSalas.Value = empresa.maximoSalas;
                    paramActiva.Direction = ParameterDirection.Input;
                    paramActiva.Value = empresa.activo;
                    paramUserId.Direction = ParameterDirection.Input;
                    paramUserId.Value = userIdentification;

                    Command.Parameters.Add(paramId);
                    Command.Parameters.Add(paramRazonSocial);
                    Command.Parameters.Add(paramCuit);
                    Command.Parameters.Add(paramTelefono);
                    Command.Parameters.Add(paramMaximoSalas);
                    Command.Parameters.Add(paramActiva);
                    Command.Parameters.Add(paramUserId);

                    int filasAfectadas = Command.ExecuteNonQuery();

                    empresa.Id = long.Parse(Command.Parameters["id"].Value.ToString());
                    return empresa;
                }
                else
                {
                    throw new BDDException();
                }

            }
            catch (SqlException ex)
            {
                throw new BDDException("Error al querer modificar/agregar la empresa en la base de datos." + ex.Message);
            }
            finally
            {
                base.Desconectar();
            }

        }

        public Empresa getFindByGuid(Guid userId)
        {
            Empresa empresa = null;
            try
            {
                if (base.Conectar())
                {
                    SqlDataReader dataReader;
                    base.Command = new SqlCommand();
                    Usuario usuario;
                    base.Command.Connection = base.Conexion;
                    Command.CommandText = "SELECT e.id, e.activa, e.cuit, e.maximoSalas, e.razonSocial, e.telefono, u.UserName, u.UserId " +
                        "FROM Empresa e " +
                        "INNER JOIN aspnet_Users u ON (u.UserId = e.UserId) WHERE u.id = @userId";

                    Command.CommandType = CommandType.Text;
                    Command.Parameters.AddWithValue("userId", userId);
                    dataReader = Command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        empresa = new Empresa();
                        usuario = new Usuario();
                        empresa.Id = long.Parse(dataReader.GetSqlInt64(0).ToString());
                        empresa.activo = Convert.ToBoolean(dataReader.GetSqlByte(1).Value);
                        empresa.CUIT = dataReader.GetSqlString(2).ToString();
                        empresa.maximoSalas = int.Parse(dataReader.GetSqlInt16(3).ToString());
                        empresa.RazonSocial = dataReader.GetSqlString(4).ToString();
                        empresa.Telefono = dataReader.GetSqlString(5).ToString();
                        usuario.EMail = dataReader.GetSqlString(6).ToString();
                        usuario.Id = new Guid(dataReader.GetSqlGuid(7).ToString());
                        empresa.Usuario = usuario;

                    }
                    return empresa;
                }
                else
                {
                    throw new BDDException();
                }
            }
            catch (SqlException ex)
            {
                throw new BDDException("Error al intentar recuperar la empresa de la base de datos. Detalle: " + ex.Message);
            }
            finally
            {
                base.Desconectar();
            }
        }
    }
}
