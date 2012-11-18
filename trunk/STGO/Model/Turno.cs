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
            int minutos;
            int minutosOther;

            if (this.FechaHoraInicio == null)
                return (other.FechaHoraInicio == null) ? 0 : 1;

            if (other.FechaHoraInicio == null)
                return -1;

            minutosOther = (other.FechaHoraInicio.Hour * 60) + other.FechaHoraInicio.Minute;
            minutos = (this.FechaHoraInicio.Hour * 60) + this.FechaHoraInicio.Minute;
            return minutos.CompareTo(minutosOther);
            
        }
    }
}
