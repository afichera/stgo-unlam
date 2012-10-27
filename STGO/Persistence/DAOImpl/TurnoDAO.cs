using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Persistence.DAO;
using Model;

namespace Persistence.DAOImpl
{
    public class TurnoDAO:BaseDAO, ICommonDAO<Turno>, ITurnoDAO
    {

        public List<Turno> getAll()
        {
            throw new NotImplementedException();
        }

        public List<Turno> getFindById(long id)
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
