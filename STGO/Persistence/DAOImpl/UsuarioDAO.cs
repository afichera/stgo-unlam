using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Persistence.DAO;
using Model;

namespace Persistence.DAOImpl
{
    public class UsuarioDAO : BaseDAO, IUsuarioDAO
    {

        public List<Usuario> getAll()
        {
            List<Usuario> usuarios = null;
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
            return usuarios;

        }
        public Usuario getFindById(long id)
        {
            return null;
            //TODO:
        }
        public Usuario getFindByEmail(String email)
        {
            return null;
            //TODO:
        }
        public Usuario saveOrUpdate(Usuario usuario)
        {
            return null;
            //TODO:
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
            if (base.Conectar())
            {
                SqlDataReader dataReader;
                base.Command = new SqlCommand();
                Usuario usuario;
                 

                base.Command.Connection = base.Conexion;
                Command.CommandText = "SELECT u.UserName, m.Password, e.id FROM aspnet_Users u INNER JOIN aspnet_Membership m ON (u.UserId = m.UserId) INNER JOIN Empresa e ON (u.UserId = e.UserId) WHERE u.UserName = @UserName";
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
                base.Desconectar();
            }
            return empresaId;
        }
    }
}
