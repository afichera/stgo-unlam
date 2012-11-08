using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace Services.Service
{
    public interface ITurnoService:ICommonService<Turno>
    {
        List<Turno> obtenerTurnosReservados(long idSala, DateTime fecha);

        List<Turno> obtenerTurnosLibres(long idSala, DateTime fecha);

        Turno obtenerTurno(long idSala, long idTurno);

        void reservarTurno(long idSala, String nombreReservador, String descripcion, DateTime horaInicio, DateTime horaFin);

        void eliminarTurno(long idSala, long idTurno);

        List<Turno> obtenerTurnos(long p, DateTime dateTime);
    }
}
