using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Sala
    {
        public long Id { get; set; }
        public String Nombre { get; set; }
        public Boolean PermiteMultiplo { get; set; }
        public int Frecuencia { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraCierre { get; set; }

        public Sala(String nombre, Boolean permiteMultiplo, int frecuencia, DateTime horaInicio, DateTime horaCierre)
        {
            this.Nombre = nombre;
            this.PermiteMultiplo = permiteMultiplo;
            this.Frecuencia = frecuencia;
            this.HoraInicio = horaInicio;
            this.HoraCierre = horaCierre;
        }
    }


}
