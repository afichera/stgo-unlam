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
    public class RolService:IRolService, ICommonService<Rol>
    {
        private IRolDAO rolDAO = DAOLocator.Instance.RolDAO;


        public List<Rol> getAll()
        {
            throw new NotImplementedException();
        }

        public Rol getFindById(long id)
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
