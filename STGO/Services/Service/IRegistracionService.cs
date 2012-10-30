using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace Services.Service
{
    public interface IRegistracionService:ICommonService<Registracion>
    {

        void newAccountValidate(String userName);

        void completarRegistro(Registracion registracion, Guid guid);

        String obtenerCuerpoMailActivacion(String userName);
    }
}
