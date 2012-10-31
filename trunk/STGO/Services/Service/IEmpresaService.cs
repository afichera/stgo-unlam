using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace Services.Service
{
    public interface IEmpresaService:ICommonService<Empresa>
    {
        Empresa saveOrUpdate(Empresa empresa, Guid userIdenficator);

        Empresa getFindByGuid(Guid userId);

    }
}
