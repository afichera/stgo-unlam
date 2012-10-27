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
    public class EmpresaService:IEmpresaService, ICommonService<Empresa>
    {
        private IEmpresaDAO empresaDAO = DAOLocator.Instance.EmpresaDAO;


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
