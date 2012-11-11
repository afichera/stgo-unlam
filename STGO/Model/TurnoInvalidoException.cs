using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Exceptions
{
    public class TurnoInvalidoException : Model.Exceptions.BusinessException
    {
        public TurnoInvalidoException(String msgError) : base(msgError) { }

        public TurnoInvalidoException():base("El turno es invalido.") { 
        
        }
    }
}
