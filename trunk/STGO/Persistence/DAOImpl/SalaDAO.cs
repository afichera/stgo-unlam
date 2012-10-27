using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Persistence.DAO;
using Model;

namespace Persistence.DAOImpl
{
    public class SalaDAO:BaseDAO, ICommonDAO<Sala>, ISalaDAO
    {
        public List<Sala> obtenerSalasEmpresa(long idEmpresa)
        {
            //TODO: Implememtar
            return null;
        }

        public List<Sala> getAll()
        {
            throw new NotImplementedException();
        }

        public List<Sala> getFindById(long id)
        {
            throw new NotImplementedException();
        }

        public Sala saveOrUpdate(Sala entity)
        {
            throw new NotImplementedException();
        }

        public void delete(Sala entity)
        {
            throw new NotImplementedException();
        }
    }
}
