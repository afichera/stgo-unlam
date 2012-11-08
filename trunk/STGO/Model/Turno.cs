using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Turno
    {
        public long Id { get; set; }
        public String Reservador { get; set; }
        public DateTime FechaHoraInicio { get; set; }
        public DateTime FechaHoraFin { get; set; }
        public String Descripcion { get; set; }
    }
}
