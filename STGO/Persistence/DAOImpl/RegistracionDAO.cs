using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Persistence.DAO;
using Model;

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
    }
}
