using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Services.Service;
using Model;
using Persistence.DAO;
using Persistence.Util;
using log4net;

namespace Services.ServiceImpl
{
    public class EmpresaService:IEmpresaService
    {
        private IEmpresaDAO empresaDAO = DAOLocator.Instance.EmpresaDAO;
        ILog logger = log4net.LogManager.GetLogger(typeof(EmpresaService));


        public List<Empresa> getAll()
        {
            List<Empresa> empresas = this.empresaDAO.getAll();
            logger.Debug("Se pidieron todas las empresas. Devolvió: ");
            return empresas;
        }

        public Empresa getFindById(long id)
        {
            return this.empresaDAO.getFindById(id);
            
        }

        public Empresa saveOrUpdate(Empresa entity)
        {
            return this.empresaDAO.saveOrUpdate(entity);
        }

        public void delete(Empresa entity)
        {
            this.empresaDAO.delete(entity);
        }

        public Empresa saveOrUpdate(Empresa empresa, Guid userIdenficator)
        {
            return this.empresaDAO.saveOrUpdate(empresa, userIdenficator);
        }


        public Empresa getFindByGuid(Guid userId)
        {
            return this.empresaDAO.getFindByGuid(userId);
        }
    }
}
