using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace Services.Service
{
    public interface ISalaService
    {
        List<Sala> obtenerSalas();

        List<Sala> obtenerSalasEmpresa(long idEmpresa);
    }
}
