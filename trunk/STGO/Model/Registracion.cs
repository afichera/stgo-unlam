using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Registracion
    {
        public String Email { get; set; }
        public String RazonSocial { get; set; }
        public String Cuit { get; set; }
        public String Telefono { get; set; }
        public DateTime FechaHoraRegistro { get; set; }
        public bool Pendiente { get; set; }
        public String password { get; set; }
    }
}
