using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Exceptions
{
    public class RegistracionExpiradaException:BusinessException
    {
        public RegistracionExpiradaException(String msgError) : base(msgError) { }

        public RegistracionExpiradaException():base("Expiró el tiempo para activar la cuenta. Debe volver a registrarse para ingresar en el sistema.") { 
        
        }
    }
}
