using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Turno : IComparable<Turno>
    {
        public long Id { get; set; }
        public String Reservador { get; set; }
        public DateTime FechaHoraInicio { get; set; }
        public DateTime FechaHoraFin { get; set; }
        public String Descripcion { get; set; }



        public int CompareTo(Turno other)
        {
            if (this.FechaHoraInicio == null)
                return (other.FechaHoraInicio == null) ? 0 : 1;

            if (other.FechaHoraInicio == null)
                return -1;

            return this.FechaHoraInicio.CompareTo(other.FechaHoraInicio);
            
        }
    }
}
