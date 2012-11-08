using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Exceptions;

namespace Persistence.Util
{
    public class BDDException : BusinessException
    {
        public BDDException(String msgError)
            : base(msgError)
        {

        }
        public BDDException()
            : base("Error en la conexión con la de Base de datos.")
        {

        }
    }
}
