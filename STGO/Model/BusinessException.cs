using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Exceptions
{
    public class BusinessException : ApplicationException
    {
        public BusinessException(String msgError)
            : base(msgError)
        {

        }

        public BusinessException():base("Ocurrio un error. Contactese con el administrador del sistema.") {
            
            
        }
    }
}
