﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace Services.Service
{
    public interface IParametroService
    {
        Parametro getFindByClave(String clave);
    }
}