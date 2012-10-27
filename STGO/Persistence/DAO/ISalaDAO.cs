using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace Persistence.DAO
{
    public interface ISalaDAO
    {
        List<Sala> obtenerSalasEmpresa(long idEmpresa);
    }
}
