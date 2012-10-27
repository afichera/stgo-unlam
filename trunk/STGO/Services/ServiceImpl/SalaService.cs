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
    public class SalaService:ISalaService, ICommonService<Sala>
    {
        private ISalaDAO salaDAO = DAOLocator.Instance.SalaDAO;

        public List<Sala> getAll()
        {
            throw new NotImplementedException();
        }

        public Sala getFindById(long id)
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

        public List<Sala> obtenerSalas()
        {
            throw new NotImplementedException();
        }

        public List<Sala> obtenerSalasEmpresa(long idEmpresa)
        {
            throw new NotImplementedException();
        }
    }
}
