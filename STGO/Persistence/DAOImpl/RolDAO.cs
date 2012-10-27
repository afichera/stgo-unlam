using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Persistence.DAO;
using Model;

namespace Persistence.DAOImpl
{
    public class RolDAO:BaseDAO, ICommonDAO<Rol>, IRolDAO
    {

        public List<Rol> getAll()
        {
            throw new NotImplementedException();
        }

        public List<Rol> getFindById(long id)
        {
            throw new NotImplementedException();
        }

        public Rol saveOrUpdate(Rol entity)
        {
            throw new NotImplementedException();
        }

        public void delete(Rol entity)
        {
            throw new NotImplementedException();
        }
    }
}
