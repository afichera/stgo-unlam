using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using Services.Service;
using Persistence.DAO;
using Persistence.Util;

namespace Services.ServiceImpl
{
    public class UsuarioService:IUsuarioService
    {
        private IUsuarioDAO usuarioDAO = DAOLocator.Instance.UsuarioDAO;

        public List<Usuario> getAll()
        {
            throw new NotImplementedException();
        }

        public Usuario getFindById(long id)
        {
            throw new NotImplementedException();
        }

        public Usuario saveOrUpdate(Usuario entity)
        {
            throw new NotImplementedException();
        }

        public void delete(Usuario entity)
        {
            throw new NotImplementedException();
        }

        public long login(string email, string password)
        {
            return this.usuarioDAO.login(email, password);
        }

        public Usuario getFindByEmail(string email)
        {
            throw new NotImplementedException();
        }
    }
}
