using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Persistence.DAO;
using Model;
using System.Data.SqlClient;
using System.Data;

namespace Persistence.DAOImpl
{
    public class RegistracionDAO:BaseDAO, IRegistracionDAO
    {
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
            throw new NotImplementedException();
        }

        public Registracion getFindByUserName(string userName)
        {
            Registracion registracion = null;
            if (base.Conectar())
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
                    registracion.RazonSocial =dataReader.GetSqlString(0).ToString();
                    registracion.Email = dataReader.GetSqlString(1).ToString();
                    registracion.Cuit = dataReader.GetSqlString(2).ToString();
                    registracion.Telefono = dataReader.GetSqlString(3).ToString();                    
                    registracion.FechaHoraRegistro = DateTime.Parse(dataReader.GetSqlDateTime(4).ToString());
                    registracion.Pendiente = Convert.ToBoolean(dataReader.GetSqlByte(5).Value);
                    registracion.linkActivacion = new Guid(dataReader.GetSqlGuid(6).ToString());
                }
                base.Desconectar();
            }
            return registracion;
        }


        public void crearPendiente(Registracion entity, Guid guid)
        {
            Registracion registracion = entity;

            if (base.Conectar())
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

                base.Desconectar();
            }
            
        }
    }
}
