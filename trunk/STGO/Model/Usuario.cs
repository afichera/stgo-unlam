using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Usuario
    {
        public long Id{ get; set; }
        public String EMail { get; set; }
        public String Descripcion{ get; set; }
        public String Password{ get; set; }
        public Rol Rol { get; set; }

        public Usuario() { 
        }

        public Usuario(String eMail, String password, String descripcion, Rol rol) 
        {
            this.Rol = rol;
            this.Descripcion = descripcion;
            this.EMail = eMail;
            this.Password = password;
        }


    }

    
}
