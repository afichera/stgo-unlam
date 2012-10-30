using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace Persistence.DAO
{
    public interface IRegistracionDAO:ICommonDAO<Registracion>
    {

        Registracion getFindByUserName(String userName);

        void crearPendiente(Registracion registracion, Guid guid);
    }
}
