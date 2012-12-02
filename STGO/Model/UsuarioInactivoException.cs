using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Exceptions;

namespace Model
{
    public class UsuarioInactivoException:BusinessException
    {
                public UsuarioInactivoException(String msgError) : base(msgError) { }

                public UsuarioInactivoException(): base("El usuario esta desactivado.")
                { 
        
        }
    }
}
