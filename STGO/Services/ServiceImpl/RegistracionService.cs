using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Services.Service;
using Model;
using Persistence.DAO;
using Persistence.Util;

namespace Services.ServiceImpl
{
    public class RegistracionService:IRegistracionService, ICommonService<Registracion>
    {
        private IRegistracionDAO registracionDAO = DAOLocator.Instance.RegistracionDAO;


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
