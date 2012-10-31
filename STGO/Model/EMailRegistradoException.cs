using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Exceptions
{
    public class EMailRegistradoException:BusinessException
    {
        public EMailRegistradoException(String msgError) : base(msgError) { 
        }

        public EMailRegistradoException() : base("El Email ingresado ya se encuentra registrado.") { 
        }
    }
}
