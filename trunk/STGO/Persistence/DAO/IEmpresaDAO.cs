using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace Persistence.DAO
{
    public interface IEmpresaDAO:ICommonDAO<Empresa>
    {
        Empresa saveOrUpdate(Empresa entity, Guid userIdentification);

        Empresa getFindByGuid(Guid userId);
    }
}
