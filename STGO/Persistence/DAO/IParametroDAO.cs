﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace Persistence.DAO
{
    public interface IParametroDAO:ICommonDAO<Parametro>
    {
        Parametro getFindByClave(String clave);
    }
}
