using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace Persistence.DAO
{
    public interface ITurnoDAO:ICommonDAO<Turno>
    {
        Turno obtenerTurno(long idSala, long idTurno);

        void reservarTurno(long idSala, String nombreReservador, String descripcion, DateTime horaInicio, DateTime horaFin);

        void eliminarTurno(long idSala, long idTurno);

        List<Turno> obtenerTurnos(long salaId, DateTime dateTime);
    }
}
