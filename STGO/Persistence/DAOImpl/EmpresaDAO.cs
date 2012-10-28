using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Persistence.DAO;
using Model;

namespace Persistence.DAOImpl
{
    public class EmpresaDAO:BaseDAO, IEmpresaDAO
    {

        public List<Empresa> getAll()
        {
            throw new NotImplementedException();
        }

        public Empresa getFindById(long id)
        {
            throw new NotImplementedException();
        }

        public Empresa saveOrUpdate(Empresa entity)
        {
            throw new NotImplementedException();
        }

        public void delete(Empresa entity)
        {
            throw new NotImplementedException();
        }
    }
}
