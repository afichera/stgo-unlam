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
    public class ParametroService:IParametroService
    {
        private IParametroDAO parametroDAO = DAOLocator.Instance.ParametroDAO;


        public List<Parametro> getAll()
        {
            throw new NotImplementedException();
        }

        public Parametro getFindById(long id)
        {
            throw new NotImplementedException();
        }

        public Parametro saveOrUpdate(Parametro entity)
        {
            throw new NotImplementedException();
        }

        public void delete(Parametro entity)
        {
            throw new NotImplementedException();
        }

        public Parametro getFindByClave(string clave)
        {
            throw new NotImplementedException();
        }
    }
}
