using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Empresa
    {
        public long Id { get; set; }
        public String RazonSocial { get; set; }
        public String CUIT { get; set; }
        public String Telefono { get; set; }
        public Usuario Usuario { get; set; }
        public Boolean activo { get; set; }
        public int maximoSalas { get; set; }

        public Empresa(String razonSocial, String cuit, String telefono, Usuario usuario)
        {
            this.Usuario = usuario;
            this.RazonSocial = razonSocial;
            this.CUIT = cuit;
            this.Telefono = telefono;
        }

    }

}
