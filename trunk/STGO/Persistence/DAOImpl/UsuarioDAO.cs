using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Persistence.DAO;
using Model;
using log4net;
using Persistence.Util;

namespace Persistence.DAOImpl
{
    public class UsuarioDAO : BaseDAO, IUsuarioDAO
    {
        private static ILog logger = log4net.LogManager.GetLogger(typeof(TurnoDAO));

        public List<Usuario> getAll()
        {
            List<Usuario> usuarios = null;
            try
            {
                if (base.Conectar())
                {
                    SqlDataReader dataReader;
                    base.Command = new SqlCommand();
                    Usuario usuario;
                    Rol rol;

                    base.Command.Connection = base.Conexion;
                    Command.CommandText = "SELECT u.id, u.email, u.password, u.descripcion, r.id, r.descripcion FROM usuario u INNER JOIN rol r ON (r.id = u.rol_id)";
                    Command.CommandType = CommandType.Text;
                    dataReader = Command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        usuario = new Usuario();
                        usuario.Id = new Guid(dataReader.GetSqlGuid(0).ToString());
                        usuario.EMail = dataReader.GetSqlString(1).ToString();
                        usuario.Password = dataReader.GetSqlString(2).ToString();
                        usuario.Descripcion = dataReader.GetSqlString(3).ToString();

                        rol = new Rol();
                        rol.Id = dataReader.GetInt32(4);
                        rol.descripcion = dataReader.GetSqlString(5).ToString();

                        usuario.Rol = rol;

                        usuarios.Add(usuario);
                    }

                }
                else {
                    logger.Error(Constantes.ERROR_BDD_CONEXION);
                    throw new BDDException();
                }
                return usuarios;

            }
            catch (SqlException ex)
            {
                logger.Error("Ocurrio un error al intentar obtener la lista de ususarios. Detalle: " + ex.StackTrace);
                throw new BDDException("Ocurrio un error al intentar obtener la lista de ususarios. Detalle: " + ex.Message);
            }
            finally {
                base.Desconectar();
            }

        }
        public Usuario getFindById(long id)
        {
            throw new NotImplementedException();
        }
        public Usuario getFindByEmail(String email)
        {
            throw new NotImplementedException();
        }
        public Usuario saveOrUpdate(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public void delete(Usuario entity)
        {
            throw new NotImplementedException();
        }

        Usuario IUsuarioDAO.getFindByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public long login(string email, string password)
        {
            long empresaId = -1;
            try
            {
                if (base.Conectar())
                {
                    SqlDataReader dataReader;
                    base.Command = new SqlCommand();
                    Usuario usuario;


                    base.Command.Connection = base.Conexion;
                    Command.CommandText = "SELECT u.UserName, m.Password, e.id FROM aspnet_Users u INNER JOIN aspnet_Membership m ON (u.UserId = m.UserId) INNER JOIN Empresa e ON (u.UserId = e.UserId) WHERE u.UserName = @UserName AND E.fechaHoraBaja IS NULL AND E.activa = 1";
                    Command.CommandType = CommandType.Text;
                    Command.Parameters.AddWithValue("UserName", email.ToUpper());
                    dataReader = Command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        usuario = new Usuario();
                        usuario.EMail = dataReader.GetSqlString(0).ToString();
                        usuario.Password = dataReader.GetSqlString(1).ToString();
                        empresaId = long.Parse(dataReader.GetSqlInt64(2).ToString());
                    }

                }
                else {
                    logger.Error(Constantes.ERROR_BDD_CONEXION);
                    throw new BDDException();
                }
                return empresaId;

            }
            catch (SqlException ex)
            {
                logger.Error("Ocurrió un error al validar el loggin para el usuario: " + email + ". Detalle: " + ex.StackTrace);
                throw new BDDException("Ocurrió un error al validar el loggin. Detalle: " + ex.Message);
            }
            finally {
                base.Desconectar();            
            }
        }
    }
}
