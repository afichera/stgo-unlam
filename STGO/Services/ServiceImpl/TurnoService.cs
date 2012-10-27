using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using Services.Service;
using Persistence.DAO;
using Persistence.Util;

namespace Services.ServiceImpl
{
    public class TurnoService:ITurnoService, ICommonService<Turno>
    {
        private ITurnoDAO turnoDAO = DAOLocator.Instance.TurnoDAO;

        public List<Turno> getAll()
        {
            throw new NotImplementedException();
        }

        public Turno getFindById(long id)
        {
            throw new NotImplementedException();
        }

        public Turno saveOrUpdate(Turno entity)
        {
            throw new NotImplementedException();
        }

        public void delete(Turno entity)
        {
            throw new NotImplementedException();
        }

        public List<Turno> obtenerTurnosReservados(long idSala, DateTime fecha)
        {
            throw new NotImplementedException();
        }

        public List<Turno> obtenerTurnosLibres(long idSala, DateTime fecha)
        {
            throw new NotImplementedException();
        }

        public Turno obtenerTurno(long idSala, long idTurno)
        {
            throw new NotImplementedException();
        }

        public void reservarTurno(long idSala, string nombreReservador, string descripcion, DateTime horaInicio, DateTime horaFin)
        {
            throw new NotImplementedException();
        }

        public void eliminarTurno(long idSala, long idTurno)
        {
            throw new NotImplementedException();
        }
    }
}
