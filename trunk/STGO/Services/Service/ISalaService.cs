using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace Services.Service
{
    public interface ISalaService:ICommonService<Sala>
    {
        Sala saveOrUpdate(Sala sala, Empresa empresa);

        List<Sala> obtenerSalas();

        List<Sala> obtenerSalasEmpresa(long idEmpresa);

        int cantidadSalasEmpresa(long idEmpresa);
    }
}
