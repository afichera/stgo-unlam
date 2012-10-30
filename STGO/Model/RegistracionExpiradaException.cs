using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Exceptions
{
    public class RegistracionExpiradaException:BusinessException
    {
        public RegistracionExpiradaException(String msgError) : base(msgError) { }
    }
}
