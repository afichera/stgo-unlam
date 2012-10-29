using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace Persistence.DAO
{
    public interface ISalaDAO:ICommonDAO<Sala>
    {
        List<Sala> obtenerSalasEmpresa(long idEmpresa);
        Sala saveOrUpdate(Sala sala, long idEmpresa);

        int cantidadSalasEmpresa(long idEmpresa);
    }
}
